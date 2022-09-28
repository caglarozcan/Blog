"use strict";

var ModalComponent = function () {
	const DATA_OPEN = '[data-modal]';
	const DATA_CLOSE = '[data-dismiss="modal"]';
	const DATA_CLOSE_FOOTER = '[data-close="modal"]';
	let MODAL;

	return {
		init: function () {
			Util.findAll(DATA_OPEN).forEach((el) => {
				let targetModal = Util.getDataAttribute(el, 'data-modal');
				let modal = Util.find(targetModal);
				if (Util.isElement(modal)) {
					const closeBtn = Util.find(DATA_CLOSE, modal);
					if (Util.isElement(closeBtn)) {
						closeBtn.addEventListener('click', (e) => {
							modal.classList.remove('show-modal');
						});
					}

					const closeFooterBtn = Util.find(DATA_CLOSE_FOOTER, modal);
					if (Util.isElement(closeFooterBtn)) {
						closeFooterBtn.addEventListener('click', (e) => {
							modal.classList.remove('show-modal');
						});
					}

					el.addEventListener('click', (e) => {
						modal.classList.add('show-modal');
					})
				}
			});
		},

		setModal: function (option) {
			var settings = {};

			if (typeof option === 'string') {
				settings.selector = option;
			} else if (typeof option === 'object') {
				settings = option;
			}

			MODAL = Util.find(option.selector);

			if (Util.isElement(MODAL)) {
				const openBtn = Util.find('[data-modal="#' + option.selector + '"]');
				if (Util.isElement(openBtn)) {
					openBtn.addEventListener('click', (e) => {
						this.open();
					});
				}

				const closeFooterBtn = Util.find(DATA_CLOSE_FOOTER, MODAL);
				if (Util.isElement(closeFooterBtn)) {
					closeFooterBtn.addEventListener('click', (e) => {
						this.close();
					});
				}

				const closeBtn = Util.find(DATA_CLOSE, MODAL);
				if (Util.isElement(closeBtn)) {
					closeBtn.addEventListener('click', (e) => {
						this.close();
					});
				}
			} else {
				//error : modal bir element değil.
			}
		},

		open: function () {
			MODAL.classList.add("show-modal");
		},

		close: function () {
			MODAL.classList.remove("show-modal");
		},

		show: function (selector) {
			const modal = Util.find(selector);
			modal.classList.add('show-modal');
		},

		hide: function (selector) {
			const modal = Util.find(selector);
			modal.classList.remove('show-modal');
		}
	};
}();

Util.onDOMContentLoaded(function () {
	ModalComponent.init();
});

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = ModalComponent;
}