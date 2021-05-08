function _getUrlVars(url) {
    var vars = [], hash;
    var hashes = url.slice(url.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

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

/********************************************* Generic Date Methods ******************************************************/
function _setToday(element) {
    var date = new Date();
    element.val(`${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`);
}

function _getToday() {
    var date = new Date();
    return `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
}
/**************************************************************************************************************************/

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

function _loadSelectZona(element, idCiudad) {
    element.empty();
    element.append('<option value="0">Seleccione...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerZonas, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion, idCiudad }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdZona + '">' + d.Descripcion + '</option>');
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
    element.empty();
    element.append('<option value="">Seleccione...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerCiudadesActivos, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion, idDepartamento }), false);    
    resRequest.data.forEach(d => {        
        element.append('<option value="' + d.IdCiudad + '">' + d.Ciudad+ '</option>');
    });
}

function _loadSelectUsosPropiedad(element) {
    element.empty();
    element.append('<option value="">Seleccione...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerUsosPropiedadesActivos, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdUso + '">' + d.Uso+ '</option>');
    });
}

function _loadSelectTiposPropiedad(element) {
    element.empty();
    element.append('<option value="">Seleccione...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerTiposPropiedadActivos, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdTipoPropiedad + '">' + d.TipoPropiedad+ '</option>');
    });
}

function _loadSelectMarcas(element) {
    element.empty();
    element.append('<option value="">Seleccione Marca...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerMarcasEquiposActivos, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdMarcaEquipo + '">' + d.MarcaEquipo+ '</option>');
    });
}

function _loadSelectTipoEquipo(element) {
    element.empty();
    element.append('<option value="">Seleccione Tipo Equipo...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerTiposEquipoActivos, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdTipoEquipo + '">' + d.TipoEquipo + '</option>');
    });
}

function _loadSelectTiposVisita(element) {
    element.empty();
    element.append('<option value="">Seleccione Tipo Visita...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerTiposVisita, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdTipoVisita + '">' + d.TipoVisita + '</option>');
    });
}

function _loadSelectLaboratorios(element) {
    element.empty();
    element.append('<option value="">Seleccione Laboratorio...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerLaboratorios, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdLaboratorio + '">' + d.Laboratorio + '</option>');
    });
}

function _loadSelectEstadosVisita(element) {
    element.empty();
    element.append('<option value="">Seleccione Estado Visita...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerEstadosVisita, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append('<option value="' + d.IdEstadoVisita + '">' + d.EstadoVisita + '</option>');
    });
}

function _loadSelectTiposVisita(element, mostrarAmbos) {
    element.empty();
    element.append('<option value="">Seleccione Tipo Visita...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerTiposVisita, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    if (mostrarAmbos == true) {
        resRequest.data.forEach(d => {
            element.append('<option value="' + d.IdTipoVisita + '">' + d.TipoVisita + '</option>');
        });
    }
    else {
        resRequest.data.filter(f=>f.IdTipoVisita != 3).forEach(d => {
            element.append('<option value="' + d.IdTipoVisita + '">' + d.TipoVisita + '</option>');
        });
    }
}

function _loadSelectFranjasHorario(element) {
    element.empty();
    element.append('<option value="">Seleccione Franja...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerFranjasHorario, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append(`<option value="${d.IdFranja}">${d.HoraInicioFranja} ${d.HoraFinFranja}</option>`);
    });
}

function _loadSelectTiposFoto(element) {
    element.empty();
    element.append('<option value="">Seleccione Tipo Foto...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ObtenerTiposFoto, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append(`<option value="${d.IdTipoFoto}">${d.TipoFoto}</option>`);
    });
}

function _loadSelectFormato(element) {
    element.empty();
    element.append('<option value="">Seleccione Formato...</option>');
    let resRequest = _peticionAjax(URL_SERVICE + URI_SERVICE.ConsultarFormatos, VerbosREST.POST, JSON.stringify({ sessionToken: UsuarioSesion.tokenSesion }), false);
    resRequest.data.forEach(d => {
        element.append(`<option value="${d.IdFormato}">${d.NroFormato}</option>`);
    });
}
/**************************************************************************************************************************/
