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
    ObtenerTiposVisita: 'api/Administracion/ObtenerTiposVisita',
    ObtenerFranjasHorario: 'api/Administracion/ObtenerFranjasHorario',
    ObtenerTiposFoto: 'api/Administracion/ObtenerTiposFoto',

    //Parámetros
    ObtenerParametros: 'api/Parametros/ObtenerParametros',

    //Laboratorios
    ObtenerLaboratorios: 'api/Laboratorios/ObtenerLaboratorios',
    CrearLaboratorio: 'api/Laboratorios/CrearLaboratorio',

    //Paises
    ObtenerPaises: 'api/Paises/ObtenerPaises',
    ObtenerPaisesActivos: 'api/Paises/ObtenerPaisesActivos',
    CrearPais: 'api/Paises/CrearPais',
    ActualizarPais: 'api/Paises/ActualizarPais',
    EliminarPais: 'api/Paises/EliminarPais',

    //Departamentos
    ObtenerDepartamentosActivos: 'api/Paises/ObtenerDepartamentosActivos',
    ObtenerDepartamentos: 'api/Paises/ObtenerDepartamentos',
    CrearDepartamento: 'api/Departamentos/CrearDepartamento',
    ActualizarDepartamento: 'api/Departamentos/ActualizarDepartamento',
    EliminarDepartamento: 'api/Departamentos/EliminarDepartamento',

    //Ciudades
    ObtenerCiudadesActivos: 'api/Departamentos/ObtenerCiudadesActivos',
    ObtenerCiudades: 'api/Departamentos/ObtenerCiudades',
    CrearCiudad: 'api/Ciudades/CrearCiudad',
    ActualizarCiudad: 'api/Ciudades/ActualizarCiudad',
    EliminarCiudad: 'api/Ciudades/EliminarCiudad',

    //TiposIdentificacion
    ObtenerTiposIdentificacion: 'api/TiposIdentificacion/ObtenerTiposIdentificacion',
    ObtenerTiposIdentificacionActivos: 'api/TiposIdentificacion/ObtenerTiposIdentificacionActivos',
    CrearTiposIdentificacion: 'api/TiposIdentificacion/CrearTipoIdentificacion',
    ActualizarTiposIdentificacion: 'api/TiposIdentificacion/ActualizarTipoIdentificacion',
    EliminarTiposIdentificacion: 'api/TiposIdentificacion/EliminarTipoIdentificacion',

    //MarcasEquipos
    ObtenerMarcasEquipos: 'api/MarcasEquipos/ObtenerMarcasEquipos',
    ObtenerMarcasEquiposActivos: 'api/MarcasEquipos/ObtenerMarcasEquiposActivos',
    CrearMarcaEquipos: 'api/MarcasEquipos/CrearMarcaEquipos',
    ActualizarMarcaEquipos: 'api/MarcasEquipos/ActualizarMarcaEquipos',
    EliminarMarcaEquipos: 'api/MarcasEquipos/EliminarMarcaEquipos',

    //TiposEquipo
    ObtenerTiposEquipos: 'api/TiposEquipo/ObtenerTiposEquipo',
    ObtenerTiposEquipoActivos: 'api/TiposEquipo/ObtenerTiposEquipoActivos',
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
    ObtenerTiposPropiedadActivos: 'api/TiposPropiedad/ObtenerTiposPropiedadActivos',
    CrearTipoPropiedad: 'api/TiposPropiedad/CrearTipoPropiedad',
    ActualizarTipoPropiedad: 'api/TiposPropiedad/ActualizarTipoPropiedad',
    EliminarTipoPropiedad: 'api/TiposPropiedad/EliminarTipoPropiedad',

    //UsosPropiedades
    ObtenerUsosPropiedades: 'api/UsosPropiedades/ObtenerUsosPropiedades',
    ObtenerUsosPropiedadesActivos: 'api/UsosPropiedades/ObtenerUsosPropiedadesActivos',
    CrearUsoPropiedad: 'api/UsosPropiedades/CrearUsoPropiedad',
    ActualizarUsoPropiedad: 'api/UsosPropiedades/ActualizarUsoPropiedad',
    EliminarUsoPropiedad: 'api/UsosPropiedades/EliminarUsoPropiedad',

    //Usuarios
    ObtenerUsuarios: 'api/Usuarios/ObtenerUsuarios',
    ObtenerUsuario: 'api/Usuarios/ObtenerUsuario',
    CrearUsuario: 'api/Usuarios/CrearUsuario',
    ActualizarUsuario: 'api/Usuarios/ActualizarUsuario',
    GetUsuariosByIdRol: 'api/Usuarios/GetUsuariosByIdRol',
    AgregarCertificadoCompetencias: 'api/Usuarios/AgregarCertificadoCompetencias',

    LogIn: 'api/Usuarios/LogIn',
    RecuperarContrasena: 'api/Usuarios/RecuperarContrasena',
    ValidarTokenModPass: 'api/Usuarios/ValidarTokenModPass',
    ModificarContrasena: 'api/Usuarios/ModificarContrasena',
    //*** Administracion ***

    //Clientes
    ObtenerClientes: 'api/Clientes/ObtenerClientes',
    CrearCliente: 'api/Clientes/CrearCliente',
    ObtenerCliente: 'api/Clientes/ObtenerCliente',
    ActualizarCliente: 'api/Clientes/ActualizarCliente',

    //Propiedades
    CrearPropiedad: 'api/Propiedades/CrearPropiedad',
    EliminarPropiedad: 'api/Propiedades/EliminarPropiedad',

    //Equipos
    ObtenerEquipos: 'api/Equipos/ObtenerEquipos',
    ObtenerEquipo: 'api/Equipos/ObtenerEquipo',
    CrearEquipo: 'api/Equipos/CrearEquipo',
    ActualizarEquipo: 'api/Equipos/ActualizarEquipo',
    EliminarEquipo: 'api/Equipos/EliminarEquipo',
    TramitarEquipoInspector: 'api/Equipos/TramitarEquipoInspector',
    IngresarVerificacionALaboratorio: 'api/Equipos/IngresarVerificacionALaboratorio',
    IngresarACalibracionEquipo: 'api/Equipos/IngresarACalibracionEquipo',
    ObtenerEquiposUsuario: 'api/Equipos/ObtenerEquiposUsuario',

    //Visitas
    ObtenerZonasAll: 'api/Visitas/ObtenerZonasAll',
    ObtenerZonas: 'api/Visitas/ObtenerZonas',
    ObtenerZona: 'api/Visitas/ObtenerZona',
    CrearZona: 'api/Visitas/CrearZona',
    AsignarZonaInspector: 'api/Visitas/AsignarZonaInspector',
    ReAsignarZonaInspector: 'api/Visitas/ReAsignarZonaInspector',
    ProgramarVisita: 'api/Visitas/ProgramarVisita',
    ReasignacionVisita: 'api/Visitas/ReasignacionVisita',
    AgregarFotoVisita: 'api/Visitas/AgregarFotoVisita',
    AgregarFormatoVisita: 'api/Visitas/AgregarFormatoVisita',
    AgregarEquipoVisita: 'api/Visitas/AgregarEquipoVisita',
    ConsultarVisita: 'api/Visitas/ConsultarVisita',
    ConsultaVisitas: 'api/Visitas/ConsultarVisitas',
    ObtenerEstadosVisita: 'api/Visitas/ObtenerEstadosVisita',
    CancelarVisita: 'api/Visitas/CancelarVisita',
    EjecutarVisita: 'api/Visitas/EjecutarVisita',

    //Papelería
    ConsultarFormatos: 'api/Papeleria/ConsultarFormatos',
    ConsultarFormato: 'api/Papeleria/ConsultarFormato',
    EliminarFormato: 'api/Papeleria/EliminarFormato',
    CrearFormato: 'api/Papeleria/CrearFormato',
    ActualizarFormato: 'api/Papeleria/ActualizarFormato',
    IngresarConsecutivosFormatoBodega: 'api/Papeleria/IngresarConsecutivosFormatoBodega',
    ActualizarEstadoConsecutivo: 'api/Papeleria/ActualizarEstadoConsecutivo',
    ActualizarEstadoConsecutivos: 'api/Papeleria/ActualizarEstadoConsecutivos',
    AsignarRangoConsecutivosFormatoInspector: 'api/Papeleria/AsignarRangoConsecutivosFormatoInspector',
    ConsultarTramiteConsecutivoFormato: 'api/Papeleria/ConsultarTramiteConsecutivoFormato',
    ObtenerConsecutivosUsuario: 'api/Papeleria/ObtenerConsecutivosUsuario'
    
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
