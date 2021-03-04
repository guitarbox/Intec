﻿function _peticionAjax(urlServicio, verb, parametros, async, onContinue) {    
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

function _peticionAjax_NoLockScreen(urlServicio, verb, parametros) {
    return new Promise((resolve, reject) => {

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
                else resolve(response);

            },
            error: function (xhr, ajaxOptions, thrownError) {
                swal({
                    text: xhr.responseText,
                    title: 'Intratec - Intec SAS',
                    icon: 'error'
                });
                reject(xhr.responseText);
            }
        });

    });
}

function _peticionAjax_Promise(urlServicio, verb, parametros) {    
    return new Promise((resolve, reject) => {
            $.blockUI({
                message: ''
            });
            $.ajax({
                type: verb,
                url: urlServicio,
                async: true,
                data: parametros,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                crossDomain: true,
                success: function (response) {                    
                    $.unblockUI();
                    if (response.error === true) {
                        swal({
                            text: response.msgError,
                            title: 'Intratec - Intec SAS',
                            icon: 'error'
                        });
                    }
                    else resolve(response);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    swal({
                        text: xhr.responseText,
                        title: 'Intratec - Intec SAS',
                        icon: 'error'
                    });
                    $.unblockUI();
                    reject(xhr.responseText);
                }
            });
        });
    
}

/********************************************* Generic Modal Methods ******************************************************/
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

function _appendToHeaderGeneriModal(element) {
    $("#genericModalHeader").append(element);
}

function _appendToBodyGeneriModal(element) {
    $("#genericModalBody").append(element);
}

function _appendToFooterGeneriModal(element) {
    $("#genericModalFooter").append(element);
}
/**************************************************************************************************************************/

/**************************************** Global Select Load **************************************************************/
function _loadSelectTiposIdentificacion(element) {
    element.empty();
    element.append('<option value="">Seleccione...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerTiposIdentificacionActivos, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdTipoIdentificacion + '">' + d.TipoIdentificacion + '</option>');
    });
}

function _loadSelectTiposPersona(element) {
    element.empty();
    element.append('<option value="">Seleccione...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerTiposPersonaActivos, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdTipoPersona + '">' + d.TipoPersona + '</option>');
    });
}

function _loadSelectPaises(element) {
    element.empty();
    element.append('<option value="">Seleccione...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerPaisesActivos, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdPais + '">' + d.Pais + '</option>');
    });
}

function _loadSelectRoles(element) {
    element.empty();
    element.append('<option value="">Seleccione...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerRoles, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdRol + '">' + d.Rol + '</option>');
    });
}

function _loadSelectDepartamentos(element, idPais) {
    element.empty();
    element.append('<option value="">Seleccione...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerDepartamentosActivos, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion, idPais }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdDepartamento + '">' + d.Departamento + '</option>');
    });
}

function _loadSelectCiudades(element, idDepartamento) {
    debugger;
    element.empty();
    element.append('<option value="">Seleccione...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerCiudadesActivos, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion, idDepartamento }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdCiudad + '">' + d.Ciudad+ '</option>');
    });
}
/**************************************************************************************************************************/
