using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Infrastructure.Data.CacheKeys.Valoracion
{
    public class ObjetivoCacheKeys
    {
        public static string ListKey => "ObjetivoList";
        public static string ListKeyNivel => "ObjetivoListNivel";
        public static string SelectListKey => "ObjetivoSelectList";

        public static string GetKey(int objetivoId) => $"Objetivo-{objetivoId}";

        public static string GetDetailsKey(int objetivoId) => $"ObjetivoDetails-{objetivoId}";
    }
}
