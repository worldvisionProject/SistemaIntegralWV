using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Infrastructure.Data.CacheKeys.Valoracion
{
    public class ResultadoCacheKey
    {
        public static string ListKey => "ResultadoList";
        public static string ListKeyNivel => "ResultadoListNivel";
        public static string SelectListKey => "ResultadoSelectList";

        public static string GetKey(int resultadoId) => $"Resultado-{resultadoId}";

        public static string GetDetailsKey(int resultadoId) => $"ResultadoDetails-{resultadoId}";
    }
}
