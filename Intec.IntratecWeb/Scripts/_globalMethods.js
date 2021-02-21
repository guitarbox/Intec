function _peticionAjax(urlServicio, verb, parametros, async, onContinue) {    
    debugger;
    var rta = "";

    if (async !== null && async !== undefined && async) {

        $.blockUI({
            message: ''
        });
        debugger;
        $.ajax({
            type: verb,
            url: urlServicio,
            async: true,
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            crossDomain: true,
            success: function (response) {
                debugger;
                $.unblockUI();

                if (response.error === true) {
                    swal({
                        text: response.msgError,
                        title: 'Intratec - Intec SAS',
                        icon: 'error'
                    });
                }
                else onContinue(response);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                swal({
                    text: xhr.responseText,
                    title: 'Intratec - Intec SAS',
                    icon: 'error'
                });
                $.unblockUI();
            }
        });
    }
    else {
        debugger;
        $.ajax({
            type: verb,
            url: urlServicio,
            async: false,
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            crossDomain: true,
            success: function (msg) {
                rta = msg;
            },
            error: function (xhr, ajaxOptions, thrownError) {
                swal({
                    text: xhr.responseText,
                    title: 'Intratec - Intec SAS',
                    icon: 'error'
                });
            }
        });
    }

    return rta;
}

function _peticionAjax_NoLockScreen(urlServicio, verb, parametros, onContinue) {
    var rta = "";

    $.ajax({
        type: verb,
        url: urlServicio,
        async: true,
        data: parametros,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        crossDomain: true,
        success: function (response) {            
            if (response.error === true) {
                swal({
                    text: response.msgError,
                    title: 'Intratec - Intec SAS',
                    icon: 'error'
                });
            }
            else onContinue(response);

        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal({
                text: xhr.responseText,
                title: 'Intratec - Intec SAS',
                icon: 'error'
            });
        }
    });

    return rta;
}

function _resetGenericModal() {
    $("#genericModalHeader").empty();
    $("#genericModalBody").empty();
    $("#genericModalFooter").empty();
}

function _openGenericModal() {
    $('#genericModal').modal('show');
}

function _closeGenericModal() {
    $('#genericModal').modal('hide');
}