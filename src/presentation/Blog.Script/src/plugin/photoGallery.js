"use strict";

const Ajax = require("../lib/ajax");

var PhotoGallery = function (options) {
	let the = this;
	var element;

	const imageLayout = '<div class="attachment">\
							<div class="thumbnail">\
								<div class="centered">\
									<img src="'+ Util.urlHelper('Uploads/')+'/{imgUrl}" />\
								</div>\
							</div>\
							<button type="button" class="check" value="{id}">\
								<i class="cdi cdi-yes"></i>\
							</button>\
						</div>';

	const fileLayout = '<div class="attachment">\
							<div class="thumbnail">\
								<div class="centered">\
									<img src="'+ Util.urlHelper('images/file.png')+'" />\
								</div>\
								<div class="filename">{fileName}</div>\
							</div>\
							<button type="button" class="check">\
								<i class="cdi cdi-yes"></i>\
							</button>\
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

					let galleryItem = document.createElement('div');
					galleryItem.classList.add('gallery-item');
					galleryItem.dataset.id = message.data[i].id;

					if (message.data[i].mimeType == 'application/pdf' || message.data[i].mimeType == 'audio/mpeg') {
						galleryItem.innerHTML = fileLayout.replace('{fileName}', message.data[i].originalName);
					} else {
						galleryItem.innerHTML = imageLayout.replace('{imgUrl}', message.data[i].uploadDir + '/' + message.data[i].name);
					}

					galleryItem.addEventListener('click', Plugin.galleryItemEvent);
					element.appendChild(galleryItem);
				}
			}).catch((message) => {
				console.log(message);
				throw new Error('Veriler alınamadı.');
			});
		},

		galleryItemEvent: function (e) {
			e.stopPropagation();
			let currentItem = e.currentTarget;

			console.log(currentItem.dataset.id);
		}
	}

	Plugin.construct.apply(the, [options]);

	return the;
};

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = PhotoGallery;
}