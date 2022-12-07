


ConfirmValidation = function (msg) {
    $.confirm({
        icon: 'fas fa-bell',
        title: 'Mensaje de Validación',
        content: msg,
        type: 'red',
        typeAnimated: true,
        autoClose: 'tryAgain|9000',
        buttons: {
            tryAgain: {
                text: 'Aceptar',
                btnClass: 'btn-red',
                keys: ['enter'],
                action: function () {
                }
            }
        }
    });
};

ConfirmYesOrNo = function (msg, param, functionsi, functionno) {
    $.confirm({
        icon: 'fas fa-question',
        title: 'Confirmación',
        content: msg,
        type: 'red',
        typeAnimated: true,
        buttons: {
            tryAgain: {
                text: 'Si',
                btnClass: 'btn-blue',
                keys: ['enter'],
                action: function () {
                    try { functionsi(param); } catch{ /* ---- */ }
                }
            },
            Cancel: {
                text: 'No',
                btnClass: 'btn-red',
                action: function () {
                    try { functionno(param); } catch{ /* ---- */ }
                }
            }
        }
    });
};

ConfirmSystem = function (msg, param, functionmessage) {
    $.confirm({
        icon: 'fas fa-bell',
        title: 'Mensaje del Sistema',
        content: msg,
        type: 'orange',
        typeAnimated: true,
        autoClose: 'tryAgain|9000',
        buttons: {
            tryAgain: {
                text: 'Aceptar',
                btnClass: 'btn-orange', keys: ['enter'],
                action: function () {
                    try { functionmessage(param); } catch { /* ---- */ }
                }
            }
        }
    });
};

ConfirmSystemTimer = function (msg, param, functionmessage, time) {
    $.confirm({
        icon: 'fas fa-bell',
        title: 'Mensaje del Sistema',
        content: msg,
        type: 'orange',
        typeAnimated: true,
        autoClose: 'tryAgain|' + time,
        buttons: {
            tryAgain: {
                text: 'Aceptar',
                btnClass: 'btn-orange', keys: ['enter'],
                action: function () {
                    try { functionmessage(param); } catch { /* ---- */ }
                }
            }
        }
    });
};

ConfirmError = function (msg, param, functionerror) {
    $.confirm({
        icon: 'fas fa-exclamation-triangle',
        title: 'Mensaje del Sistema',
        content: msg,
        type: 'red',
        typeAnimated: true,
        autoClose: 'tryAgain|9000',
        buttons: {
            tryAgain: {
                text: 'Aceptar',
                btnClass: 'btn-red',
                keys: ['enter'],
                action: function () {
                    try { functionerror(param); } catch { /* ---- */ }
                }
            }
        }
    });
};

ConfirmSuccess = function (msg, param, functionsuccess) {
    $.confirm({
        icon: 'fas fa-check',
        title: 'Mensaje del Sistema',
        content: msg,
        type: 'green',
        typeAnimated: true,
        autoClose: 'tryAgain|9000',
        buttons: {
            tryAgain: {
                text: 'Aceptar',
                btnClass: 'btn-green',
                keys: ['enter'],
                action: function () {
                    try { functionsuccess(param); } catch { /* ---- */ }
                }
            }
        }
    });
};

ConfirmNotify = function (msg) {
    $.confirm({
        icon: 'fas fa-envelope',
        title: 'Notificación',
        content: msg,
        type: 'green',
        typeAnimated: true,
        autoClose: 'tryAgain|9000',
        buttons: {
            tryAgain: {
                text: 'Aceptar',
                btnClass: 'btn-green',
                keys: ['enter'],
                action: function () {
                }
            }
        }
    });
};


$.fn.extractObject = function () {
    var accum = {};
    function add(accum, namev, value) {
        if (namev.length == 1)
            accum[namev[0]] = value;
        else {
            if (accum[namev[0]] == null)
                accum[namev[0]] = {};
            add(accum[namev[0]], namev.slice(1), value);
        }
    };
    this.find('input, textarea, select').each(function () {
        if (typeof $(this).attr('name') !== "undefined") {
            add(accum, $(this).attr('name').split('.'), $(this).val());
        }
    });
    return accum;
};






