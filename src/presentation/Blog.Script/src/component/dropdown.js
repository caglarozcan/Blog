"use strict";

var DropDownComponent = function () {
	const DROPDOWN = '.dropdown';
	const DROPDOWN_BUTTON = '[data-dropdown]';
	const DROPDOWN_MENU_CONTAINER = '.drop-down';

	var initComponent = function (element) {
		var ddButton = Util.find(DROPDOWN_BUTTON, element);

		ddButton.addEventListener('click', (e) => {
			e.stopPropagation();

			var currentTarget = Util.getAttribute(e.currentTarget, 'data-dropdown');

			Util.findAll(DROPDOWN_MENU_CONTAINER + ':not(' + currentTarget + ')').forEach(function (ddowns) {
				ddowns.classList.remove('show');
			});

			var ddMenu = Util.find(currentTarget, element)

			if (ddMenu.matches('.show')) {
				ddMenu.classList.remove('show');
			} else {
				ddMenu.classList.add('show');
			}
		});
	}

	return {
		init: function () {
			Util.findAll(DROPDOWN).forEach(function (el) {
				initComponent(el);
			});
		}
	};
}();

Util.onDOMContentLoaded(function () {
	DropDownComponent.init();
	
	window.onclick = function (event) {
		if (!event.target.matches("[data-dropdown]")) {
			var dropdowns = document.getElementsByClassName("drop-down");
			var i;
			for (i = 0; i < dropdowns.length; i++) {
				var openDropdown = dropdowns[i];
				if (openDropdown.classList.contains("show")) {
					openDropdown.classList.remove("show");
				}
			}
		}
	};
});

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = DropDownComponent;
}