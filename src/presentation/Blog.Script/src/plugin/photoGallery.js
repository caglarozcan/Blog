"use strict";

var PhotoGallery = function (options) {
	var the = this;
	var element;

	var Plugin = {
		construct: function (options) {
			if (!options.hasOwnProperty('selector')) {
				throw new Error('Galeri seçici bulunamad?.');
			}

			element = Util.find(options.selector);

			if (element) {
				the.options = options;
				Plugin.init();
				Plugin.build();
			} else {
				throw new Error('Galeri elementi bulunamad?.');
			}
			

			return the;
		},

		init: function () {
			console.log('Galeri init CALL.');
		},

		build: function () {
			console.log('Galeri build CALL');
		},
	}

	Plugin.construct.apply(the, [options]);

	return the;
};

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = PhotoGallery;
}