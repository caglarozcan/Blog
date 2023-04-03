(function (root, factory) {
	var plugin = "ChSelect";

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
	}

	var findAll = function (selector, element = document.documentElement) {
		return [].concat(
			...Element.prototype.querySelectorAll.call(element, selector)
		);
	}

	var each = function (arr, fn, scope) {
		var n;
		if (isObject(arr)) {
			for (n in arr) {
				if (Object.prototype.hasOwnProperty.call(arr, n)) {
					fn.call(scope, arr[n], n);
				}
			}
		} else {
			for (n = 0; n < arr.length; n++) {
				fn.call(scope, arr[n], n);
			}
		}
	};

	var ChSelect = function (selector, options) {
		this.rootElement = find(selector);
		this.options = options;
		this.init();
	}

	var dchSelectProto = ChSelect.prototype;

	dchSelectProto.init = function () {
		var select = this;

		var selectedTextElement = find('.selected-text', select.rootElement);

		var selectContent = find('.select-content', select.rootElement);

		var name = select.rootElement.dataset.name;

		var placeHolder = select.rootElement.dataset.placeholder;
		selectedTextElement.innerHTML = placeHolder;

		var selectDropdown = find('.option-box', select.rootElement);


		var inputHidden = document.createElement('input');
		inputHidden.type = 'hidden';
		inputHidden.name = name;
		select.rootElement.appendChild(inputHidden);


		var selectOptionContainer = find('ul', selectDropdown);

		var options = findAll('li', selectOptionContainer);
		options.forEach(function (item) {
			if (item.classList.contains('selected')) {
				inputHidden.value = item.dataset.value;
			}

			item.addEventListener('click', function (e) {
				var optionValue = item.dataset.value;
				inputHidden.value = optionValue;
			});
		});

		selectContent.addEventListener('click', function (e) {
			if (selectDropdown.classList.contains('hide')) {
				selectDropdown.classList.remove('hide');
				selectDropdown.classList.add('show');
			} else {
				selectDropdown.classList.remove('show');
				selectDropdown.classList.add('hide');
			}
		}, true);
	}

	return ChSelect;
});