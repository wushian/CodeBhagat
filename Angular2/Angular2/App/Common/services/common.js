'use strict';

var serviceId = 'common';
app.factory(serviceId, [common]);


function common(ngToast) {
    return {
        isValid: isValid,
    };

    function isValid(val) {

        return val != undefined && val != "" && val != null;
    }
}
