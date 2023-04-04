"use strict";

var Util = function () {
	const NODE_TEXT = 3;
	
	return {
		onDOMContentLoaded: function (callback) {
			if (document.readyState === 'loading') {
				document.addEventListener('DOMContentLoaded', callback);
			} else {
				callback();
			}
		},

		hasClass: function (element, className) {
			return element.classList.contains(className);
		},

		addClass: function (element, className) {
			return element.classList.add(className);
		},

		removeClass: function (element, className) {
			return element.classList.removeClass(className);
		},

		urlHelper: function (endpoint) {
			return 'https://localhost:9000/' + endpoint.replace(/^\/|\/$/g, '');
		},

		isElement: function (element) {
			if (!element || typeof element !== 'object') {
				return false;
			}

			return typeof element.nodeType !== 'undefined';
		},

		isArray: function (val) {
        	return Array.isArray(val);
		},

		isObject: function (val) {
			return Object.prototype.toString.call(val) === "[object Object]";
		},
		
		isJson: function (str) {
			var result = false;
			try {
				result = JSON.parse(str);
			} catch (ex) {
				return false;
			}

			return !(null === result || (!isArray(result) && !isObject(result))) && result;
		},

		find: function (selector, element = document.documentElement) {
			return Element.prototype.querySelector.call(element, selector);
		},

		findAll: function (selector, element = document.documentElement) {
			return [].concat(
				...Element.prototype.querySelectorAll.call(element, selector)
			);
		},

		childs: function (element, selector) {
			return [].concat(...element.children)
				.filter((child) => child.matches(selector));
		},

		parents: function (element, selector) {
			const parentList = [];

			let parent = element.parentNode;

			while(parent && parent.nodeType == Node.ELEMENT_NODE && parent.nodeType != NODE_TEXT){
				if (parent.matches(selector)) {
					parentList.push(parent);
				}

				parent = parent.parentNode;
			}

			return parentList;
		},

		closest: function (element, selector) {
			return Element.prototype.closest.call(element, selector);
		},

		prev: function (element, selector) {
			let previous = element.previousElementSibling;

			while (previous) {
				if (previous.matches(selector)) {
					return [previous];
				}

				previous = previous.previousElementSibling;
			}

			return [];
		},

		next: function (element, selector) {
			let next = element.nextElementSibling;

			while (next) {
				if (next.matches(selector)) {
					return [next];
				}

				next = next.nextElementSibling;
			}

			return [];
		},

		getAttribute: function (element, key) {
			return element.getAttribute(key);
		},

		getDataAttribute: function (element, key) {
			return this.getAttribute(element, key);
		},

		serialize: function (form, returnType = 'o') {
			var formElement, formData = [];

			if (typeof form === 'string') {
				formElement = this.find(form);
			} else if (typeof form === 'object' && form.nodeName === 'FORM') {
				formElement = form;
			} else {
				throw 'Form nesnesi bulunamad?.';
			}

			var formElementsLen = formElement.elements.length;

			for (var i = 0; i < formElementsLen; i++) {
				var field = formElement.elements[i];
				if (field.name && !field.disabled && field.type != 'file' && field.type != 'reset' && field.type != 'submit' && field.type != 'button') {
					formData[field.name] = field.value;
				}
			}

			if (returnType == 'o') {
				return Object.assign({}, formData);
			} else {
				return Object.keys(formData).map((key) => {
					return encodeURIComponent(key) + '=' + encodeURIComponent(formData[key])
				}).join('&');
			}
		}
	}
}();

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = Util;
}