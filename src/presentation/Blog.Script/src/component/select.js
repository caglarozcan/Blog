"use strict";

var ChSelect = function () {

	var properties = {
		element: null,
		searchable: false,
		options: [],
		selectedOptions: [],
		placeholder: '',
		searchText: '',
		dropdown: null,
		multiple: null,
		disabled: null
	};

	var initComponent = function (selector, options) {
		properties.element = Util.find(selector);
		properties.searchable = false;

		properties.placeholder = Util.getAttribute(properties.element, 'placeholder') || options.placeholder || 'Bir deðer seçiniz';
		properties.searchText = Util.getAttribute(properties.element, 'searchtext') || options.searchText || 'Ara..';

		this.multiple = Util.getAttribute(properties.element, 'multiple');
		this.disabled = Util.getAttribute(properties.element, 'disabled');

		properties.element.style.opacity = "0";
		properties.element.style.padding = "0";
		properties.element.style.width = "0";
		properties.element.style.height = "0";

		processData();
	};

	var processData = function () {
		var options = Util.findAll('option,optgroup', properties.element);
		var data = [];
		var allOptions = [];
		var selectedOptions = [];

		options.forEach(item => {
			if (item.tagName == 'OPTGROUP') {
				var itemData = {
					text: item.label,
					value: 'optgroup'
				};
			} else {
				var text = item.innerText;
				if (item.dataset.display != undefined) text = dataset.display;

				var itemData = {
					text: text,
					value: item.value,
					selected: Util.getAttribute(item, 'selected') != null,
					disabled: Util.getAttribute(item, 'disabled') != null
				};
			}

			var attributes = {
				selected: Util.getAttribute(item, 'selected') != null,
				disabled: Util.getAttribute(item, 'disabled') != null,
				optgroup: item.tagName == 'OPTGROUP'
			};

			data.push(itemData);
			allOptions.push({ data: itemData, attributes: attributes });
		});

		properties.data = data;
		properties.options = allOptions;
		properties.options.forEach(item => {
			if (item.attributes.selected) selectedOptions.push(item);
		});
		properties.selectedOptions = selectedOptions;
	};

	return {
		init: function (selector, options) {
			initComponent(selector, options);
		}
	};
}();

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = ChSelect;
}