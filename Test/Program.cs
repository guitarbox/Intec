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
        static void Main(string[] args)
        {
            Intec.DAL.TE.ClientesTE clienteTe = new Intec.DAL.TE.ClientesTE();

            // 1)
            //var res = clienteTe.ConsultaGralClientes("1030", "", "", "", false);

            // 2)
            Intec.DAL.Clientes res = clienteTe.ConsultaDetalladaClientes(4);

            // 3)
            res.Nombres = "wishon";
            clienteTe.EditarClientes(res, 1);

            // 7)
            //new Intec.DAL.TE.ClientesTE().CrearCliente(new Intec.DAL.Clientes() {
            //    Apellidos = "Laguna Cárdenas",
            //    Direccion = "Calle 58b No. 14a-59",
            //    Email1 = "lagunawilson@gmail.com",
            //    Email2 = "ing.wlaguna@gmail.com",
            //    Foto = "",
            //    IdCiudad = "05001",                
            //    IdTipoIdentificacion  =1,
            //    IdTipoPersona = 1,
            //    IdUso = 1,
            //    IdUsuarioCreacion = 1,
            //    Nombres = "Wilson Alexánder",
            //    NumeroIdentificacion = "1019032749",
            //    TelefonoCel1 = "3192665259",
            //    TelefonoCel2 = "3108854944",
            //    TelefonoFijo = "8114718"
            //});
        }
    }
}