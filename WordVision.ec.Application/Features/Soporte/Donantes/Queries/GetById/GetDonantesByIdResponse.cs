using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Donantes.Queries.GetById
{
    public class GetDonantesByIdResponse
    {
        public int IDHubspot { get; set; }

        public DateTime FechaConversion { get; set; }

        public int Canal { get; set; }
        public string Responsable { get; set; }
        public int Tipo { get; set; }
        public int Categoria { get; set; }
        public int Campana { get; set; }
        public int EstadoDonante { get; set; }

        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Genero { get; set; }
        public int Cedula { get; set; }
        public int RUC { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public int Region { get; set; }
        public int Provincia { get; set; }

        public int Ciudad { get; set; }
        public string Direccion { get; set; }
        public int TelefonoConvencional { get; set; }
        public int TelefonoCelular { get; set; }
        public bool WhatsApp { get; set; }
        public string Email { get; set; }
        public int FrecuenciaDonacion { get; set; }
        public int Cantidad { get; set; }
        public DateTime MesInicialDebito { get; set; }

        public int FormaPago { get; set; }
        public int NumReferencia { get; set; }
        public int TipoCuenta { get; set; }
        public int NumeroCuenta { get; set; }
        public int TiposTarjetasCredito { get; set; }
        public int NumeroTarjeta { get; set; }

        public DateTime FechaCaducidad { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Banco { get; set; }
    }
}
