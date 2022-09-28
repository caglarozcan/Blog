"use strict";

var DialogComponent = function () {

	const iconWarning = '<div class="dialog-icon dialog-warning dialog-icon-show" style="display: flex;"><div class="dialog-icon-content">!</div></div>';
	const iconSuccess = '<div class="dialog-icon dialog-success dialog-icon-show" style="display: flex;"><div class="dialog-success-circular-line-left" style="background-color: rgb(255, 255, 255);"></div><span class="dialog-success-line-tip"></span><span class="dialog-success-line-long"></span><div class="dialog-success-ring"></div><div class="dialog-success-fix" style="background-color: rgb(255, 255, 255);"></div><div class="dialog-success-circular-line-right" style="background-color: rgb(255, 255, 255);"></div></div>';
	const iconDanger = '<div class="dialog-icon dialog-error dialog-icon-show" style="display: flex;"><span class="dialog-x-mark"><span class="dialog-x-mark-line-left"></span><span class="dialog-x-mark-line-right"></span></span></div>';
	const iconInfo = '<div class="dialog-icon dialog-info dialog-icon-show" style="display: flex;"><div class="dialog-icon-content">i</div></div>';
	const iconQuestion = '<div class="dialog-icon dialog-question dialog-icon-show" style="display: flex;"><div class="dialog-icon-content">?</div></div>';

	var handle = function (setting) {
		var dialogHtml = document.createElement('div');
		dialogHtml.classList.add('dialog');
		dialogHtml.classList.add('dialog-open');

		var dialogWrapper = document.createElement('div');
		dialogWrapper.classList.add('dialog-wrapper');

		var dialogContent = document.createElement('div');
		dialogContent.classList.add('dialog-content');
		dialogContent.classList.add('dialog-open-animation');

		var closeAction = function () {
			dialogContent.classList.remove('dialog-open-animation');
			dialogContent.classList.add('dialog-close-animation');

			setTimeout(function () {
				dialogHtml.remove();
			}, 300);
		};

		if (typeof setting.icon !== 'undefined') {
			dialogContent.appendChild(getIcon(setting.icon));
		}

		var dialogBody = document.createElement('div');
		dialogBody.classList.add('dialog-body');

		if (typeof setting.title !== 'undefined') {
			dialogBody.appendChild(getTitle(setting.title));
		}

		if (typeof setting.message !== 'undefined') {
			dialogBody.appendChild(getMessage(setting.message));
		}

		var yesAction = () => { };
		if (typeof setting.ajax !== 'undefined') {
			yesAction = function (e) {
				e.currentTarget.innerHTML = 'Gönderiliyor... <div class="loader"></div>';
				Ajax.send(setting.ajax).then((message) => {
					dialogContent.innerHTML = '';
					dialogContent.appendChild(getIcon(message.success ? 'success' : 'danger'));

					var dlgBody = document.createElement('div');
					dlgBody.classList.add('dialog-body');
					dialogContent.appendChild(dlgBody);
					
					dlgBody.appendChild(getTitle(message.success ? 'İşlem başarılı..' : 'İşlem başarısız!'));
					dlgBody.appendChild(getMessage(message.message));

					var dlgButton = document.createElement('div');
					dlgButton.classList.add('dialog-button');
					dlgButton.appendChild(getButton('Kapat', 'yes', closeAction));
					dlgBody.appendChild(dlgButton);

					if (setting.hasOwnProperty('ajaxAfter')) {
						if (typeof setting.ajaxAfter === 'function') {
							setting.ajaxAfter();
						}
					}
				}).catch((message) => {;
					dialogContent.innerHTML = '';
					dialogContent.appendChild(getIcon('danger'));

					var dlgBody = document.createElement('div');
					dlgBody.classList.add('dialog-body');
					dialogContent.appendChild(dlgBody);
					
					dlgBody.appendChild(getTitle('İşlem Başarısız!'));
					dlgBody.appendChild(getMessage('İşlem sırasında bir hata oluştu, daha sonra tekrar deneyiniz.'));

					var dlgButton = document.createElement('div');
					dlgButton.classList.add('dialog-button');
					dlgButton.appendChild(getButton('Kapat', 'yes', closeAction));
					dlgBody.appendChild(dlgButton);
				});
			}
		}

		var dialogButton = document.createElement('div');
		dialogButton.classList.add('dialog-button');

		if (typeof setting.buttonType !== 'undefined') {
			if (setting.buttonType == 'ok') {
				dialogButton.appendChild(getButton('Tamam', 'yes', setting.callback ? setting.callback : closeAction));
			} else if (setting.buttonType === 'yesNo'){
				dialogButton.appendChild(getButton('Evet', 'yes', yesAction));
				dialogButton.appendChild(getButton('Hayır', 'no', closeAction));
			} else if (setting.buttonType === 'okCancel') {
				dialogButton.appendChild(getButton('Tamam', 'ok', yesAction));
				dialogButton.appendChild(getButton('İptal', 'cancel', closeAction));
			}
		}

		dialogBody.appendChild(dialogButton);
		dialogContent.appendChild(dialogBody);
		dialogWrapper.appendChild(dialogContent);
		dialogHtml.appendChild(dialogWrapper);
		document.body.appendChild(dialogHtml);
	}

	var getButton = function (btnText, btnType, callback) {
		var button = document.createElement('button');
		button.classList.add('btn');
		button.classList.add('btn-md');

		if (btnType === 'yes' || btnType == 'ok') {
			button.classList.add('btn-primary');
		} else {
			button.classList.add('btn-default');
		}

		button.innerText = btnText;
		button.addEventListener('click', callback);
		return button;
	};

	var getIcon = function (iconYype) {
		var dialogIconWrapper = document.createElement('div');
		dialogIconWrapper.classList.add('dialog-icon-container');

		switch (iconYype) {
			case 'success':
				dialogIconWrapper.innerHTML = iconSuccess;
				break;
			case 'danger':
				dialogIconWrapper.innerHTML = iconDanger;
				break;
			case 'warning':
				dialogIconWrapper.innerHTML = iconWarning;
				break;
			case 'info':
				dialogIconWrapper.innerHTML = iconInfo;
				break;
			case 'question':
				dialogIconWrapper.innerHTML = iconQuestion;
				break;
			default:
				dialogIconWrapper.innerHTML = '';
				break;
		}

		return dialogIconWrapper;
	}

	var getTitle = function (title) {
		var dialogTitle = document.createElement('div');
		dialogTitle.classList.add('title-text');
		dialogTitle.innerText = title;
		return dialogTitle;
	}

	var getMessage = function (message) {
		var dialogMessage = document.createElement('div');
		dialogMessage.classList.add('message-text');
		dialogMessage.innerHTML = message;
		return dialogMessage;
	}

	return {
		init: function (setting) {
			handle(setting);
		}
	}
}();

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	module.exports = DialogComponent;
}