"use strict";

var TabComponent = function () {
	const TAB_CONTAINER = '[data-tab="tab"]';
	const TAB_MENU = '.tab-menu-fixed';
	const TAB_MENU_ITEM_CONTAINER = '.tab-menu-item';
	const TAB_MENU_ITEM = '[data-tab-target]';
	const TAB_CONTENT = '.tab-content'
	const TAB_CONTENT_BODY = '.tab-item';

	var initComponent = function (element) {
		var tabMenu = Util.find(TAB_MENU, element); //tab menu container in tab container
		var tabMenuItems = Util.findAll(TAB_MENU_ITEM_CONTAINER, tabMenu); //ta menu items in tab menu container
		var tabContent = Util.find(TAB_CONTENT, element); //tab body container in tab container
		var tabBodies = Util.findAll(TAB_CONTENT_BODY, tabContent); // tab body containers in tab body container

		tabMenuItems.forEach(function (el) {
			var menuButton = Util.find(TAB_MENU_ITEM, el);

			menuButton.addEventListener('click', (e) => {
				e.stopPropagation();

				var tabTarget = Util.getDataAttribute(e.currentTarget, 'data-tab-target');
				
				tabMenuItems.forEach(function (tm) {
					tm.classList.remove('active');
				});
				
				tabBodies.forEach(function (tb) {
					tb.classList.remove('show');
				});

				el.classList.add('active');

				var currenctTab = Util.find(tabTarget, tabContent);
				currenctTab.classList.add('show');
			});
		});
	}

	return {
		init: function () {
			Util.findAll(TAB_CONTAINER).forEach(function (el) {
				initComponent(el);
			});
		}
	};
}();

Util.onDOMContentLoaded(function () {
	TabComponent.init();
});

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = TabComponent;
}