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
			this.settings = { ...settings };
			this.el = {
				container: find(this.settings.selector),
			};

			this.getSelectedBlockType = this.getSelectedBlockType.bind(this);
			this.getCurrentBlock = this.getCurrentBlock.bind(this);
			this.init();
		};

		init() {
			this.el = {
				...this.el,
				iframe: find(this.settings.selector + ' iframe'),
				doc: find(this.settings.selector + ' iframe').contentWindow.document
			};

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
			this.el.doc.body.addEventListener('keyup', this.getSelectedBlockType);
			this.el.doc.body.addEventListener('mouseup', this.getSelectedBlockType);
			this.el.doc.body.addEventListener('mouseup', this.getCurrentBlock);
		}

		getSelectedBlockType(e) {
			const key = e.key || e.keyCode;
			if (e.type === "mouseup" || (key === "Enter" || key === 13 || key === "Backspace" || key === 8)) {
				const selection = this.el.doc.getSelection().anchorNode.parentNode;
				const parentType = selection.parentNode.nodeName.toLowerCase();
				const type = selection.nodeName.toLowerCase();

				console.log(type);

				//menü butonu aktif et.
				/*
				$all('.toolbar__btn[data-format="block"]', this.el.toolbar).forEach(
				btn => {
					if (btn.dataset.type === type || btn.dataset.type === parentType) {
						btn.classList.add("is-selected");
					} else {
						btn.classList.remove("is-selected");
					}
				});
				*/
			}
		}

		getCurrentBlock() {
			const selection = this.el.doc.getSelection().anchorNode.parentNode;
			const type = selection.nodeName.toLowerCase();
			if (type === "body" || type === "html") return;
			const children = this.el.doc.body.childNodes;
			let index = 0;
			for (let i = 0; i < children.length; i++) {
				if (children[i] == selection) {
					index = i;
					break;
				}
			}
			const currentBlock = {
				index,
				type,
				text: selection.textContent
			};
			console.log(currentBlock);
			return currentBlock;
		}
	};

	return Editor;
})();