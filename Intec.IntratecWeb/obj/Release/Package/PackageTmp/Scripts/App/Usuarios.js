function IniciarSesion() {
    _peticionAjax(URL_SERVICE + URI_SERVICE.LogIn, VerbosREST.POST,
        JSON.stringify({ NumeroIdentificacion: $('#NumeroIdentificacion_LogIn').val(), Password: $('#Password_LogIn').val() }),
        true, response => {
            if (response != null) {
                _peticionAjax('../Session/AddUsuarioSesion', VerbosREST.POST, JSON.stringify({ UsuarioSesion: response }), false);
                window.location.href = '../Home/Index';
            }
            else
                swal({
                    text: 'Usuario y/o Contraseña incorrecto(s)',
                    title: 'Intratec - Intec SAS',
                    icon: 'error'
                });            
            return false;
        });
}

function CerrarSesion() {
    _peticionAjax('../Session/Abandon', VerbosREST.POST, '', true,
        response => {
            UsuarioSesion = null;
            window.location.href = '../Usuarios/LogIn';
        });
}

function RecuperarContrasena() {
    _peticionAjax(URL_SERVICE + URI_SERVICE.RecuperarContrasena, VerbosREST.POST, JSON.stringify({  NumeroIdentificacion: $("#NumeroIdentificacion").val(), Email: $("#Email").val() }), true,
        response => {
            if(response)
                swal({
                    text: 'Se ha enviado un correo electrónico con las instrucciones para el cambio de contraseña.',
                    title: swalTitle,
                    icon: "success"
                });
            else
                swal({
                    text: 'No se encuentra usuario asociado a la cuenta de correo indicada.',
                    title: swalTitle,
                    icon: "error"
                });
        }
    );
}

function ModificarContrasena(token) {
    if ($("#NuevaContrasena").val() === $("#NuevaContrasena2").val()) {
        _peticionAjax(URL_SERVICE + URI_SERVICE.ModificarContrasena, VerbosREST.POST, JSON.stringify({ token, NuevaContrasena: $("#NuevaContrasena").val() }), true, response => {
            if (response) {
                $("#NuevaContrasena").val('');
                $("#NuevaContrasena2").val('');
                swal({ title: swalTitle, text: 'Contraseña actualizada correctamente', icon: 'success' })
                    .then(() => { window.location.href = '../Usuarios/Login' });
            }
            else
                swal({ title: swalTitle, text: 'Token no válido', icon: 'error' });
        });
    }
    else
        swal({ title: swalTitle, text: 'Las contraseñas no coinciden', icon: 'error' });
}