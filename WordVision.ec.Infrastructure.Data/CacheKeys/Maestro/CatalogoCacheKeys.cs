using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Infrastructure.Data.CacheKeys.Maestro
{
    public class CatalogoCacheKeys
    {
        public static string ListKey => "CatalogoList";

        public static string SelectListKey => "CatalogoSelectList";

        public static string GetKey(int catalogoId) => $"Catalogo-{catalogoId}";

        public static string GetDetailsKey(int catalogoId) => $"CatalogoDetails-{catalogoId}";

        public static string DetailsListKey => "CatalogoDetalleList";

    }
}
