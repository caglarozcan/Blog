"use strict";

var Ticket = function () {

	var handle = function (settings) {
		console.log('tivkets');
	}

	return {
		init: function (setting) {
			handle(setting);
		}
	}
}();

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = Ticket;
}