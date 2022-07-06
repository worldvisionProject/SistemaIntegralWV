using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Domain.Entities.Donacion
{
    public class ProductoDonante : AuditableEntity
    {
        public string NombreProducto { get; set; }

        public int Precio { get; set; }
        public int IdDonante { get; set; }
        public int FormaPago { get; set; }
        public string NumReferencia { get; set; }
        public int? TipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public int? TiposTarjetasCredito { get; set; }
        public string NumeroTarjeta { get; set; }

        public DateTime? FechaCaducidad { get; set; }
        public int? Banco { get; set; }


        public string NumReferenciaBp { get; set; }
        public int? TipoCuentaBp { get; set; }
        public string NumeroCuentaBp { get; set; }
        public int? TiposTarjetasCreditoBp { get; set; }
        public string NumeroTarjetaBp { get; set; }
        public DateTime? FechaCaducidadBp { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? BancoBp { get; set; }
        public Donante Donantes { get; set; }
    }
}
