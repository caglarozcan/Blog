"use strict";

const Util = require("../util/util");

var PasswordMeter = function () {

	var handleMeter = function (element) {
		var inputName = Util.getDataAttribute(element, 'data-pm-bind');
		var input = Util.find('input[name="' + inputName + '"]');

		if (Util.isElement(input)) {
			input.addEventListener('keyup', (e) => {
				passwordTester(e.target.value);
			});
		} else {
			throw '?ifre alan? bulunamad?. Seçiciyi kontrol ediniz.';
		}
	};

	var passwordTester = function (text) {

	};

	return {
		init: function () {
			Util.findAll('[data-pm="true"]').forEach(function (element) {
				handleMeter(element);
			});
		}
	}
}();

Util.onDOMContentLoaded(function () {
	PasswordMeter.init();
});

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = PasswordMeter;
}