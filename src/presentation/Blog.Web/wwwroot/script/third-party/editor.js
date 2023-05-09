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

	var replaceSelection = function (html) {
		var selection = window.getSelection();
		var fragment;
		if (selection.getRangeAt && selection.rangeCount) {
			var range = window.getSelection().getRangeAt(0);
			range.deleteContents();

			if (range.createContextualFragment) {
				fragment = range.createContextualFragment(html);
			}

			var firstInsertedNode = fragment.firstChild;
			var lastInsertedNode = fragment.lastChild;
			range.insertNode(fragment);

			if (firstInsertedNode) {
				range.setStartBefore(firstInsertedNode);
				range.setEndAfter(lastInsertedNode);
			}
			selection.removeAllRanges();
			selection.addRange(range);
		}
	};

	var Editor = function (selector) {
		var editor = find(selector);
		this.el = {
			parentContainer: editor,
			menu: find('.editor-menu > .menu', editor),
			textArea: find('.editor-content', editor),
			footer: find('.editor-footer', editor),
			//doc: editor.contentWindow.document
		};

		this.init();
	};

	var editorProto = Editor.prototype;

	editorProto.init = function () {
		var editor = this;
		document.execCommand('defaultParagraphSeparator', false, 'p');

		var menuItems = findAll('li:not(.seperator)', editor.el.menu);

		menuItems.forEach((item, i) => {
			var command = item.children[0];
			this.process(command);
		});
	};

	editorProto.process = function (element) {
		var command = element.getAttribute('data-process');
		switch (command) {
			case 'heading':
				this.heading(element);
				break;
			case 'bold':
				this.bold(element);
				break;
			case 'italic':
				this.italic(element);
				break;
			case 'underline':
				this.underline(element);
				break;
			case 'stroke':
				this.stroke(element);
				break;
			case 'stroke':
				this.stroke(element);
				break;
			case 'alignleft':
				this.alignLeft(element);
				break;
			case 'aligncenter':
				this.alignCenter(element);
				break;
			case 'alignright':
				this.alignRight(element);
				break;
			case 'alignjustify':
				this.alignJustify(element);
				break;
			case 'emphasize':
				this.emphasize(element);
				break;
			case 'fontcolor':
				this.fontcolor(element);
				break;
			case 'superset':
				this.superset(element);
				break;
			case 'subset':
				this.subset(element);
				break;
			case 'image':
				this.image(element);
				break;
			case 'media':
				this.media(element);
				break;
			case 'youtube':
				this.youtube(element);
				break;
			case 'table':
				this.table(element);
				break;
			case 'link':
				this.link(element);
				break;
			case 'listul':
				this.listul(element);
				break;
			case 'listol':
				this.listol(element);
				break;
			case 'quote':
				this.quote(element);
				break;
			case 'code':
				this.code(element);
				break;
			case 'switchcode':
				this.switchCode(element);
				break;
			default:
				'geçersiz komut';
				break;
		};
	};

	editorProto.heading = function (element) {
		element.addEventListener('click', function () {
			console.log('heading');
		});
	};

	editorProto.bold = function (element) {
		element.addEventListener('click', function () {
			var replace = document.createElement('b');
			replace.style.color = this.value;
			replace.textContent = window.getSelection().toString();

			replaceSelection(replace.outerHTML);
		});
	};

	editorProto.italic = function (element) {
		element.addEventListener('click', function () {
			var replace = document.createElement('i');
			replace.style.color = this.value;
			replace.textContent = window.getSelection().toString();

			replaceSelection(replace.outerHTML);
		});
	};

	editorProto.underline = function (element) {
		element.addEventListener('click', function () {
			var replace = document.createElement('u');
			replace.style.color = this.value;
			replace.textContent = window.getSelection().toString();

			replaceSelection(replace.outerHTML);
		});
	};

	editorProto.stroke = function (element) {
		element.addEventListener('click', function () {
			var replace = document.createElement('s');
			replace.style.color = this.value;
			replace.textContent = window.getSelection().toString();

			replaceSelection(replace.outerHTML);
		});
	};

	editorProto.alignLeft = function (element) {
		element.addEventListener('click', function () {
			console.log('alignLeft');
		});
	};

	editorProto.alignCenter = function (element) {
		element.addEventListener('click', function () {
			console.log('alignCenter');
		});
	};

	editorProto.alignRight = function (element) {
		element.addEventListener('click', function () {
			console.log('alignRight');
		});
	};

	editorProto.alignJustify = function (element) {
		element.addEventListener('click', function () {
			console.log('alignJustify');
		});
	};

	editorProto.emphasize = function (element) {
		element.addEventListener('click', function () {
			console.log('emphasize');
		});
	};

	editorProto.fontcolor = function (element) {
		element.addEventListener('click', function () {
			console.log('fontcolor');
		});
	};

	editorProto.superset = function (element) {
		element.addEventListener('click', function () {
			var replace = document.createElement('sup');
			replace.style.color = this.value;
			replace.textContent = window.getSelection().toString();

			replaceSelection(replace.outerHTML);
		});
	};

	editorProto.subset = function (element) {
		element.addEventListener('click', function () {
			var replace = document.createElement('sub');
			replace.style.color = this.value;
			replace.textContent = window.getSelection().toString();

			replaceSelection(replace.outerHTML);
		});
	};

	editorProto.image = function (element) {
		element.addEventListener('click', function () {
			console.log('image');
		});
	};

	editorProto.media = function (element) {
		element.addEventListener('click', function () {
			console.log('media');
		});
	};

	editorProto.youtube = function (element) {
		element.addEventListener('click', function () {
			console.log('youtube');
		});
	};

	editorProto.table = function (element) {
		element.addEventListener('click', function () {
			console.log('table');
		});
	};

	editorProto.link = function (element) {
		element.addEventListener('click', function () {
			console.log('link');
		});
	};

	editorProto.listul = function (element) {
		element.addEventListener('click', function () {
			console.log('listul');
		});
	};

	editorProto.listol = function (element) {
		element.addEventListener('click', function () {
			console.log('listol');
		});
	};

	editorProto.quote = function (element) {
		element.addEventListener('click', function () {
			console.log('quote');
		});
	};

	editorProto.code = function (element) {
		element.addEventListener('click', function () {
			console.log('code');
		});
	};

	editorProto.switchCode = function (element) {
		element.addEventListener('click', function () {
			console.log('switchcode');
		});
	};

	

	return Editor;
});