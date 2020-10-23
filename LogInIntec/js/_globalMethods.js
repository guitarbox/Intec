function _peticionAjax(urlServicio, parametros, async, onContinue) {
    debugger;
    var rta = "";

    if (async !== null && async !== undefined && async) {

        //$.blockUI({
        //    message: ''
        //});

        $.ajax({
            type: "POST",
            url: urlServicio,
            async: true,
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (rta) {
                //$.unblockUI();

                var json = rta;
                if (json.error === true) {
                    alert("Error: " + json.errorMessage);
                }
                else
                    onContinue(rta);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.responseText);
                $.unblockUI();
            }
        });
    }
    else {
        $.ajax({
            type: "POST",
            url: urlServicio,
            async: false,
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                rta = msg;
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.responseText);
            }
        });
    }

    return rta;
}
