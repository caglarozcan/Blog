"use strict";

const Ajax = require("../lib/ajax");

var PhotoGallery = function (options) {
	let the = this;
	var element;

	const imageLayout = '<div class="gallery-item">\
							<div class="attachment">\
								<div class="thumbnail">\
									<div class="centered">\
										<img src="'+ Util.urlHelper('Uploads/')+'{imgUrl}" />\
									</div>\
								</div>\
								<button type="button" class="check" value="{id}">\
									<i class="cdi cdi-yes"></i>\
								</button>\
							</div>\
						</div>';

	const fileLayout = '<div class="gallery-item">\
							<div class="attachment">\
								<div class="thumbnail">\
									<div class="centered">\
										<img src="'+ Util.urlHelper('images/file.png')+'" />\
									</div>\
									<div class="filename">{fileName}</div>\
								</div>\
								<button type="button" class="check">\
									<i class="cdi cdi-yes"></i>\
								</button>\
							</div>\
						</div>';

	var Plugin = {
		construct: function (options) {
			if (!options.hasOwnProperty('selector')) {
				throw new Error('Galeri seçici bulunamadı.');
			}

			element = Util.find(options.selector);
			
			if (element) {
				the.options = options;
				Plugin.init();
			} else {
				throw new Error('Galeri elementi bulunamadı.');
			}

			return the;
		},

		init: function () {
			Ajax.send({
				method: 'GET',
				url: Util.urlHelper('Admin/Media/GetMediaList'),
				data: { Page: 1, PerData: 34 }
			}).then((message) => {
				for (var i = 0; i < message.data.length; i++) {
					if (message.data[i].mimeType == 'application/pdf' || message.data[i].mimeType == 'audio/mpeg') {
						element.insertAdjacentHTML('beforeend', fileLayout.replace('{fileName}', message.data[i].originalName));
					} else {
						element.insertAdjacentHTML('beforeend', imageLayout.replace('{imgUrl}', message.data[i].uploadDir + '/' + message.data[i].name));
					}
				}
			}).catch((message) => {
				throw new Error('Veriler alınamadı.');
			});
		}
	}

	Plugin.construct.apply(the, [options]);

	return the;
};

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = PhotoGallery;
}