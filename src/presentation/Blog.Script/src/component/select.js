"use strict";

const { hasClass } = require("../util/util");

var ChSelect = function () {

	var properties = {
		element: null,
		searchable: true,
		options: [],
		selectedOptions: [],
		placeholder: '',
		searchText: '',
		dropdown: null,
		multiple: false,
		disabled: null
	};

	//Begin::Events
	// utility functions
	var triggerClick = function (el) {
		var event = document.createEvent("MouseEvents");
		event.initEvent("click", true, false);
		el.dispatchEvent(event);
	};

	var triggerChange = function (el) {
		var event = document.createEvent("HTMLEvents");
		event.initEvent("change", true, false);
		el.dispatchEvent(event);
	};

	var triggerFocusIn = function (el) {
		var event = document.createEvent("FocusEvent");
		event.initEvent("focusin", true, false);
		el.dispatchEvent(event);
	};

	var triggerFocusOut = function (el) {
		var event = document.createEvent("FocusEvent");
		event.initEvent("focusout", true, false);
		el.dispatchEvent(event);
	};

	var triggerModalOpen = function(el) {
		var event = document.createEvent("UIEvent");
		event.initEvent("modalopen", true, false);
		el.dispatchEvent(event);
	}

	var triggerModalClose = function(el) {
		var event = document.createEvent("UIEvent");
		event.initEvent("modalclose", true, false);
		el.dispatchEvent(event);
	}
	//End::Events

	var initComponent = function (selector, options) {
		properties.element = Util.find(selector);
		properties.searchable = true;

		properties.placeholder = 'Bir de?er seçiniz.', //Util.getAttribute(properties.element, 'placeholder') || options.placeholder || 'Bir deðer seçiniz';
		properties.searchText = 'Ara..', //Util.getAttribute(properties.element, 'searchtext') || options.searchText || 'Ara..';

		properties.multiple = false, //Util.getAttribute(properties.element, 'multiple');
		//this.disabled = Util.getAttribute(properties.element, 'disabled');

		properties.element.style.opacity = "0";
		properties.element.style.padding = "0";
		properties.element.style.width = "0";
		properties.element.style.height = "0";

		processData();
		renderDropdown();
		bindEvent();
		renderSelectedItem();
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

	var renderDropdown = function () {
		var searchHtml = '<div class="option-search"><input type="text" placeholder="' + properties.searchText + '" /></div>';

		var html = '<div class="select">';
		html += '<div class="select-content">';
		html += '<i class="fa-duotone fa-chevron-down fa-fw"></i>';
		html += '</div>';
		html += '<div class="option-box">';
		html += (properties.searchable ? searchHtml : '');
		html += '<ul>';
		html += '</ul>';
		html += '</div>';
		html += '</div>';

		properties.element.insertAdjacentHTML('afterend', html);
		properties.dropdown = properties.element.nextElementSibling;

		renderSelectedItem();
		renderItems();
	};

	var renderSelectedItem = function () {
		var selectedHtml = '';
		if (properties.multiple) {
			properties.selectedOptions.forEach(item => {
				selectedHtml += $`<div class="selected-text">${item.data.text}</div>`;
			});

			selectedHtml == '' ? properties.placeholder : selectedHtml;
		} else {
			selectedHtml = properties.selectedOptions.length > 0 ? properties.selectedOptions[0].data.text : properties.placeholder;
		}

		var selectContent = Util.find('.select-content', properties.dropdown);
		selectContent.innerHTML = selectedHtml;
	};

	var renderItems = function () {
		var ul = Util.find('ul', properties.dropdown);
		properties.options.forEach(item => {
			ul.appendChild(renderItem(item));
		});
	}

	var renderItem = function (option) {
		var li = document.createElement('li');
		var span = document.createElement('span');
		span.innerText = option.data.text;
		var icon = document.createElement('i');
		Util.addClass(icon, 'fa-duotone');
		Util.addClass(icon, 'fa-check');
		Util.addClass(icon, 'fa-fw');

		li.setAttribute('data-value', option.data.value);
		li.appendChild(span);

		option.attributes.selected ? li.appendChild(icon) : null;
		option.attributes.selected ? li.classList.add('selected') : null;
		option.attributes.disabled ? li.classList.add('disabled') : null;

		return li;
	}

	var bindEvent = function () {
		properties.dropdown.addEventListener('click', _onClicked.bind(this));
		properties.dropdown.addEventListener("focusin", triggerFocusIn.bind(this, properties.element));
		properties.dropdown.addEventListener("focusout", triggerFocusOut.bind(this, properties.element));
	};

	var _onClicked = function (e) {
		e.preventDefault();
		if (!Util.hasClass(properties.dropdown, 'show')) {
			Util.addClass(properties.dropdown, 'show');
			triggerModalOpen(properties.element);
		} 

		if (Util.hasClass(properties.dropdown, 'show')) {

		} else {
			properties.dropdown.focus();
		}
		/*else {
			Util.removeClass(properties.dropdown, 'show');
			triggerModalClose(properties.element);
		}*/
	};

	return {
		init: function (selector, options) {
			initComponent(selector, options);
		}
	};
}();

Util.onDOMContentLoaded(function () {
	ChSelect.init('.chselect');
});

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = ChSelect;
}