using Intec.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            new Intec.Common.Mail().SendEmail(new List<string>() { "lagunawilson@gmail.com" }, "Prueba", "<p>Hola</p>", new List<string>(), "intratec@intecsas.com.co", "intr4t3c@", "mail.intecsas.com.co", 25, out string msjError);
        }
            
        static void Main6(string[] args) //UsuariosBE
        {
            //Intec.BL.DTO.Usuarios usuario = new Intec.BL.BE.UsuarioBE().IniciarSesion("1019032749", "1234");
            int idUsuarioCreado = new Intec.BL.BE.UsuariosBE().CrearUsuario(new Intec.BL.DTO.Usuarios()
            {
                Nombres = "Tatiana",
                Apellidos = "Muñoz",
                IdTipoIdentificacion = 1,
                NumeroIdentificacion = "1019034383",
                Direccion = "Calle 58b #14a-59",
                IdCiudadDomicilio = "05001",
                IdPaisOrigen = 57,
                IdRol = 1,
                IdUsuarioCreacion = 1,
                Password = "1019034382",
                Telefono = "3125675736",
                Foto = "Foto"
            });
        }

        #region Test Clientes
        static void Main1(string[] args)
        {
            Intec.DAL.TE.ClientesTE PClientesTE = new Intec.DAL.TE.ClientesTE();
            //Test Clientes
            //1.

            //var res = PClientesTE.ConsultaGralClientes("1030", "", "", "", false);

            // Resultado OK, testeado con los 4 filtros

            //2.

            //var res = PClientesTE.ConsultaDetalladaClientes(3);

            //Resultado OK, id`s 3 y 4, Excepción OK

            //3. 
            //res.TelefonoFijo = "5709148";
            //PClientesTE.EditarClientes(res, 2);

            //Resultado OK, No logré testear la excepción ya que entra la del #2 al no encontrar IdCliente.

            //4.
            //Propiedades PropiedadCrear = new Propiedades()
            //{
            //    IdCliente = 3,
            //    Direccion = "Cra 12 # 54 - 48",
            //    IdUso = 1,
            //    Telefono = "1234567",
            //    Foto = "",
            //    Observaciones = "Esto es una observación",
            //    IdTipoPropiedad = 1,
            //    IdUsuarioCreacion = 2

            //};

            //new Intec.DAL.TE.ClientesTE().CrearPropiedad(PropiedadCrear);

            //Resultado OK

            //5.
            //var res = PClientesTE.ConsultaDetalladaPropiedad(4);
            //res.Observaciones = "Esto es un edit de la observación 2";
            //PClientesTE.EditarPropiedad(res, 2);

            //6.
            //PClientesTE.EliminarPropiedad(3);

            //Resultado OK, Eliminada Propiedad ID 3, Excpeción ok

            //7.
            //Clientes ClienteCrear = new Clientes()
            //{
            //    NumeroIdentificacion = "1026451697",
            //    IdTipoIdentificacion = 1,
            //    Nombres = "Estefany",
            //    Apellidos = "Cubillos",
            //    TelefonoFijo = "57091165",
            //    TelefonoCel1 = "3151234569",
            //    TelefonoCel2 = "3107894561",
            //    Direccion = "Cra 23 # 48 - 78",
            //    IdCiudad = "05001",
            //    Foto = "",
            //    Email1 = "Estefany12345@live.com",
            //    IdTipoPersona = 1,
            //    IdUso = 1,
            //    IdUsuarioCreacion = 2
            //};

            //PClientesTE.CrearCliente(ClienteCrear);

            //Resultado OK, cliente cerado, excepción numero y tipo de documento ok 
        }
        #endregion

        #region Test Papeleria
        static void Main2(string[] args)
        {
            Intec.DAL.TE.PapeleriaTE PPapeleriaTE = new Intec.DAL.TE.PapeleriaTE();
            //Test Papelería
            //1. 

            //Formatos formatoCrear = new Formatos()
            //{
            //    NroFormato = "FTOP-01",
            //    Formato = "Prueba Asignacion",
            //    Mascara = 4,
            //    Activo = true,
            //    IdUsuarioCreacion = 2
            //};

            //PPapeleriaTE.CrearFormato(formatoCrear);

            //Resultado OK

            //4.

            //var res = PPapeleriaTE.ConsultarFormato(6);

            //Resultado Ok

            //2.

            //res.Formato = "Prueba Edit 3";
            //PPapeleriaTE.EditarFormato(res, 2);

            // Resultado OK

            //3.

            //var res = PPapeleriaTE.ConsultarFormatos();

            //Resultado OK

            //5.

            //PPapeleriaTE.EliminarFormato(6);

            //Resultado OK, eliminado ID 7, Excepción OK no permite eliminar ID 6

            //6.

            //PPapeleriaTE.AsignarRangoConsecutivosFormatoInspector(8, 3, 12, 12, 2);

            // Resultado OK, Excepción OK

            //7.

            //PPapeleriaTE.IngresarConsecutivosFormatoBodega(8, 85, 100, 2);

            // Resultado OK, Excepción OK

            //8.

            //PPapeleriaTE.ActualizarEstadoConsecutivo(8, new List<int>() {6}, "X", 3, "Cambio a estado Anulacion");

            // Resultado OK, posible incosistencia columna IdInspector tablas TramiteConsecutivo y ConsecutivosFormato, Excepción OK
        }
        #endregion

        #region Test Equipos
        static void Main3(string[] args)
        {
            Intec.DAL.TE.EquiposTE PEquiposTE = new Intec.DAL.TE.EquiposTE();
            //1.

            //var res = PEquiposTE.ObtenerEquipos(1, 1, "02");

            //Resultado OK, Excepción OK

            //1.1

            //var res = PEquiposTE.ObtenerEquipos(2);

            //Resultado OK

            //2.

            //Equipos EquiposCrear = new Equipos
            //{
            //    Area = "Area1",
            //    SerieIDInterno = "EQ-005",
            //    IdTipoEquipo = 1,
            //    IdMarcaEquipo = 1,
            //    Modelo = "Modelo 02",
            //    RangoMedicion = "0 - 1000",
            //    Tolerancia = "10",
            //    Calibrado = true,
            //    PeriodoCalibracion = "120",
            //    PeriodoVerificacion = "60",
            //    IdUsuarioCreacion = 2

            //};

            //PEquiposTE.AgregarEquipo(EquiposCrear);

            //Resultado OK

            //3.

            //PEquiposTE.EliminarEquipo(4);

            //Resultado OK, ID 4 eliminado

            //4.

            //PEquiposTE.TramitarEquipoInspector(3, 3, 2, "ASIGNACION", "Prueba validación");

            // Resultado OK

            //5.

            //VerificacionesLabEquipos VEquipos = new VerificacionesLabEquipos()
            //{
            //    IdEquipo = 5,
            //    Secuencia = 1,
            //    FechaVerificacion = DateTime.Today,
            //    NroCertificado = "0001",
            //    Laboratorio = "QWERTY",
            //    Observaciones = "Prueba ingreso verificación LAB",
            //    IdUsuarioCreacion = 2
            //};

            //PEquiposTE.IngresarVerificacionLAB(VEquipos);

            //Resultado OK, Secuencia?, Falta validación

            //6.

            //CalibracionesEquipos CEquipos = new CalibracionesEquipos()
            //{
            //    IdEquipo = 3,
            //    Secuencia = 1,
            //    FechaCalibracion = DateTime.Today,
            //    Laboratorio = "ABCDE",
            //    Observaciones = "Prueba ingreso calibración equipos",
            //    IdUsuarioCreacion = 2
            //};

            //PEquiposTE.IngresarCalibracionEq(CEquipos);

            //Resultado OK, Falta validación

        }
        #endregion

        #region Test Administracion
        static void Main4(string[] args)
        {
            Intec.DAL.TE.AdministracionTE PAdministracionTE = new Intec.DAL.TE.AdministracionTE();

            //Paises

            //1

            //Paises PaisCrear = new Paises()
            //{
            //    IdPais = 4,
            //    Pais = "Prueba5",
            //    CodigoPais = "P5",
            //    IdUsuarioCreacion = 2
            //};

            //PAdministracionTE.CrearPais(PaisCrear);

            // Resultado OK

            //2

            //var res = PAdministracionTE.ObtenerPaises();

            // Resultado OK

            //3

            //var res = PAdministracionTE.ObtenerPais(0);

            //res.Pais = "Editar1";

            //PAdministracionTE.EditarPais(res, 2);

            //Resultado OK

            //4

            //PAdministracionTE.EliminarPais(4, 2);

            //Resultado OK, Descativados Ids 1, 3 y 4




            //Departamentos
            //1

            //Departamentos DepartamentoCrear = new Departamentos()
            //{
            //    IdDepartamento = "01",
            //    IdPais = 57,
            //    Departamento = "Prueba2",
            //    IdUsuarioCreacion = 2
            //};

            //PAdministracionTE.CrearDepartamento(DepartamentoCrear);

            //Resultado OK

            //2

            //var res = PAdministracionTE.ObtenerDepartamentos(57);

            //Resultado OK

            //3

            //var res = PAdministracionTE.ObtenerDepartamento("01");

            //res.Departamento = "Editar";

            //PAdministracionTE.EditarDepartamento(res, 2);

            //Resultado OK

            //4

            //PAdministracionTE.EliminarDepartamento("01", 2);




            //Ciudades

            //1

            //Ciudades CiudadCrear = new Ciudades()
            //{
            //    IdCiudad = "00002",
            //    IdDepartamento = "00",
            //    Ciudad = "Prueba2",
            //    IdUsuarioCreacion = 2
            //};

            //PAdministracionTE.CrearCiudad(CiudadCrear);

            // Resultado OK

            //2

            //var res = PAdministracionTE.ObtenerCiudades("05");

            //var res = PAdministracionTE.ObtenerCiudad("00002");

            // Resultado OK

            //3

            //res.Ciudad = "Editar";

            //PAdministracionTE.EditarCiudad(res, 2);

            // Resultado OK

            //4

            //PAdministracionTE.EliminarCiudad("00001", 2);

            // Resultado OK




            //TiposIdentificacion

            //1

            //TiposIdentificacion TipoIdentificacionCrear = new TiposIdentificacion()
            //{
            //    IdTipoIdentificacion = 6,
            //    TipoIdentificacion = "Prueba2",
            //    Abreviatura = "PR3",
            //    CodigoTipoIdFiscal = 00,
            //    IdUsuarioCreacion = 2
            //};

            //PAdministracionTE.CrearTipoIdentificacion(TipoIdentificacionCrear);

            //Resultado OK, IdTipoIdentificacion no se autoincrementa

            //2

            //var res = PAdministracionTE.ObtenerTiposIdentificacion();

            //var res = PAdministracionTE.ObtenerTipoIdentificacion(5);

            //res.CodigoTipoIdFiscal = 2;
            //res.Abreviatura = "OK";

            //Resultado OK

            //3

            //PAdministracionTE.EditarTipoIdentificacion(res, 2);

            //Resultado OK

            //4

            //PAdministracionTE.EliminarTipoIdentificacion(4, 2);

            //Resultado OK




            //MarcasEquipos

            //1.

            //MarcasEquipos MEquipos = new MarcasEquipos()
            //{
            //    IdMarcaEquipo = 3,
            //    MarcaEquipo = "Bauker",
            //    IdUsuarioCreacion = 2
            //};

            //PAdministracionTE.CrearMarcaEquipos(MEquipos);

            //Resultado OK, IdMarcaEquipo no se autoincrementa

            //2.

            //var res = PAdministracionTE.ObtenerMarcasEquipos();

            //var res = PAdministracionTE.ObtenerMarcaEquipo(2);

            //Resultado OK


            //3.

            //res.MarcaEquipo = "Stanley Editar";

            //PAdministracionTE.EditarMarcaEquipo(res, 2);

            //Resultado OK

            //4

            //PAdministracionTE.EliminarMarcaEquipo(2, 2);

            //Resultado OK




            //TiposEquipos

            //1.

            //TiposEquipo PTiposEquipo = new TiposEquipo()
            //{
            //    IdTipoEquipo = 3,
            //    TipoEquipo = "Corte",
            //    IdUsuarioCreacion = 2
            //};

            //PAdministracionTE.CrearTipoEquipo(PTiposEquipo);

            //Resultado OK

            //2

            //var res = PAdministracionTE.ConsultaTipoEquipo();

            //var res = PAdministracionTE.ObtenerTipoEquipo(3);

            //Resultado OK

            //3

            //res.TipoEquipo = "Corte Editar";

            //PAdministracionTE.EditarTipoEquipo(res, 2);

            //Resultado OK

            //4

            //PAdministracionTE.EliminarTipoEquipo(1, 2);

            //Resultado OK




            //TiposPersona

            //1

            //TiposPersona TipoPersonaCrear = new TiposPersona()
            //{
            //    IdTipoPersona = 4,
            //    TipoPersona = "Prueba2",
            //    CodigoTipoPersona = "3",
            //    IdUsuarioCreacion = 2
            //};

            //PAdministracionTE.CrearTipoPersona(TipoPersonaCrear);

            //Resultado OK, IdTipoPersona no se autoincrementa

            //2

            //var res = PAdministracionTE.ObtenerTiposPersona();

            //var res = PAdministracionTE.ObtenerTipoPersona(3);

            //3

            //res.TipoPersona = "Editar";
            //res.CodigoTipoPersona = "4";

            //PAdministracionTE.EditarTipoPersona(res, 2);

            //Resultado OK

            //4

            //PAdministracionTE.EliminarTipoPersona(4, 2);

            // Resultado OK




            //TiposPropiedades

            //1

            //TiposPropiedades TipoPropiedadCrear = new TiposPropiedades()
            //{
            //    IdTipoPropiedad = 5,
            //    TipoPropiedad = "Prueba2",
            //    IdUsuarioCreacion = 2
            //};

            //PAdministracionTE.CrearTipoPropiedad(TipoPropiedadCrear);

            //Resultado OK, IdTipoPropiedad no se autoincrementa

            //2

            //var res = PAdministracionTE.ObtenerTiposPropiedades();

            //var res = PAdministracionTE.ObtenerTipoPropiedad(4);

            //Resultado OK

            //3

            //res.TipoPropiedad = "Editar";

            //PAdministracionTE.EditarTipoPropiedad(res, 2);

            //Resultado OK

            //4

            //PAdministracionTE.EliminarTipoPropiedad(5, 2);

            //Resultado OK




            //UsosPropiedades

            //1

            //UsosPropiedades UsoPropiedadCrear = new UsosPropiedades()
            //{
            //    IdUso = 5,
            //    Uso = "Prueba3",
            //    IdUsuarioCreacion = 10
            //};

            //PAdministracionTE.CrearUsoPropiedad(UsoPropiedadCrear);

            //Resultado OK, IdUso no se autoincrementa, me permite crear con IdUsuarioCreacion 10

            //2

            //var res = PAdministracionTE.ObtenerUsosPropiedades();

            //var res = PAdministracionTE.ObtenerUsoPropieadad(5);

            //Resultado OK

            //3

            //res.Uso = "Editar2";

            //PAdministracionTE.EditarUsoPropiedad(res, 2);

            //Resultado OK

            //4

            //PAdministracionTE.EliminarUsoPropiedad(5, 2);

            //Resultado OK

        }
        #endregion

        #region Test Visitas

        static void Main5(string[] args)
        {
            Intec.DAL.TE.VisitasTE PVisitasTE = new Intec.DAL.TE.VisitasTE();

            //Zonas

            //1

            //Zonas ZonaCraer = new Zonas()
            //{
            //    IdZona = 3,
            //    IdCiudad = "11001",
            //    Descripcion = "Esta es la creación de otra zona 2",
            //    IdUsuarioCreacion = 2
            //};

            //PVisitasTE.CrearZona(ZonaCraer);

            //Resultado OK, IdZona no se autoincrementa

            //2

            //var res = PVisitasTE.ObtenerZonas();

            //3

            //var res = PVisitasTE.ObtenerZona(3);

            //Resultado OK

            //4 AsignarZona

            //PVisitasTE.AsignarZonaInspector(6, "11001", 4, 2);

            //Resultado OK, Falta excpeción para Inspector no existe?

            //5 Reasignar

            //PVisitasTE.ReAsignarZonaInspector(5, "11001", 3, 2);

            //Resultado OK



            //Visita

            //1

            //Visitas VisitaProgramar = new Visitas()
            //{
            //    IdSolicitudProgramacion = 3,
            //    IdCliente = 3,
            //    IdPropiedad = 4, 
            //    Direccion = "Cr 80 C # 42 C 83 Sur",
            //    IdZona = 1,
            //    IdCiudad = "11001",
            //    FechaVisita = DateTime.Today,
            //    IdInspector = 3,
            //    ObservacionesVisita = "Esto es una creación",
            //    IdEstadoVisitas = "P",
            //    OrigenVisita  = "Sitio Web",
            //    IdUsuarioCreacion = 2
            //};

            //PVisitasTE.ProgramarVisita(VisitaProgramar);

            //2

            //PVisitasTE.ReasignacionVisita(2, 5);

            //Fecha modificación y Id? - Cambio de IdEstadoVisitas?

            //3

            //FotosVisita FotoCrear = new FotosVisita()
            //{
            //    IdVisita = 2,
            //    Path = "RutaFoto"
            //};

            //PVisitasTE.AgregarFotoVisita(FotoCrear, 2);

            //Resultado OK

            //4

            //FormatosVisita FormatoCrear = new FormatosVisita()
            //{
            //    IdVisita = 5,
            //    IdFormato = 8,
            //    Consecutivo = 15
            //};

            //PVisitasTE.AgregarFormatoVisita(FormatoCrear, 2);

            //Resultado OK

            // 5

            //EquiposVisita EquipoVisitaCrear = new EquiposVisita()
            //{
            //    IdVisita = 2,
            //    IdEquipo = 2
            //};

            //PVisitasTE.AgregarEquipoVisita(EquipoVisitaCrear, 2);

            //Resultado OK

            //6

            //var res = PVisitasTE.ConsultarVisita(2);

            //Ok

            var res = PVisitasTE.ConsultaVisitas(DateTime.Parse("21/01/2021"), DateTime.Parse("22/01/2021"), "", 2, "");

            //Id Uso tb Clientes y propieades, SolicitudProgramacionVisitas IP no NULLS, la cédula debe estar completa
            //Inspector se puede asignar a visita sin importar la ciudad


        }


        #endregion

        #region Test AdministracionBE

        static void Main7(string[] args)
        {
            Intec.BL.BE.AdministracionBE TAdministracionBE = new Intec.BL.BE.AdministracionBE();

            //Paises

            //1

            //Intec.BL.DTO.Paises PaisCrear = new Intec.BL.DTO.Paises()
            //{
            //    IdPais = 5,
            //    Pais = "PruebaBE1",
            //    CodigoPais = "BE1",
            //    IdUsuarioCreacion = 2
            //};

            //TAdministracionBE.CrearPais(PaisCrear);

            //Resultado OK

            //2

            //var res = TAdministracionBE.ObtenerPaises();

            //var res = TAdministracionBE.ObtenerPais(5);

            // Resultado OK

            //3

            //res.Pais = "EditarBE1";

            //TAdministracionBE.EditarPais(res, 2);

            //Resultado OK

            //4

            //TAdministracionBE.EliminarPais(5, 2);

            //Resultado OK



            //Departamentos
            //1

            //Intec.BL.DTO.Departamentos DepartamentoCrear = new Intec.BL.DTO.Departamentos()
            //{
            //    IdDepartamento = "02",
            //    IdPais = 57,
            //    Departamento = "PruebaBE1",
            //    IdUsuarioCreacion = 2
            //};

            //TAdministracionBE.CrearDepartamento(DepartamentoCrear);

            //Resultado OK

            //2

            //var res = TAdministracionBE.ObtenerDepartamentos(57);

            //var res = TAdministracionBE.ObtenerDepartamento("02");

            //Resultado OK

            //3


            //res.Departamento = "EditarBE";

            //TAdministracionBE.EditarDepartamento(res, 2);

            //Resultado OK

            //4

            //TAdministracionBE.EliminarDepartamento("02", 2);

            //Resultado OK



            //Ciudades

            //1

            //Intec.BL.DTO.Ciudades CiudadCrear = new Intec.BL.DTO.Ciudades()
            //{
            //    IdCiudad = "00003",
            //    IdDepartamento = "01",
            //    Ciudad = "PruebaBE",
            //    IdUsuarioCreacion = 2
            //};

            //TAdministracionBE.CrearCiudad(CiudadCrear);

            // Resultado OK, Se generó ciudad con Departamento inactivo

            //2

            //var res = TAdministracionBE.ObtenerCiudades("05");

            //var res = TAdministracionBE.ObtenerCiudad("00003");

            // Resultado OK

            //3

            //res.Ciudad = "EditarBE";

            //TAdministracionBE.EditarCiudad(res, 2);

            // Resultado OK

            //4

            //TAdministracionBE.EliminarCiudad("00003", 2);

            // Resultado OK




            //TiposIdentificacion

            //1

            //Intec.BL.DTO.TiposIdentificacion TipoIdentificacionCrear = new Intec.BL.DTO.TiposIdentificacion()
            //{
            //    IdTipoIdentificacion = 6,
            //    TipoIdentificacion = "PruebaBE",
            //    Abreviatura = "BE1",
            //    CodigoTipoIdFiscal = 00,
            //    IdUsuarioCreacion = 2
            //};

            //TAdministracionBE.CrearTipoIdentificacion(TipoIdentificacionCrear);

            //Resultado OK, IdTipoIdentificacion no se autoincrementa

            //2

            //var res = TAdministracionBE.ObtenerTiposIdentificacion();

            //var res = TAdministracionBE.ObtenerTipoIdentificacion(6);

            //res.CodigoTipoIdFiscal = 2;
            //res.Abreviatura = "OK";

            //Resultado OK

            //3

            //TAdministracionBE.EditarTipoIdentificacion(res, 2);

            //Resultado OK

            //4

            //TAdministracionBE.EliminarTipoIdentificacion(6, 2);

            //Resultado OK




            //MarcasEquipos

            //1.

            //Intec.BL.DTO.MarcasEquipos MEquipos = new Intec.BL.DTO.MarcasEquipos()
            //{
            //    IdMarcaEquipo = 3,
            //    MarcaEquipo = "Bauker",
            //    IdUsuarioCreacion = 2
            //};

            //TAdministracionBE.CrearMarcaEquipo(MEquipos);

            //Resultado OK, IdMarcaEquipo no se autoincrementa

            //2.

            //var res = TAdministracionBE.ObtenerMarcasEquipos();

            //var res = TAdministracionBE.ObtenerMarcaEquipo(2);

            //Resultado OK


            //3.

            //res.MarcaEquipo = "EditarBE";

            //TAdministracionBE.EditarMarcaEquipo(res, 2);

            //Resultado OK

            //4

            //TAdministracionBE.EliminarMarcaEquipo(3, 2);

            //Resultado OK




            //TiposEquipos

            //1.

            //Intec.BL.DTO.TiposEquipo PTiposEquipo = new Intec.BL.DTO.TiposEquipo()
            //{
            //    IdTipoEquipo = 2,
            //    TipoEquipo = "PruebaBE",
            //    IdUsuarioCreacion = 2
            //};

            //TAdministracionBE.CrearTipoEquipo(PTiposEquipo);

            //Resultado OK

            //2

            //var res = TAdministracionBE.ObtenerTiposEquipos();

            //var res1 = TAdministracionBE.ObtenerTipoEquipo(2);

            //Resultado OK

            //3

            //res1.TipoEquipo = "EditarBE";

            //TAdministracionBE.EditarTipoEquipo(res1, 2);

            //Resultado OK

            //4

            //TAdministracionBE.EliminarTipoEquipo(3, 2);

            //Resultado OK




            //TiposPersona

            //1

            //Intec.BL.DTO.TiposPersona TipoPersonaCrear = new Intec.BL.DTO.TiposPersona()
            //{
            //    IdTipoPersona = 5,
            //    TipoPersona = "PruebaBE",
            //    CodigoTipoPersona = "3",
            //    IdUsuarioCreacion = 2
            //};

            //TAdministracionBE.CrearTipoPersona(TipoPersonaCrear);

            //Resultado OK, IdTipoPersona no se autoincrementa

            //2

            //var res = TAdministracionBE.ObtenerTiposPersona();

            //var res1 = TAdministracionBE.ObtenerTipoPersona(5);

            //3

            //res1.TipoPersona = "EditarBE";

            //TAdministracionBE.EditarTipoPersona(res1, 2);

            //Resultado OK

            //4

            //TAdministracionBE.EliminarTipoPersona(5, 2);

            // Resultado OK




            //TiposPropiedades

            //1

            //Intec.BL.DTO.TiposPropiedades TipoPropiedadCrear = new Intec.BL.DTO.TiposPropiedades()
            //{
            //    IdTipoPropiedad = 6,
            //    TipoPropiedad = "PruebaBE",
            //    IdUsuarioCreacion = 2
            //};

            //TAdministracionBE.CrearTipoPropiedad(TipoPropiedadCrear);

            //Resultado OK, IdTipoPropiedad no se autoincrementa

            //2

            //var res = TAdministracionBE.ObtenerTiposPropiedades();

            //var res1 = TAdministracionBE.ObtenerTipoPropiedad(5);

            //Resultado OK

            //3

            //res1.TipoPropiedad = "EditarBE";

            //TAdministracionBE.EditarTipoPropiedad(res1, 2);

            //Resultado OK

            //4

            //TAdministracionBE.EliminarTipoPropiedad(4, 2);

            //Resultado OK




            //UsosPropiedades

            //1

            //Intec.BL.DTO.UsosPropiedades UsoPropiedadCrear = new Intec.BL.DTO.UsosPropiedades()
            //{
            //    IdUso = 6,
            //    Uso = "PruebaBE",
            //    IdUsuarioCreacion = 2
            //};

            //TAdministracionBE.CrearUsoPropiedad(UsoPropiedadCrear);

            //Resultado OK, IdUso no se autoincrementa, me permite crear con IdUsuarioCreacion 10

            //2

            //var res = TAdministracionBE.ObtenerUsosPropiedades();

            //var res1 = TAdministracionBE.ObtenerUsoPropiedad(4);

            //Resultado OK

            //3

            //res1.Uso = "EditarBE";

            //TAdministracionBE.EditarUsoPropiedad(res1, 2);

            //Resultado OK

            //4

            //TAdministracionBE.EliminarUsoPropiedad(3, 2);

            //Resultado OK


        }

        #endregion

        #region Test ClientesBE

        static void Main8(string[] args)
        {

            Intec.BL.BE.ClientesBE TClientesBE = new Intec.BL.BE.ClientesBE();

            //1.

            //var res = TClientesBE.ConsultaGralClientes("", "cárdenas", "", "", false);

            // Resultado OK, no es case sensitive pero sí requiere tildes

            //2.

            //var res1 = TClientesBE.ConsultaDetalladaClientes(3);

            //Resultado OK

            //3. 

            //res1.TelefonoFijo = "7777777";
            //TClientesBE.EditarClientes(res1, 2);

            //Resultado OK

            //4.
            //Intec.BL.DTO.Propiedades PropiedadCrear = new Intec.BL.DTO.Propiedades()
            //{
            //    IdCliente = 10,
            //    Direccion = "Cra 85 # 23 - 78",
            //    IdUso = 1,
            //    Telefono = "6543217",
            //    Foto = "Foto",
            //    Observaciones = "Esto es una observación",
            //    IdTipoPropiedad = 2,
            //    IdUsuarioCreacion = 2

            //};

            //TClientesBE.CrearPropiedad(PropiedadCrear);

            //Resultado OK

            //5.

            //var res = TClientesBE.ConsultaDetalladaPropiedad(4);
            //res.Observaciones = "Esto es un edit BE";
            //TClientesBE.EditarPropiedad(res, 2);

            //6.

            //TClientesBE.EliminarPropiedad(9);

            //Resultado OK

            //7.
            //Intec.BL.DTO.Clientes ClienteCrear = new Intec.BL.DTO.Clientes()
            //{
            //    NumeroIdentificacion = "111223365",
            //    IdTipoIdentificacion = 1,
            //    Nombres = "BE",
            //    Apellidos = "test",
            //    TelefonoFijo = "9876543",
            //    TelefonoCel1 = "3150000000",
            //    TelefonoCel2 = "3105555555",
            //    Direccion = "Cra 41 # 58 - 74",
            //    IdCiudad = "05001",
            //    Foto = "",
            //    Email1 = "qwewqlive.com",
            //    IdTipoPersona = 1,
            //    IdUso = 1,
            //    IdUsuarioCreacion = 2
            //};

            //TClientesBE.CrearCliente(ClienteCrear);

            //Resultado OK, Correo sin @

        }

        #endregion

        #region Test EquiposBE
        static void Main9(string[] args)
        {
            Intec.BL.BE.EquiposBE PEquiposTE = new Intec.BL.BE.EquiposBE();

            //1.

            //var res = PEquiposTE.ObtenerEquipos(1, 1, "02");

            //Resultado OK

            //1.1

            //var res = PEquiposTE.ObtenerEquipo(2);

            //Resultado OK

            //2.

            //Intec.BL.DTO.Equipos EquiposCrear = new Intec.BL.DTO.Equipos()
            //{
            //    Area = "Area2",
            //    SerieIDInterno = "EQ-006BE",
            //    IdTipoEquipo = 1,
            //    IdMarcaEquipo = 1,
            //    Modelo = "Modelo 02",
            //    RangoMedicion = "0 - 1000",
            //    Tolerancia = "10",
            //    Calibrado = true,
            //    PeriodoCalibracion = "120",
            //    PeriodoVerificacion = "60",
            //    IdUsuarioCreacion = 2

            //};

            //PEquiposTE.AgregarEquipo(EquiposCrear);

            //Resultado OK

            //3.

            //PEquiposTE.EliminarEquipo(6);

            //Resultado OK

            //4.

            //PEquiposTE.TramitarEquipoInspector(7, 3, 2, "ASIGNACION", "Prueba BE");

            // Resultado OK

            //5.

            //Intec.BL.DTO.VerificacionesLabEquipos VEquipos = new Intec.BL.DTO.VerificacionesLabEquipos()
            //{
            //    IdEquipo = 1,
            //    FechaVerificacion = DateTime.Today,
            //    NroCertificado = "0002",
            //    Laboratorio = "QWERTY",
            //    Observaciones = "Prueba ingreso BE2",
            //    IdUsuarioCreacion = 2
            //};

            //PEquiposTE.IngresarVerificacionLAB(VEquipos);

            //Resultado OK, Validaciones

            //6.

            //Intec.BL.DTO.CalibracionesEquipos CEquipos = new Intec.BL.DTO.CalibracionesEquipos()
            //{
            //    IdEquipo = 7,
            //    FechaCalibracion = DateTime.Today,
            //    Laboratorio = "ABCDE",
            //    Observaciones = "Prueba ingreso BE",
            //    IdUsuarioCreacion = 2
            //};

            //PEquiposTE.IngresarCalibracionEq(CEquipos);

            //Resultado OK, Validaciones

        }

        #endregion

        #region Test PapeleriaBE
        static void Main10(string[] args)
        {
            Intec.BL.BE.PapeleriaBE PPapeleriaTE = new Intec.BL.BE.PapeleriaBE();
            //Test Papelería
            //1. 

            //Intec.BL.DTO.Formatos formatoCrear = new Intec.BL.DTO.Formatos()
            //{
            //    NroFormato = "FTOBE-01",
            //    Formato = "PruebaBE",
            //    Mascara = 4,
            //    Activo = true,
            //    IdUsuarioCreacion = 2
            //};

            //PPapeleriaTE.CrearFormato(formatoCrear);

            //Resultado OK

            //4.

            //var res = PPapeleriaTE.ConsultarFormato(8);

            //Resultado Ok

            //2.

            //res.Formato = "Edit BE";
            //PPapeleriaTE.EditarFormato(res, 2);

            // Resultado OK

            //3.

            //var res = PPapeleriaTE.ConsultarFormatos();

            //Resultado OK

            //5.

            //PPapeleriaTE.EliminarFormato(6);

            //Resultado OK, Como funciona la excepción?

            //6.

            //PPapeleriaTE.AsignarRangoConsecutivosFormatoInspector(8, 3, 15, 16, 2);

            // Resultado OK

            //7.

            //PPapeleriaTE.IngresarConsecutivosFormatoBodega(9, 1, 5, 2);

            // Resultado OK

            //8.

            //PPapeleriaTE.ActualizarEstadoConsecutivo(8, new List<int>() { 15, 16 }, "R", 3, "Cambio a estado BE");

            // Resultado OK, De bodega directo a aceptación
        }

        #endregion

        #region Test VisitasBE

        static void Mainv(string[] args)
        {
            Intec.BL.BE.VisitasBE PVisitasBE = new Intec.BL.BE.VisitasBE();

            //Zonas

            //1

            //Intec.BL.DTO.Zonas ZonaCraer = new Intec.BL.DTO.Zonas()
            //{
            //    IdZona = 6,
            //    IdCiudad = "11001",
            //    Descripcion = "Esta es la creación BE",
            //    IdUsuarioCreacion = 2
            //};

            //PVisitasBE.CrearZona(ZonaCraer);

            //Resultado OK, IdZona no se autoincrementa

            //2

            //var res = PVisitasBE.ObtenerZonas();

            //3

            //var res = PVisitasBE.ObtenerZona(3);

            //Resultado OK

            //4 AsignarZona

            //PVisitasBE.AsignarZonaInspector(6, "11001", 3, 2);

            //Resultado OK, Falta excpeción para Inspector no existe?

            //5 Reasignar

            //PVisitasBE.ReAsignarZonaInspector(6, "11001", 2, 2);

            //Resultado OK



            //Visita

            //1

            //Intec.BL.DTO.Visitas VisitaProgramar = new Intec.BL.DTO.Visitas()
            //{
            //    IdSolicitudProgramacion = 3,
            //    IdCliente = 3,
            //    IdPropiedad = 4,
            //    Direccion = "Cr 80 C # 42 C 83 Sur",
            //    IdZona = 1,
            //    IdCiudad = "11001",
            //    FechaVisita = DateTime.Today,
            //    IdInspector = 3,
            //    ObservacionesVisita = "Esto es una creación BE",
            //    IdEstadoVisitas = "P",
            //    OrigenVisita = "Sitio Web",
            //    IdUsuarioCreacion = 2
            //};

            //PVisitasBE.ProgramarVisita(VisitaProgramar);

            //Resultado OK, se pueden crear 2 iguales

            //2

            //PVisitasBE.ReasignacionVisita(10, 2);

            //Fecha y Id modificación?

            //3

            //Intec.BL.DTO.FotosVisita FotoCrear = new Intec.BL.DTO.FotosVisita()
            //{
            //    IdVisita = 11,
            //    Path = "RutaFoto"
            //};

            //PVisitasBE.AgregarFotoVisita(FotoCrear, 2);

            //Resultado OK, pude crear una visita id 11 con argumento 2

            //4

            //Intec.BL.DTO.FormatosVisita FormatoCrear = new Intec.BL.DTO.FormatosVisita()
            //{
            //    IdVisita = 11,
            //    IdFormato = 8,
            //    Consecutivo = 4
            //};

            //PVisitasBE.AgregarFormatoVisita(FormatoCrear, 2);

            //Resultado OK

            // 5

            //Intec.BL.DTO.EquiposVisita EquipoVisitaCrear = new Intec.BL.DTO.EquiposVisita()
            //{
            //    IdVisita = 11,
            //    IdEquipo = 2
            //};

            //PVisitasBE.AgregarEquipoVisita(EquipoVisitaCrear, 11);

            //Resultado OK, Deja duplicar el equipo

            //6

            //var res = PVisitasBE.ConsultarVisita(2);

            //Ok

            var res = PVisitasBE.ConsultaVisitas(DateTime.Parse("02/02/2021"), DateTime.Parse("22/02/2021"), "", 3, "");

            //Id Uso tb Clientes y propieades, SolicitudProgramacionVisitas IP no NULLS, la cédula debeestar completa
            //Inspector se puede asignar a visita sin importar la ciudad


            #endregion

        }
    }

}