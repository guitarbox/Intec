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

        static void Main(string[] args)
        {
            Intec.DAL.TE.AdministracionTE PAdministracionTE = new Intec.DAL.TE.AdministracionTE();

            //1.

            //MarcasEquipos MEquipos = new MarcasEquipos()
            //{
            //    IdMarcaEquipo = 3,
            //    MarcaEquipo = "Bauker",
            //    IdUsuarioCreacion = 2
            //};

            //PAdministracionTE.CrearMarcaEquipos(MEquipos);

            //Resultado OK

            //2.

            //PAdministracionTE.EliminarMarcaEquipo(3);

            //Resultado OK, Eliminado ID 3

            //3.

            //var res = PAdministracionTE.ConsultarMarcasEquipos();

            //Resultado OK

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

            //PAdministracionTE.EliminarTipoEquipo(2);

            //Resultado OK, Eliminado ID 2

            //3

            //var res = PAdministracionTE.ConsultaTipoEquipo();

            //Resultado OK

        }


    }
}