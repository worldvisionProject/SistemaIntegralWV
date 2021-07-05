using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Infrastructure.Data.CacheKeys
{
    public class DocumentoCacheKeys
    {

        public static string ListKey => "DocumentoList";

        public static string SelectListKey => "DocumentoSelectList";

        public static string GetKey(int DocumentoId) => $"Documento-{DocumentoId}";

        public static string GetDetailsKey(int DocumentoId) => $"DocumentoDetails-{DocumentoId}";
    }
}
