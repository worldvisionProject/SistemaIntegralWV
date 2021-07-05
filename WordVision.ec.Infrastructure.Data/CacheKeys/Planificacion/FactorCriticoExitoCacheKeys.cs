using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Infrastructure.Data.CacheKeys.Planificacion
{
   public class FactorCriticoExitoCacheKeys
    {
        public static string ListKey => "FactorCriticoExitoList";

        public static string SelectListKey => "FactorCriticoExitoSelectList";

        public static string GetKey(int factorCriticoExitoId) => $"FactorCriticoExito-{factorCriticoExitoId}";

        public static string GetDetailsKey(int factorCriticoExitoId) => $"FactorCriticoExitoDetails-{factorCriticoExitoId}";
    }
}
