namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class IndicadorProductoObjetivoViewModel
    {
        public int Id { get; set; }
        public string Indicador { get; set; }
        public int AnioFiscal { get; set; }
        public int IdProductoObjetivo { get; set; }
        public ProductoObjetivoViewModel ProductoObjetivos { get; set; }
    }
}
