using Intec.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class ParametrosBE
    {
        public static List<Parametros> Parametros 
        {
            get => MapperConfig.Config.MapperParametros.Map<List<DTO.Parametros>>(new DAL.TE.ParametrosTE().GetAll());
        }
    }
}
