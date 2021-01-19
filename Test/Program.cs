using Intec.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
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

            //Resultado OK, Secuencia?, Falta validación

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

        static void Main(string[] args)
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

            var res = PVisitasTE.ConsultaVisitas( DateTime.Parse("21/01/2021"), DateTime.Parse("22/01/2021"), "", 2, "" );

            //Id Uso tb Clientes y propieades, SolicitudProgramacionVisitas IP no NULLS, la cédula debeestar completa
            //Inspector se puede asignar a visita sin importar la ciudad


        }


        #endregion











    }
}