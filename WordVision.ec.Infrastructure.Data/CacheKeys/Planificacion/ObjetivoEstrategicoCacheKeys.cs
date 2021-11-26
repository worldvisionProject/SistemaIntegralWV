namespace WordVision.ec.Infrastructure.Data.CacheKeys.Planificacion
{
    public class ObjetivoEstrategicoCacheKeys
    {
        public static string ListKey => "ObjetivoEstrategicoList";

        public static string SelectListKey => "ObjetivoEstrategicoSelectList";

        public static string GetKey(int objetivoEstrategicoId) => $"ObjetivoEstrategico-{objetivoEstrategicoId}";

        public static string GetDetailsKey(int objetivoEstrategicoId) => $"ObjetivoEstrategicoDetails-{objetivoEstrategicoId}";

    }
}
