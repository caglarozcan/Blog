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

	var find = function (element, selector) {
		return Element.prototype.querySelector.call(element, selector);
	};

	var findAll = function (element, selector) {
		return Element.prototype.querySelectorAll.call(element, selector);
	};

	var Editor = function (selector) {
		this.editor = document.querySelector(selector);
		this.menu = document.querySelector('.editor-menu .menu');
		this.editorArea = find(this.editor, '.editor-content');
		this.state = [];
		this.init();
	};

	var editorProto = Editor.prototype;

	editorProto.init = function () {
		var el = this;
		var doc = el.editor.contentWindow.document;

		doc.execCommand('defaultParagraphSeparator', 'p');

		var menuItems = findAll(el.menu, 'li:not(.seperator)');

		console.log(menuItems);
	};

	return Editor;
});