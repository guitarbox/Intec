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
            List < Intec.DAL.SolicitudesProgramacionVisitas > solicitudes = new Intec.DAL.TE.SolicitudesProgramacionVIsitasTE().ConsultarSolicitudes();
            foreach (Intec.DAL.SolicitudesProgramacionVisitas solicitud in solicitudes)
            {
                Console.WriteLine($"{solicitud.Nombre} {solicitud.Paises.CodigoPais}");
            }
            Console.ReadKey();
        }
    }
}
