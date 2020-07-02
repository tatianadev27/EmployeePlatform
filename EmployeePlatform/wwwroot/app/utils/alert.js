function notifyResult(message, type) {
    if (message != "" && type != "") {
        alertify.set('notifier', 'position', 'top-right');
        if (type == "Ok") {
            alertify.success(message);
        } else {
            alertify.error(message);
        }
    }
}