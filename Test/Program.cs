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
            //Test Clientes
            
        }

        static void Main(string[] args)
        {
            //Test Papelería
            //1. 
            Formatos formatoCrear = new Formatos() { };
            new Intec.DAL.TE.PapeleriaTE().CrearFormato(formatoCrear);
            //Resultado: OK / NOK: bla bla bla


        }
    }
}