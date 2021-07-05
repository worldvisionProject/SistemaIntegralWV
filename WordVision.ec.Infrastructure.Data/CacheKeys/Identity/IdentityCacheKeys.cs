using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Infrastructure.Data.CacheKeys.Identity
{
    public class IdentityCacheKeys
    {
        public static string ListKey => "IdentityList";

        public static string SelectListKey => "IdentitySelectList";

        public static string GetKey(string IdentityId) => $"Identity-{IdentityId}";

        public static string GetDetailsKey(string IdentityId) => $"IdentityDetails-{IdentityId}";
    }
}
