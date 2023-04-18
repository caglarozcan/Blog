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

	var Editor = function (selector) {
		this.editor = document.querySelector(selector);
		this.menu = document.querySelector('.editor-menu .menu');
		this.init();
	}

	var editorProto = Editor.prototype;

	editorProto.init = function () {
		var editor = this;

		var menuItems = Element.prototype.querySelectorAll.call(editor.menu, 'li:not(.seperator)');

		menuItems.forEach((item) => {
			console.log(item);
		});

		console.log(menuItems);
	}

	return Editor;
});