using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Infrastructure.Data.CacheKeys.Planificacion
{
   public  class EstrategiaNacionalCacheKeys
    {
        public static string ListKey => "EstrategiaNacionalList";

        public static string SelectListKey => "EstrategiaNacionalSelectList";

        public static string GetKey(int estrategiaNacionalId) => $"EstrategiaNacional-{estrategiaNacionalId}";

        public static string GetDetailsKey(int estrategiaNacionalId) => $"EstrategiaNacionalDetails-{estrategiaNacionalId}";
    }
}
