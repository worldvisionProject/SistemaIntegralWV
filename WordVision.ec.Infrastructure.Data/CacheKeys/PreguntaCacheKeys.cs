using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Infrastructure.Data.CacheKeys
{
    public class PreguntaCacheKeys
    {

        public static string ListKey => "PreguntaList";

        public static string SelectListKey => "PreguntaSelectList";

        public static string GetKey(int PreguntaId) => $"Pregunta-{PreguntaId}";

        public static string GetDetailsKey(int PreguntaId) => $"PreguntaDetails-{PreguntaId}";
    }
}
