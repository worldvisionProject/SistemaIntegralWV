using System;

namespace WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetById
{
    public class GetDebitosByIdResponse
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public int CodigoBanco { get; set; }

        public int Anio { get; set; }

        public int Mes { get; set; }


      //  public int Quincena { get; set; }


        public int Intento { get; set; }

        public decimal? Valor { get; set; }
        public string CodigoRespuesta { get; set; }
        public int? Estado { get; set; }
        public int IdDonante { get; set; }
        public int FormaPago { get; set; }

        public string Contrapartida { get; set; }
        public string FechaDebito { get; set; }
    }
}
