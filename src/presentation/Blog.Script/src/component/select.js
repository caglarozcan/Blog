"use strict";

var Select = function () {
	return {
		init: function (selector) {
			console.log(selector);
		}
	};
}();

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = Select;
}