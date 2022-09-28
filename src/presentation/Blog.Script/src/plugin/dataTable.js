"use strict";

var DataTable = function (options) {
    var the = this;
    var element;

    var Plugin = {
        construct: function (options) {
            if (!options.hasOwnProperty('selector')) {
                throw new Error('DataTable seçici bulunamad?.');
            }

            element = Util.findOne(options.selector);

            the.options = options;

            if (Util.data(element).has('datatable')) {
                the = Util.data(element).get(alert);
            } else {
                Plugin.init();
                Plugin.build();
                Util.data(element).set('datatable', the);
            }

            return the;
        },

        init: function () {
        },

        build: function () {

        },
    }

    Plugin.construct.apply(the, [options]);

    return the;
};

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
    module.exports = DataTable;
}