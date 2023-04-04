function attr(element, key) {
	if (element[key] != undefined) return element[key];

	return element.getAttribute(key);
}

function data(element, key) {
	return element.getAttribute('data-' + key);
}

function hasClass(element, className) {
	if (element)
		return element.classList.contains(className);
	else
		return false;
}

function addClass(element, className) {
	if (element) return element.classList.add(className);
}

function removeClass(element, className) {
	if (element) return element.classList.remove(className);
}

var defaultOptions = {
	data: null,
	searchable: false
}

export default function ChSelect(element, options) {
	this.element = element;
	this.config = Object.assign({}, defaultOptions, options || {});
	this.data = this.config.data;
	this.selectedOptions = [];

	this.placeholder = attr(this.element, 'placeholder') || this.config.placeholder || 'Bir değer seçiniz';
	this.searchText = attr(this.element, 'searchtext') || this.config.searchText || 'Ara..';

	this.dropdown = null;
	this.multiple = attr(this.element, 'multiple');
	this.disabled = attr(this.element, 'disabled');

	this.create();
};

ChSelect.prototype.create = function () {
	this.element.style.opacity = "0";
	this.element.style.padding = "0";
	this.element.style.width = "0";
	this.element.style.height = "0";

	if (this.data)
		this.data = this.processData(this.data);
	else
		this.data = this.extractData();
};

ChSelect.prototype.processData = function (data) {
	var options = [];

	data.forEach(item => {
		options.push({
			data: item,
			attributes: {
				selected: !!item.selected,
				disabled: !!item.disabled,
				optgroup: item.value == 'optgroup'
			}
		});
	});

	this.options = options;
};

ChSelect.prototype.extractData = function () {
	var options = this.element.querySelectorAll('option,optgroup');
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
				selected: item.getAttribute('selected') != null,
				disabled: item.getAttribute('disabled') != null
			};
		}

		var attributes = {
			selected: item.getAttribute('selected') != null,
			disabled: item.getAttribute('disabled') != null,
			optgroup: item.tagName == 'OPTGROUP'
		};

		data.push(itemData);
		allOptions.push({ data: itemData, attributes: attributes });
	});

	this.data = data;
	this.options = allOptions;
	this.options.forEach(item => {
		if (item.attributes.selected) selectedOptions.push(item);
	});
	this.selectedOptions = selectedOptions;
};