$(document).ready(() => {
    var response = _peticionAjax('../Session/GetUsuarioSesion', VerbosREST.GET, '', false);
    //response => {        
    if (response == "NO_SESSION")
        window.location.href = '../Usuarios/LogIn';
    UsuarioSesion = response;
    $("#UsuarioSesion").empty();
    $("#UsuarioSesion").append('Bienvenid@ ' + UsuarioSesion.Nombres + ' ' + UsuarioSesion.Apellidos);

    $("#Perfil").empty();
    $("#Perfil").append(UsuarioSesion.Roles.Rol);
    //});

    /*Cíclicas sin servicio*/
    Hora();
});

function Hora() {
    $("#hora").empty();
    $("#hora").append(new Date());
    setTimeout(Hora, 1000);
    //console.log('Hora ' + new Date());
}