using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Infrastructure.Data.CacheKeys.Planificacion
{
    public class GestionCacheKeys
    {
        public static string ListKey => "GestionList";

        public static string SelectListKey => "GestionSelectList";

        public static string GetKey(int gestionId) => $"Gestion-{gestionId}";

        public static string GetDetailsKey(int gestionId) => $"GestionDetails-{gestionId}";

    }
}
