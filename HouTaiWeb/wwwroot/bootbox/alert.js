var user = user || {}; user.alert = user.alert || {};
user.autoAlert = user.autoAlert || {};

user.alert = function (msg) {

    var dialog = bootbox.dialog({
        message: '<p class="text-center">' + msg + '</p>',
        closeButton: false
    });

    //autoClose = autoClose || true;
    if (b) {
        setTimeout(function () {
            dialog.modal('hide');
        }, 2000);
    }
}
//自动关闭
user.autoAlert = function (msg) {

    var dialog = bootbox.dialog({
        message: '<p class="text-center">' + msg + '</p>',
        closeButton: false
    });
    setTimeout(function () {
        dialog.modal('hide');
    }, 2000);
}



$(document).click(function () {
    bootbox.hideAll();
});