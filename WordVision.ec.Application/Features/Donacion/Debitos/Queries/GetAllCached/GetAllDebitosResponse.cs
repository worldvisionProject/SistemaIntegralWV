using System;

namespace WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetAllCached
{
    public class GetAllDebitosResponse
    {
        public int Id { get; set; }
        public int CodigoBanco { get; set; }

        public int Anio { get; set; }

        public int Mes { get; set; }


        //public int Quincena { get; set; }


        public int Intento { get; set; }

        public decimal? Valor { get; set; }
        public int? CodigoRespuesta { get; set; }
        public int? Estado { get; set; }
        public int IdDonante { get; set; }
    }
}
