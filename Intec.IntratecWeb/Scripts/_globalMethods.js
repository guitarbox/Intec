function _peticionAjax(urlServicio, verb, parametros, async, onContinue) {    
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
            success: function (rta) {
                $.unblockUI();

                //var json = rta;
                //if (json.error === true) {
                //    swal("Error: " + json.errorMessage);
                //}
                //else
                    onContinue(rta);
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
        success: function (rta) {
            //var json = rta;
            //if (json.error === true) {
            //    alert("Error: " + json.errorMessage);
            //}
            //else
                onContinue(rta);

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
