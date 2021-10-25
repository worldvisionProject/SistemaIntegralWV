using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Soporte.Models
{
    public class DonanteViewModel
    {
        public int Id { get; set; }
        public string IDHubspot { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de convesión")]
        public DateTime? FechaConversion { get; set; }

        public int Canal { get; set; }
        public string Responsable { get; set; }
        public int Tipo { get; set; }
        public int Categoria { get; set; }
        public int Campana { get; set; }
        public int EstadoDonante { get; set; }
        [Display(Name = "Primer nombre")]
        public string Nombre1 { get; set; }
        [Display(Name = "Segundo nombre")]
        public string Nombre2 { get; set; }
        [Display(Name = "Primer apellido")]
        public string Apellido1 { get; set; }
        [Display(Name = "Segundo apellido")]
        public string Apellido2 { get; set; }
        public int Genero { get; set; }
        public int Cedula { get; set; }
        public string RUC { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public int Region { get; set; }
        public int Provincia { get; set; }

        public int Ciudad { get; set; }
        public string Direccion { get; set; }
        [Display(Name = "Teléfono")]
        public string TelefonoConvencional { get; set; }
        [Display(Name = "Celular")]
        public string TelefonoCelular { get; set; }
        public bool WhatsApp { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int FrecuenciaDonacion { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Cantidad { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? MesInicialDebito { get; set; }

        public int FormaPago { get; set; }
        public string NumReferencia { get; set; }
        public int? TipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public int? TiposTarjetasCredito { get; set; }
        public string NumeroTarjeta { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaCaducidad { get; set; }

          public int? Banco { get; set; }



        public string NumReferenciaBp { get; set; }
        public int? TipoCuentaBp { get; set; }
        public string NumeroCuentaBp { get; set; }
        public int? TiposTarjetasCreditoBp { get; set; }
        public string NumeroTarjetaBp { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaCaducidadBp { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaVencimiento { get; set; }
        public int? BancoBp { get; set; }

        public SelectList FormaPagoList { get; set; }
        public SelectList CanalList { get; set; }
        public SelectList ResponsableList { get; set; }
        public SelectList TipoList { get; set; }
        public SelectList CategoriaList { get; set; }
        public SelectList CampanaList { get; set; }
        public SelectList EstadoDonanteList { get; set; }
        public SelectList GeneroList { get; set; }
        public SelectList TipoIdList { get; set; }
        public SelectList RegionList { get; set; }
        public SelectList ProvinciaList { get; set; }
        public SelectList CiudadList { get; set; }
        public SelectList FrecuenciaList { get; set; }
        public SelectList TipoCuentaList { get; set; }
        public SelectList TipoTarjetaList { get; set; }
        public SelectList BancoList { get; set; }


    }
}
