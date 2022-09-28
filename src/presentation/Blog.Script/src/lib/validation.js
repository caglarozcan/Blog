"use strict";

var FormValidation = function () {
	var handler = function (settings) {
		const form = document.querySelector(settings.formSelector);

		if (typeof form !== 'undefined' && form != null) {
			form.addEventListener('submit', function (e) {
				e.preventDefault();

				Util.findAll('[calss*="vld-"]', form).forEach(function (el) {
					el.innerHTML = ' ';
				});

				let errorCounter = 0;
				settings.inputs.forEach(function (item) {
					let input = form.querySelector('[name="' + item.name + '"]');
					let errors = '';
					
					for (let i = 0; i < item.rules.length; i++){
						if (callRule(item.rules[i].rule, input.value)) {
							errors += item.rules[i].message;
							errorCounter++;
						}
					}

					let messageContainer = form.querySelector('.vld-' + item.name);
					if (typeof messageContainer !== 'undefined') {
						messageContainer.innerHTML = errors;
					}
				});

				if (settings.sendAjax && errorCounter == 0) {
					Ajax.send({
						method: 'POST',
						url: Util.urlHelper(Util.getAttribute(form, 'action')),
						data: Util.serialize(form)
					}).then(responseData => {
						Dailog.init({
							icon: responseData.success ? 'success' : 'danger',
							title: responseData.success ? 'İşlem başarılı..' : 'İşlem başarısız!',
							message: responseData.message,
							buttonType: 'ok'
						});

						if (settings.hasOwnProperty('ajaxAfter')) {
							if (typeof settings.ajaxAfter === 'function') {
								settings.ajaxAfter();
							}
						}
					}).catch(error => {
						console.log('Error : ', error);
						Dailog.init({
							icon: 'danger',
							title: 'İşlem başarısız!',
							message: 'İşlem sırasında bir hata oluştu.. Daha sonra tekrar deneyiniz.',
							buttonType: 'ok'
						});
					});
				}
			});
		}
	};

	var required = function (value) {
		return (value === '' || value === null || value === 'undefined');
	};

	var validEmail = function (value) {
		if (required(value))
			return false;

		let pattern = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
		return !(pattern.test(value));
	};

	var isNumeric = function (value) {
		let pattern = /\d+/i
		return !(pattern.test(value));
	};

	var isAlpha = function (value) {
		let pattern = /[a-zA-Z]+/i;
		return !(pattern.test(value));
	};

	var isAlphaNumeric = function (value) {
		let pattern = /[a-zA-Z0-9]+/i;
		return !(pattern.test(value));
	};

	var callRule = function (rule, value) {
		switch (rule) {
			case 'required':
				return required(value);
			case 'valid-email':
				return validEmail(value);
			case 'is-numeric':
				return isNumeric(value);
			case 'is-alpha':
				return isAlpha(value);
			case 'is-aplhanumeric':
				return isAlphaNumeric(value);
			default:
				return false;
		}
	}

	return {
		init: function (settings) {
			handler(settings);
		},

		isEmail: function (email) {
			return validEmail(email);
		},

		isRequired: function (val) {
			return required(val);
		}
	}
}();

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = FormValidation;
}