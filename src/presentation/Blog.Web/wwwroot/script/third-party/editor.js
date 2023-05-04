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

		console.log(menuItems);

		menuItems.forEach((item, i) => {
			console.log(i);
			console.log(item);
		});
	};

	return Editor;
});