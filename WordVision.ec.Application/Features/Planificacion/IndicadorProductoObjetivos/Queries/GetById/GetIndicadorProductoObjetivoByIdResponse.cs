using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Queries.GetById
{
    public class GetIndicadorProductoObjetivoByIdResponse
    {
        public int Id { get; set; }
        public string Indicador { get; set; }

        public int AnioFiscal { get; set; }
        public int IdProductoObjetivo { get; set; }
        public ProductoObjetivo ProductoObjetivos { get; set; }

    }
}
