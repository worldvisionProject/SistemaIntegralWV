namespace WordVision.ec.Application.Features.Presupuesto.Presupuesto.Queries.GetAllCached
{
    public class GetAllPresupuestosCachedResponse
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public string T5 { get; set; }

        public string DescripcionT5 { get; set; }

        public decimal Precio { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Total { get; set; }

        public int TipoCargo { get; set; }


        public int Mes { get; set; }
        public int TodoAnio { get; set; }
    }
}
