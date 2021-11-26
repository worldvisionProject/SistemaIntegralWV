namespace WordVision.ec.Infrastructure.Data.CacheKeys.Planificacion
{
    public class IndicadorEstrategicosCacheKeys
    {
        public static string ListKey => "IndicadorEstrategicoList";

        public static string SelectListKey => "IndicadorEstrategicoSelectList";

        public static string GetKey(int indicadorEstrategicoId) => $"IndicadorEstrategico-{indicadorEstrategicoId}";

        public static string GetDetailsKey(int indicadorEstrategicoId) => $"IndicadorEstrategicoDetails-{indicadorEstrategicoId}";
    }
}
