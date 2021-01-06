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
            Intec.DAL.TE.ClientesTE PClientesTE = new Intec.DAL.TE.ClientesTE();
            //Test Clientes
            //1.

            //var res = PClientesTE.ConsultaGralClientes("", "", "", "", false);
            // Resultado OK, testeado con los 4 filtros

            //2.

            var res = PClientesTE.ConsultaDetalladaClientes(4);
            //NOK
            
        }

        static void Main20(string[] args)
        {
            //Test Papelería
            //1. 
            Formatos formatoCrear = new Formatos() { };
            new Intec.DAL.TE.PapeleriaTE().CrearFormato(formatoCrear);
            //Resultado: OK / NOK: bla bla bla


        }
    }
}