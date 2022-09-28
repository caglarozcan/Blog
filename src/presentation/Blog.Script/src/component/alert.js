"use strict";

var AlertComponent = function () {

	const ALERT_OPEN_BUTTON = '[data-alert]';
	const ALERT_SELECTOR = '.alert';
	const ALERT_CLOSE = '[data-close]';

	var initComponent = function (element) {
		var targetAlert = Util.getAttribute(element, 'data-alert');

		var alert = Util.find(targetAlert);

		if (Util.isElement(alert)) {
			var closeButton = Util.find(ALERT_CLOSE, alert);
			closeButton.addEventListener('click', (e) => {
				alert.classList.remove('show');
			});
		}
	}

	return {
		init: function () {
			Util.findAll(ALERT_OPEN_BUTTON).forEach(function (el) {
				initComponent(el);
			});
		},

		open: function (selector) {
			var element;

			if (typeof selector == 'string') {
				element = Util.find(selector);
			} else {
				element = selector;
			}

			if (Util.isElement(element)) {
				element.classList.add('show');
			}
		}
	};
}();

Util.onDOMContentLoaded(function () {
	AlertComponent.init();
});

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = AlertComponent;
}