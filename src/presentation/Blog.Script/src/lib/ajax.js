"use strict";

var Ajax = function () {

	var serialize = function (data) {
		return Object.keys(data).map((key) => {
			return encodeURIComponent(key) + '=' + encodeURIComponent(data[key])
		}).join('&');
	}

	return {
		send: function (options) {
			let settings = options || {};
			let dataTemp;

			if (!settings.hasOwnProperty('method')) {
				settings.method = 'POST';
			}

			if (!settings.hasOwnProperty('data')) {
				settings.data = {};
			}

			if (!settings.hasOwnProperty('contentType')) {
				settings.contentType = 'application/x-www-form-urlencoded; charset=UTF-8';
			}

			const promise = new Promise(function (resolve, reject) {
				const xhrRequest = new XMLHttpRequest();
				xhrRequest.responseType = 'json';
				xhrRequest.open(settings.method, settings.url);
				xhrRequest.setRequestHeader('Content-type', settings.contentType);

				if (settings.data != {}) {
					if (settings.contentType === 'application/json; charset=UTF-8') {
						dataTemp = JSON.stringify(settings.data);
					} else {
						dataTemp = serialize(settings.data);
					}
				}

				xhrRequest.onload = function () {
					if (xhrRequest.status < 200 || xhrRequest.status > 299) {
						resolve(xhrRequest.response);
					} else {
						resolve(xhrRequest.response);
					}
				}

				xhrRequest.onerror = function () {
					reject(xhrRequest.response);
				}

				xhrRequest.send(dataTemp);
			});

			return promise;
		}
	}
}();

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = Ajax;
}