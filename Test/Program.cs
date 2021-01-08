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

            //var res = PClientesTE.ConsultaGralClientes("", "", "", "", false);

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

        static void Main(string[] args)
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

            //PPapeleriaTE.AsignarRangoConsecutivosFormatoInspector(8, 3, 0, 3, 2);

            // Resultado: En espera

            //7.

            PPapeleriaTE.IngresarConsecutivosFormatoBodega(8, 1, 100, 2);
        }
    }
}