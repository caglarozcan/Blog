(function (root, factory) {
	var plugin = "DataTable";

	if (typeof exports === "object") {
		module.exports = factory(plugin);
	} else if (typeof define === "function" && define.amd) {
		define([], factory(plugin));
	} else {
		root[plugin] = factory(plugin);
	}
})(typeof global !== "undefined" ? global : this.window || this.global, function (plugin) {
	"use strict";

	var isObject = function (val) {
		return Object.prototype.toString.call(val) === "[object Object]";
	};

	var find = function (selector, element = document.documentElement) {
		return Element.prototype.querySelector.call(element, selector);
	}

	var findAll = function (selector, element = document.documentElement) {
		return [].concat(
			...Element.prototype.querySelectorAll.call(element, selector)
		);
	}

	var each = function (arr, fn, scope) {
		var n;
		if (isObject(arr)) {
			for (n in arr) {
				if (Object.prototype.hasOwnProperty.call(arr, n)) {
					fn.call(scope, arr[n], n);
				}
			}
		} else {
			for (n = 0; n < arr.length; n++) {
				fn.call(scope, arr[n], n);
			}
		}
	};

	var on = function (element, event, callback) {
		if (element) {
			element.addEventListener(event, callback, false);
		}
	};

	var makeRequest = function (opts) {
		return new Promise(function (resolve, reject) {
			var params = opts.params;
			if (params && typeof params === 'object') {
				params = Object.keys(params).map(function (key) {
					return encodeURIComponent(key) + '=' + encodeURIComponent(params[key]);
				}).join('&');
			}

			var xhr = new XMLHttpRequest();
			xhr.open(opts.method, opts.url + '?' + params);
			xhr.onload = function () {
				if (xhr.status >= 200 && xhr.status < 300) {
					resolve(xhr.responseText);
				} else {
					reject({
						status: xhr.status,
						statusText: xhr.statusText
					});
				}
			};
			xhr.onerror = function () {
				reject({
					status: xhr.status,
					statusText: xhr.statusText
				});
			};
			xhr.send(null);
		});
	};

	var objProt = Object.prototype;

	objProt.getByIndex = function (index) {
		if (index !== 'undefined') {
			if (this) {
				return this[Object.keys(this)[index]];
			}
		}
	};

	var DataTable = function (selector, options) {
		this.table = find(selector);
		this.options = options;

		this.init();
	}

	var dtProto = DataTable.prototype;

	dtProto.init = function () {
		var dt = this;

		dt.thead = dt.table.tHead;
		dt.tbody = dt.table.tBodies[0];

		dt.rect = dt.table.getBoundingClientRect();

		if (dt.options.hasOwnProperty('order')) {
			dt.sortedIndex = dt.options.order[0];
			dt.sortType = dt.options.order[1];
		} else {
			dt.sortedIndex = -1;
			dt.sortType = 0;
		}

		dt.SearchValue = '';

		dt.currentPage = 1;
		dt.totalData = 0;
		dt.dataPerPage = dt.options.hasOwnProperty('dataPerPage') ? dt.options.dataPerPage : 15;

		dt.render();
	}

	dtProto.formatDate = function (dateText, fromat) {
		var months = ['Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran', 'Temmuz', 'Ağustos', 'Eylül', 'Ekim', 'Kasım', 'Aralık'];
		var regexp = /([0-9]{4})-([0-9]{2})-([0-9]{2})T([0-9]{2}):([0-9]{2})/g;
		var dateParts = [...dateText.matchAll(regexp)];
		return dateParts[0][3] + ' ' + months[(parseInt(dateParts[0][2]) - 1)] + ' ' + dateParts[0][1] + ' ' + dateParts[0][4] + ':' + dateParts[0][5];
	}

	dtProto.render = function () {
		this.renderHead();
		this.renderBody();
		this.filter();
	}

	dtProto.filter = function () {
		var dt = this;
		if (dt.options.hasOwnProperty('filter')) {
			var filterInput = document.querySelector(dt.options.filter.element);
			on(filterInput, 'keydown', function (e) {
				e.stopPropagation();

				if (e.keyCode == 13) {
					dt.SearchValue = filterInput.value;
					dt.currentPage = 1;
					dt.renderBody();
				}
			});

			on(filterInput, 'keyup', function (e) {
				e.stopPropagation();

				if (this.value.length == 0) {
					dt.SearchValue = filterInput.value;
					dt.currentPage = 1;
					dt.renderBody();
				}
			});
		}
	}

	dtProto.renderHead = function () {
		var dt = this;
		var headingOptions = dt.options.columns;

		var heads = findAll('th', dt.thead);

		dt.headSize = heads.length;

		each(heads, function (thead, index) {
			var text = thead.innerText;

			var span = document.createElement('span');
			span.innerText = text;

			thead.innerHTML = '';
			thead.appendChild(span);

			if (headingOptions[index].hasOwnProperty('width')) {
				thead.style.width = headingOptions[index].width;
			}

			if (headingOptions[index].hasOwnProperty('aling')) {
				if (headingOptions[index].aling === 'left' || headingOptions[index].aling === 'right' || headingOptions[index].aling === 'center' || headingOptions[index].aling === 'justify') {
					thead.style.textAlign = headingOptions[index].aling;
				} else {
					throw 'Geçersiz hizalama değeri.';
				}
			}

			if (headingOptions[index].order) {
				thead.classList.add('sortable');
				thead.dataset.sortindex = headingOptions[index].targets;
				on(thead, 'click', function (e) {
					e.stopPropagation();
					var thead = e.currentTarget;
					var sortIndex = thead.dataset.sortindex;

					if (sortIndex == dt.sortedIndex) {
						var sortIcon = find('i', thead);
						sortIcon.classList.add('cdi');
						dt.sortType = (dt.sortType === 0 ? 1 : 0);

						if (dt.sortType === 1) {
							sortIcon.classList.remove('cdi-arrow-up');
							sortIcon.classList.add('cdi-arrow-down');
						} else {
							sortIcon.classList.remove('cdi-arrow-down');
							sortIcon.classList.add('cdi-arrow-up');
						}
					} else {
						var sortIcons = findAll('i', dt.thead);
						each(sortIcons, function (icon) {
							icon.remove();
						});

						var sortIcon = document.createElement('i');
						sortIcon.classList.add('cdi');
						sortIcon.classList.add('cdi-arrow-down');

						thead.appendChild(sortIcon);

						dt.sortedIndex = sortIndex;
						dt.sortType = 0;
					}

					dt.renderBody();
				});
			}
		});

		if (dt.options.fixColumn) {
			each(heads, function (cell, i) {
				var ow = cell.offsetWidth;
				var w = ow / dt.rect.width * 100;
				cell.style.width = w + "%";
			}, this);
		}
	}

	dtProto.renderBody = function () {
		var dt = this;
		dt.tbody.innerHTML = '';

		var params = {
			page: dt.currentPage,
			sortType: dt.sortType,
			sortIndex: dt.sortedIndex,
			searchValue: dt.SearchValue,
			perData: dt.dataPerPage
		};

		dt.loading();

		makeRequest({
			method: dt.options.method,
			url: dt.options.url,
			params: params
		}).then(function (data) {
			var jsonData = JSON.parse(data);
			//console.log(jsonData);
			dt.totalData = jsonData.totalRow;

			var loader = find('tr.loading', dt.tbody);
			loader.remove();

			if (jsonData.data) {
				dt.loadRows(jsonData.data);

				if (jsonData.data.length > 0) {
					dt.paging();
				}
			}

			dt.onRendered();
		}).catch(function (err) {
			console.error('Bir hata oluştu : ', err);
		});
	}

	dtProto.loadRows = function (data) {
		var dt = this, increment = 0;
		if (data) {
			if (data.length == 0) {
				var tr = document.createElement('tr');
				var td = document.createElement('td');
				td.colSpan = dt.headSize;
				td.classList.add('datatable-nodata');
				td.innerText = 'Gösterilecek herhangi bir veri yok.';
				tr.appendChild(td);
				dt.tbody.appendChild(tr);
			} else {
				increment = ((parseInt(dt.currentPage) - 1) * parseInt(dt.dataPerPage)) + 1;
				each(data, function (item, index) {
					var tr = document.createElement('tr');

					each(dt.options.columns, function (column, index) {
						var td = document.createElement('td');

						if (column.hasOwnProperty('aling')) {
							if (column.aling === 'left' || column.aling === 'right' || column.aling === 'center' || column.aling === 'justify') {
								td.style.textAlign = column.aling;
							} else {
								throw 'Geçersiz hizalama değeri.';
							}
						}

						if (column.hasOwnProperty('class')) {
							td.classList.add(column.class);
						}

						if (column.hasOwnProperty('bind')) {
							if (column.hasOwnProperty('render')) {
								if (typeof column.render === 'function') {
									td.innerHTML = column.render(item.getByIndex(column.bind));
								} else {
									throw 'Sütun için render değeri fonksiyon olmalı.';
								}
							} else {
								td.innerHTML = item.getByIndex(column.bind);
							}
						} else {
							if (column.targets !== 'AI') {
								td.innerText = item.getByIndex(column.targets);
							} else {
								td.innerText = increment++;
							}
						}

						if (column.hasOwnProperty('dateFormat')) {
							td.innerHTML = dt.formatDate(item.getByIndex(column.targets), column.dateFormat);
						}

						tr.appendChild(td);
					});

					dt.tbody.appendChild(tr);
				});
			}
		}
	}

	dtProto.paging = function (totalRow) {
		var dt = this;

		var pageSize = Math.ceil(dt.totalData / dt.dataPerPage);
		var currentPage = parseInt(dt.currentPage);

		var currentPageContainer = dt.table.nextElementSibling;
		if (currentPageContainer != null) {
			currentPageContainer.remove();
		}

		var pagerContainer = document.createElement('div');
		pagerContainer.classList.add('table-footer');

		var pageSummary = document.createElement('div');
		pageSummary.classList.add('table-info');
		pageSummary.innerText = 'Gösterilen ' + (((currentPage - 1) * dt.options.dataPerPage) == 0 ? 1 : (currentPage - 1) * dt.options.dataPerPage) + '-' + (currentPage * dt.options.dataPerPage) + '/' + dt.totalData;
		pagerContainer.appendChild(pageSummary);

		var pagerUl = document.createElement('ul');
		pagerUl.classList.add('pagination');
		var docFrag = document.createDocumentFragment();

		var firstLi = document.createElement('li');
		firstLi.classList.add('arrow');
		var firstLink = document.createElement('a');
		firstLink.classList.add('link-first');
		firstLink.href = 'javascript:void(0)';
		firstLink.innerHTML = '<i class="cdi cdi-arrow-left-alt"></i>';
		on(firstLink, 'click', function (e) {
			e.stopPropagation();
			dt.currentPage = 1;
			dt.renderBody();
		})
		firstLi.appendChild(firstLink);
		docFrag.appendChild(firstLi);

		var previousLi = document.createElement('li');
		previousLi.classList.add('arrow');
		var previousLink = document.createElement('a');
		previousLink.classList.add('link-first');
		previousLink.href = 'javascript:void(0)';
		previousLink.innerHTML = '<i class="cdi cdi-arrow-left-alt2"></i>';
		on(previousLink, 'click', function (e) {
			e.stopPropagation();
			if (currentPage > 1) {
				dt.currentPage = currentPage - 1;
				dt.renderBody();
			}
		});
		previousLi.appendChild(previousLink);
		docFrag.appendChild(previousLi);

		var loopStart = currentPage - Math.floor(5 / 2);
		var loopEnd = currentPage + Math.floor(5 / 2);

		if (loopStart < 1) {
			loopStart = 1;
			loopEnd = 5;
		}

		if (loopEnd > pageSize) {
			loopStart = pageSize - (5 - 1);
			loopEnd = pageSize;

			if (loopStart < 1) {
				loopStart = 1;
			}
		}

		for (var i = loopStart; i <= loopEnd; i++) {
			var li = document.createElement('li');

			var a = document.createElement('a');
			a.innerText = i;
			a.href = 'javascript:void(0)';
			a.dataset.page = i;

			if (i == dt.currentPage) {
				li.classList.add('active');
			} else {
				on(a, 'click', function (e) {
					e.stopPropagation();
					var currentElement = e.currentTarget;
					dt.currentPage = currentElement.dataset.page;
					dt.renderBody();
				});
			}

			li.appendChild(a);
			docFrag.appendChild(li);
		}

		var nextLi = document.createElement('li');
		nextLi.classList.add('arrow');
		var nextLink = document.createElement('a');
		nextLink.classList.add('link-first');
		nextLink.href = 'javascript:void(0)';
		nextLink.innerHTML = '<i class="cdi cdi-arrow-right-alt2"></i>';
		on(nextLink, 'click', function (e) {
			e.stopPropagation();
			if (currentPage < pageSize) {
				dt.currentPage = currentPage + 1;
				dt.renderBody();
			}
		});
		nextLi.appendChild(nextLink);
		docFrag.appendChild(nextLi);

		var lastLi = document.createElement('li');
		lastLi.classList.add('arrow');
		var lastLink = document.createElement('a');
		lastLink.classList.add('link-first');
		lastLink.href = 'javascript:void(0)';
		lastLink.innerHTML = '<i class="cdi cdi-arrow-right-alt"></i>';
		on(lastLink, 'click', function (e) {
			e.stopPropagation();
			dt.currentPage = pageSize;
			dt.renderBody();
		});
		lastLi.appendChild(lastLink);
		docFrag.appendChild(lastLi);

		pagerUl.appendChild(docFrag);
		pagerContainer.appendChild(pagerUl);
		dt.table.parentNode.appendChild(pagerContainer);
	}

	dtProto.loading = function () {
		var dt = this;
		var tr = document.createElement('tr');
		tr.classList.add('loading');
		var td = document.createElement('td');
		td.colSpan = dt.headSize;
		td.classList.add('datatable-loader');
		td.innerHTML = '<div class="datatable-loading"><div class="datatable-spinner"></div></div>';
		tr.appendChild(td);
		dt.tbody.appendChild(tr);
	}

	dtProto.onRendered = function () {
		var dt = this;

		if (dt.options.hasOwnProperty('onRendered')) {
			if (typeof dt.options.onRendered === 'function') {
				dt.options.onRendered();
			}
		}
	}

	return DataTable;
});