namespace WordVision.ec.Infrastructure.Data.CacheKeys.Maestro
{
    public class EstructuraCacheKeys
    {
        public static string ListKey => "EstructuraList";

        public static string SelectListKey => "EstructuraSelectList";

        public static string GetKey(int estructuraId) => $"Estructura-{estructuraId}";

        public static string GetDetailsKey(int estructuraId) => $"EstructuraDetails-{estructuraId}";
    }
}
