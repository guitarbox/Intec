const swalTitle = 'Intratec - Intec SAS';

var UsuarioSesion = null;

var VerbosREST = {
    POST: 'POST',
    GET: 'GET',
    PUT: 'PUT',
    DELETE: 'DELETE',
}

var URL_SERVICE = 'http://localhost:63440/';
//var URL_SERVICE = 'http://servicios.intecsas.com.co/';

var URI_SERVICE = {
    //--- Administracion ---
    //Administracion
    ObtenerRoles: 'api/Administracion/ObtenerRoles',

    //Parámetros
    ObtenerParametros: 'api/Parametros/ObtenerParametros',

    //Paises
    ObtenerPaisesActivos: 'api/Paises/ObtenerPaisesActivos',

    //Departamentos
    ObtenerDepartamentosActivos: 'api/Paises/ObtenerDepartamentosActivos',

    //Ciudades
    ObtenerCiudadesActivos: 'api/Departamentos/ObtenerCiudadesActivos',

    //TiposIdentificacion
    ObtenerTiposIdentificacion: 'api/TiposIdentificacion/ObtenerTiposIdentificacion',
    ObtenerTiposIdentificacionActivos: 'api/TiposIdentificacion/ObtenerTiposIdentificacionActivos',
    CrearTiposIdentificacion: 'api/TiposIdentificacion/CrearTipoIdentificacion',
    ActualizarTiposIdentificacion: 'api/TiposIdentificacion/ActualizarTipoIdentificacion',
    EliminarTiposIdentificacion: 'api/TiposIdentificacion/EliminarTipoIdentificacion',

    //MarcasEquipos
    ObtenerMarcasEquipos: 'api/MarcasEquipos/ObtenerMarcasEquipos',
    CrearMarcaEquipos: 'api/MarcasEquipos/CrearMarcaEquipos',
    ActualizarMarcaEquipos: 'api/MarcasEquipos/ActualizarMarcaEquipos',
    EliminarMarcaEquipos: 'api/MarcasEquipos/EliminarMarcaEquipos',

    //TiposEquipo
    ObtenerTiposEquipos: 'api/TiposEquipo/ObtenerTiposEquipo',
    CrearTipoEquipo: 'api/TiposEquipo/CrearTipoEquipo',
    ActualizarTipoEquipo: 'api/TiposEquipo/ActualizarTipoEquipo',
    EliminarTipoEquipo: 'api/TiposEquipo/EliminarTipoEquipo',

    //TiposPersona
    ObtenerTiposPersona: 'api/TiposPersona/ObtenerTiposPersona',
    ObtenerTiposPersonaActivos: 'api/TiposPersona/ObtenerTiposPersonaActivos',
    CrearTipoPersona: 'api/TiposPersona/CrearTipoPersona',
    ActualizarTipoPersona: 'api/TiposPersona/ActualizarTipoPersona',
    EliminarTipoPersona: 'api/TiposPersona/EliminarTipoPersona',

    //TiposPropiedades
    ObtenerTiposPropiedad: 'api/TiposPropiedad/ObtenerTiposPropiedad',
    CrearTipoPropiedad: 'api/TiposPropiedad/CrearTipoPropiedad',
    ActualizarTipoPropiedad: 'api/TiposPropiedad/ActualizarTipoPropiedad',
    EliminarTipoPropiedad: 'api/TiposPropiedad/EliminarTipoPropiedad',

    //UsosPropiedades
    ObtenerUsosPropiedades: 'api/UsosPropiedades/ObtenerUsosPropiedades',
    CrearUsoPropiedad: 'api/UsosPropiedades/CrearUsoPropiedad',
    ActualizarUsoPropiedad: 'api/UsosPropiedades/ActualizarUsoPropiedad',
    EliminarUsoPropiedad: 'api/UsosPropiedades/EliminarUsoPropiedad',

    //Usuarios
    ObtenerUsuarios: 'api/Usuarios/ObtenerUsuarios',
    CrearUsuario: 'api/Usuarios/CrearUsuario',

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
