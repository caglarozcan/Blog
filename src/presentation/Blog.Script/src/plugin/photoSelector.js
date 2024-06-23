"use strict";

const Ajax = require("../lib/ajax");

var PhotoSelector = function (options) {
	let the = this;
	var element;

	const imageLayout = '<div class="attachment">\
							<div class="thumbnail">\
								<div class="centered">\
									<img src="'+ Util.urlHelper('Uploads/') + '/{imgUrl}" />\
								</div>\
							</div>\
							<button type="button" class="check" value="{id}">\
								<i class="cdi cdi-yes"></i>\
							</button>\
						</div>';

	const fileLayout = '<div class="attachment">\
							<div class="thumbnail">\
								<div class="centered">\
									<img src="'+ Util.urlHelper('images/file.png') + '" />\
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
				throw new Error('Galeri seçici bulunamad?.');
			}

			element = Util.find(options.selector);

			if (element) {
				the.options = options;
				Plugin.init();
			} else {
				throw new Error('Galeri elementi bulunamadi.');
			}

			return the;
		},

		init: function () {
			Ajax.send({
				method: 'POST',
				url: Util.urlHelper('Admin/Media/GetFilteredMediaList'),
				data: { Page: 1, PerData: the.options.perData, SearchValue: the.options.searchValue }
			}).then((message) => {
				for (var i = 0; i < message.data.length; i++) {
					let galleryItem = document.createElement('div');
					galleryItem.classList.add('gallery-item');
					galleryItem.dataset.id = message.data[i].id;
					galleryItem.dataset.orname = message.data[i].originalName;
					galleryItem.dataset.path = Util.urlHelper('Uploads') + '/' + message.data[i].uploadDir + '/' + message.data[i].name;

					if (message.data[i].mimeType.includes('image')) {
						galleryItem.innerHTML = imageLayout.replace('{imgUrl}', message.data[i].uploadDir + '/' + message.data[i].name);
					} else {
						galleryItem.innerHTML = fileLayout.replace('{fileName}', message.data[i].originalName);
					}

					galleryItem.addEventListener('click', Plugin.galleryItemEvent);
					element.appendChild(galleryItem);
				}
			}).catch((message) => {
				throw new Error('Veriler alinamadi.');
			});
		},

		galleryItemEvent: function (e) {
			e.stopPropagation();
			let currentItem = e.currentTarget;

			for (var child of element.children) {
				child.classList.remove('selected-item');
			}
	
			currentItem.classList.add('selected-item');

			if (the.options.hasOwnProperty('eh')) {
				the.options.eh(currentItem.dataset.id, currentItem.dataset.path, currentItem.dataset.orname);
			}
		}
	}

	Plugin.construct.apply(the, [options]);

	return the;
};

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = PhotoSelector;
}