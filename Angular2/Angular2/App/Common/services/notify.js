'use strict';

var serviceId = 'notify';
app.factory(serviceId, ['ngToast', notify]);


function notify(ngToast) {
    return {
        showMessage: showMessage,
    };

    function showMessage(type, message) {
        ngToast.create({
            className: type,
            content: message
        });
    }
}
