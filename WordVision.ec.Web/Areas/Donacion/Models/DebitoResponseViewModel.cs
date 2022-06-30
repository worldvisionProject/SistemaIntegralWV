using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace WordVision.ec.Web.Areas.Donacion.Models
{
    public class DebitoResponseViewModel
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string Categoria { get; set; }
        public string Campana { get; set; }
        public string Frecuencia { get; set; }
        public string Identificacion { get; set; }
        public string NombreDonante { get; set; }
        public string BancoTarjeta { get; set; }
        public string CuentaTarjeta { get; set; }
        public decimal Valor { get; set; }

        public int TipoId { get; set; }
        public int TipoCuenta { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public string RespuestaBanco { get; set; }
        public string FechaDebito { get; set; }
    }

    public class DebitoFiltroViewModel
    {
        public int FormaPago { get; set; }
        public int BancoTarjeta { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public SelectList FormaPagoList { get; set; }
        public SelectList BancosList { get; set; }
        public SelectList AnioList { get; set; }
        public SelectList MesList { get; set; }
    }
}
