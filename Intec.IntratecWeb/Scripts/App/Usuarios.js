function IniciarSesion() {
    _peticionAjax(URL_SERVICE + URI_SERVICE.LogIn, VerbosREST.POST,
        JSON.stringify({ NumeroIdentificacion: $('#NumeroIdentificacion_LogIn').val(), Password: $('#Password_LogIn').val() }),
        true, response => {
            if (response != null) {
                _peticionAjax('../Session/AddUsuarioSesion', VerbosREST.POST, JSON.stringify({ UsuarioSesion: response }), false);
                window.location.href = '../Home/Index';
            }
            else
                swal('Usuario y/o Contraseña incorrecto(s)');
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