namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class IndicadorVinculadoPOAViewModel
    {
        public int Id { get; set; }
        public int TipoIndicador { get; set; }
        public int CodigoIndicador { get; set; }
        public int UnidadMedida { get; set; }
        public int ActorParticipante { get; set; }
        public int IdIndicadorPOA { get; set; }
        public IndicadorPOAViewModel IndicadorPOAs { get; set; }
    }
}
