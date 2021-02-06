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

    //var titles = $("[data-type='title']");
    //debugger;
    //for (let i = 0; i < titles.length; i++) {
    //    $("#" + titles[i].id).addClass('text-center');
    //}
});

function Hora() {
    $("#hora").empty();
    let h = new Date();
    $("#hora").append(h.getFullYear() + '/' + (h.getMonth() + 1) + '/' + h.getDate() + ' ' + h.getHours() + ':' + h.getMinutes() + ':' + h.getSeconds());
    setTimeout(Hora, 1000);
    //console.log('Hora ' + new Date());
}