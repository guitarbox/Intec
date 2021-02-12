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
    Paises: 'api/Paises',
    Departamentos: 'api/Departamentos',
    Ciudades: 'api/Ciudades',
    TiposIdentificacion: 'api/TiposIdentificacion',
    MarcasEquipos: 'api/MarcasEquipos',
    TiposEquipo: 'api/TiposEquipo',
    TiposPersona: 'api/TiposPersona',
    TiposPropiedades: 'api/TiposPropiedades',
    UsosPropiedades: 'api/UsosPropiedades',
    //Usuarios
    Usuarios: 'api/Usuarios/',
    LogIn: 'api/Usuarios/LogIn',
    RecuperarContrasena: 'api/Usuarios/RecuperarContrasena',
    ValidarTokenModPass: 'api/Usuarios/ValidarTokenModPass',
    ModificarContrasena: 'api/Usuarios/ModificarContrasena'
};

var _language_options_table =
{
    search: '',
    searchPlaceholder: 'Buscar',
    lengthMenu: 'Mostrar _MENU_ registros por página',
    info: 'Mostrando página _PAGE_ de _PAGES_',
    infoFiltered: "(filtrado de _MAX_ registros)",
    infoEmpty: "No hay registros disponibles",
    zeroRecords: "No hay registros disponibles",
    paginate: {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
    }
}
