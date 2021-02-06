const swalTitle = 'Intratec - Intec SAS';

var UsuarioSesion = null;

var VerbosREST = {
    POST: 'POST',
    GET: 'GET',
    PUT: 'PUT',
    DELETE: 'DELETE',
}

//var URL_SERVICE = 'http://localhost:63440/';
var URL_SERVICE = 'http://servicios.intecsas.com.co/';

var URI_SERVICE = {
    //Administracion
    Parametros: 'api/Parametros',
    //Usuarios
    LogIn: 'api/Usuarios/LogIn',
    RecuperarContrasena: 'api/Usuarios/RecuperarContrasena',
    ValidarTokenModPass: 'api/Usuarios/ValidarTokenModPass',
    ModificarContrasena: 'api/Usuarios/ModificarContrasena'
};