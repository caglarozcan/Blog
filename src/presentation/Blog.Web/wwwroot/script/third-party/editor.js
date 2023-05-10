(function (root, factory) {
	var plugin = "Editor";

	if (typeof exports === "object") {
		module.exports = factory(plugin);
	} else if (typeof define === "function" && define.amd) {
		define([], factory(plugin));
	} else {
		root[plugin] = factory(plugin);
	}
})(typeof global !== "undefined" ? global : this.window || this.global, function (plugin) {
	"use strict";

	var find = function (selector, element = document.documentElement) {
		return Element.prototype.querySelector.call(element, selector);
	};

	var findAll = function (selector, element = document.documentElement) {
		return [].concat(
			...Element.prototype.querySelectorAll.call(element, selector)
		);
	};

	var isHidden = function (el) {
		var style = window.getComputedStyle(el);
		return (style.display === 'none')
	}

	var Editor = function (selector) {
		var editor = find(selector);
		var iframe = find('#richEditor', editor);
		this.el = {
			parentContainer: editor,
			menu: find('.editor-menu > .menu', editor),
			container: iframe,
			footer: find('.editor-footer', editor),
			doc: iframe.contentWindow.document,
			textarea: find('textarea', editor)
		};

		this.init();
	};

	var editorProto = Editor.prototype;

	editorProto.init = function () {
		var editor = this;
		editor.el.doc.body.setAttribute('contenteditable', "true");
		editor.el.doc.execCommand('defaultParagraphSeparator', false, 'p');

		editor.el.doc.body.addEventListener('input', function () {
			var firstChild = editor.el.doc.body.firstChild;
			if (!firstChild || firstChild.nodeType !== 3) return;
			var range = document.createRange();
			range.selectNodeContents(firstChild);
			var selection = window.getSelection();
			selection.removeAllRanges();
			selection.addRange(range);
			editor.el.doc.execCommand('formatBlock', false, 'p');
			editor.el.doc.body.focus();
		});

		editor.el.doc.body.addEventListener("keyup", this.getBlockType);
		editor.el.doc.body.addEventListener("mouseup", this.getBlockType);

		//Switch Editor
		var switchEditor = find('[data-process="switchcode"]', editor.el.menu);
		switchEditor.addEventListener('click', function () {

			editor.el.textarea.value = editor.el.doc.body.innerHTML;

			if (isHidden(editor.el.textarea)) {
				editor.el.container.style.display = 'none';
				editor.el.textarea.style.display = 'block';
			} else {
				editor.el.textarea.style.display = 'none';
				editor.el.container.style.display = 'block';
			}
		});
	};

	editorProto.getBlockType = function (e) {
		console.log(this);
		const key = e.key || e.keyCode;
		if (
			e.type === "mouseup" ||
			(key === "Enter" ||
				key === 13 ||
				key === "Backspace" ||
				key === 8)
		) {
			const selection = this.el.doc.getSelection().anchorNode.parentNode;
			const parentType = selection.parentNode.nodeName.toLowerCase();
			const type = selection.nodeName.toLowerCase();
			console.log(parentType);
			console.log(type);
		}
	}

	return Editor;
});