(()=>{"use strict";var t={893:t=>{var i=function(){const t='[data-dismiss="modal"]',i='[data-close="modal"]';let e;return{init:function(){Util.findAll("[data-modal]").forEach((e=>{let s=Util.getDataAttribute(e,"data-modal"),n=Util.find(s);if(Util.isElement(n)){const s=Util.find(t,n);Util.isElement(s)&&s.addEventListener("click",(t=>{n.classList.remove("show-modal")}));const o=Util.find(i,n);Util.isElement(o)&&o.addEventListener("click",(t=>{n.classList.remove("show-modal")})),e.addEventListener("click",(t=>{n.classList.add("show-modal")}))}}))},setModal:function(s){var n={};if("string"==typeof s?n.selector=s:"object"==typeof s&&(n=s),e=Util.find(s.selector),Util.isElement(e)){const n=Util.find('[data-modal="#'+s.selector+'"]');Util.isElement(n)&&n.addEventListener("click",(t=>{this.open()}));const o=Util.find(i,e);Util.isElement(o)&&o.addEventListener("click",(t=>{this.close()}));const l=Util.find(t,e);Util.isElement(l)&&l.addEventListener("click",(t=>{this.close()}))}},open:function(){e.classList.add("show-modal")},close:function(){e.classList.remove("show-modal")},show:function(t){Util.find(t).classList.add("show-modal")},hide:function(t){Util.find(t).classList.remove("show-modal")}}}();Util.onDOMContentLoaded((function(){i.init()})),void 0!==t.exports&&(t.exports=i)}},i={};!function e(s){var n=i[s];if(void 0!==n)return n.exports;var o=i[s]={exports:{}};return t[s](o,o.exports,e),o.exports}(893)})();