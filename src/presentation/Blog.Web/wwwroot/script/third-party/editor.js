function find(selector, el = document.documentElement) {
	return Element.prototype.querySelector.call(el, selector);
};

function findAll(selector, el = document.documentElement) {
	return [].concat(
		...Element.prototype.querySelectorAll.call(el, selector)
	);
};

function isHidden(el) {
	var style = window.getComputedStyle(el);
	return (style.display === 'none')
}

const editor_plugin = (function () {
	class Editor {
		constructor(settings) {
			const editorContainer = find(settings.selector);
			this.settings = { ...settings };
			this.el = {
				container: editorContainer,
				menuItems: findAll('.menu > li:not(.seperator)', editorContainer),
				textarea: find('textarea', editorContainer),
				footer: find('.editor-footer', editorContainer)
			};

			this.getSelectedBlockType = this.getSelectedBlockType.bind(this);
			this.showSelectedInlineStyles = this.showSelectedInlineStyles.bind(this);
			this.init();
		};

		init() {
			this.el = {
				...this.el,
				iframe: find(this.settings.selector + ' iframe'),
				doc: find(this.settings.selector + ' iframe').contentWindow.document,
			};

			let cssFile = document.createElement('link');
			cssFile.href = 'https://localhost:9000/style/editorHtml.css';
			cssFile.rel = 'stylesheet';
			cssFile.type = 'text/css';
			this.el.doc.head.appendChild(cssFile);

			this.el.doc.body.setAttribute('contenteditable', 'true');
			this.el.doc.execCommand('defaultParagraphSeparator', false, 'p');
			this.el.doc.body.addEventListener('input', () => {
				const firstChild = this.el.doc.body.firstChild;
				if (!firstChild || firstChild.nodeType !== 3) return;
				const range = document.createRange();
				range.selectNodeContents(firstChild);
				const selection = window.getSelection();
				selection.removeAllRanges();
				selection.addRange(range);
				this.el.doc.execCommand('formatBlock', false, 'p');
			});

			//test
			let sampleData = document.createElement('p');
			sampleData.innerText = "Bu yazı deneme ve test amaçlı eklenmiştir. Bu yazı da deneme ve test amaçlı eklenmiştir.";
			this.el.doc.body.appendChild(sampleData);
			this.wordCounter();
			//test

			this.el.doc.addEventListener("keyup", () => this.displayHTML(), false);
			this.el.doc.body.addEventListener('keyup', this.getSelectedBlockType);
			this.el.doc.body.addEventListener('mouseup', this.getSelectedBlockType);
			this.el.doc.body.addEventListener('mouseup', this.showSelectedInlineStyles);

			this.editorButtons();
		}

		editorButtons() {
			const codeSwitchBtn = find('[data-process="switchcode"]', this.el.container);
			codeSwitchBtn.addEventListener('click', e => {
				this.displayHTML();
				this.el.iframe.classList.toggle('hide');
				this.el.textarea.classList.toggle('hide');
			});

			this.el.menuItems.forEach(item => {
				let menu = item.children[0];
				const isCommand = menu.dataset.command;
				if (isCommand == 'true') {
					menu.addEventListener('click', e => {
						e.stopPropagation();
						e.preventDefault();
						this.selectTool(e);
					}, false);
				} else {
					//TODO : burada opsiyonlar geliştirilecek.
				}
			});
		}

		getSelectedBlockType(e) {
			const key = e.key || e.keyCode;
			if (e.type === "mouseup" || (key === "Enter" || key === 13 || key === "Backspace" || key === 8)) {
				const selection = this.el.doc.getSelection().anchorNode.parentNode;
				const parentType = selection.parentNode.nodeName.toLowerCase();
				const type = selection.nodeName.toLowerCase();

				this.el.menuItems.forEach(
					item => {
						let button = item.children[0];
						if (button.dataset.type === type || button.dataset.type === parentType) {
							button.classList.add("selected");
						} else {
							button.classList.remove("selected");
						}
					});
			}
		}

		showSelectedInlineStyles(e) {
			const selection = this.el.doc.getSelection();
			const type = selection.anchorNode.parentNode.tagName.toLowerCase();
			if (type === "body") return;
			['bold', 'italic', 'underline', 'strikeThrough', 'insertUnorderedList', 'insertOrderedList', 'superscript', 'subscript'].forEach(key => {
				const command = key;
				const btn = find(`[data-process="${command}"]`, this.el.container);
				if (this.el.doc.queryCommandState(command)) {
					btn.classList.add("selected");
				} else {
					btn.classList.remove("selected");
				}
			});
		}

		selectTool(e) {
			const target = e.currentTarget;
			const process = target.dataset.process;
			const isChanged = this.el.doc.execCommand(process, false, null);
			target.classList.toggle('selected');
			if (isChanged) {
				this.displayHTML();
			}
			this.el.doc.body.focus();
		}

		displayHTML() {
			this.el.textarea.value = this.el.doc.body.innerHTML;
			this.wordCounter();
		}

		wordCounter() {
			let text = this.el.doc.body.innerText;
			let count = text.replace(/\s+/gm, ' ').replace(/^\s+|\s+$/gm, '').split(' ').length;
			this.el.footer.innerText = 'Kelime: ' + count;
		}
	};

	return Editor;
})();