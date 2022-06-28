﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Soporte.Models
{
    public class DonanteViewModelView
    {
        public List<DonanteViewModel> DonanteViewModels { get; set; }
        public SelectList CampanaList { get; set; }
        public SelectList EstadoDonanteList { get; set; }
        public SelectList CiudadList { get; set; }
    }
    public class DonanteViewModel
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de conversión")]
        public DateTime? FechaConversion { get; set; }
        [Display(Name = "Evidencia de conversión")]
        public byte[] EvidenciaConversion { get; set; }
        [Display(Name = "Canal")]
        public int Canal { get; set; }
        public int Responsable { get; set; }
        public int Tipo { get; set; }
        [Display(Name = "Categoría")]
        public int Categoria { get; set; }
        [Display(Name = "Campaña")]
        public int Campana { get; set; }
        [Display(Name = "Estado del Donante")]
        public int EstadoDonante { get; set; }
        [Display(Name = "Primer nombre")]
        public string Nombre1 { get; set; }
        [Display(Name = "Segundo nombre")]
        public string Nombre2 { get; set; }
        [Display(Name = "Primer apellido")]
        public string Apellido1 { get; set; }
        [Display(Name = "Segundo apellido")]
        public string Apellido2 { get; set; }
        [Display(Name = "Género")]
        public int Genero { get; set; }

        [Display(Name = "Tipo Id.")]
        public int Cedula { get; set; }

        [Display(Name = "Identificación")]
        public string RUC { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        [Display(Name = "Región")]
        public int Region { get; set; }
        public int Provincia { get; set; }

        public int Ciudad { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Area")]
        public string CodigoArea { get; set; }

        [Display(Name = "Teléfono")]
        public string TelefonoConvencional { get; set; }
        [Display(Name = "Celular")]
        public string TelefonoCelular { get; set; }
        public bool WhatsApp { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Frecuencia de Donación")]
        public int FrecuenciaDonacion { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Cantidad { get; set; }

        [Display(Name = "Fecha de inicio de débito")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? MesInicialDebito { get; set; }

        [Display(Name = "Forma de pago")]
        public int FormaPago { get; set; }
        [Display(Name = "Num. referencia")]
        public string NumReferencia { get; set; }
        [Display(Name = "Tipo de cuenta")]
        public int? TipoCuenta { get; set; }
        [Display(Name = "Número de cuenta")]
        public string NumeroCuenta { get; set; }
        [Display(Name = "Tipo de tarjetas")]
        public int? TiposTarjetasCredito { get; set; }
        [Display(Name = "Número de tarjeta")]
        public string NumeroTarjeta { get; set; }

        [Display(Name = "Fecha de caducidad")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaCaducidad { get; set; }

        [Display(Name = "Banco")]
        public int? Banco { get; set; }


        [Display(Name = "Num. referencia")]
        public string NumReferenciaBp { get; set; }
        public int? TipoCuentaBp { get; set; }
        public string NumeroCuentaBp { get; set; }
        public int? TiposTarjetasCreditoBp { get; set; }
        public string NumeroTarjetaBp { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaCaducidadBp { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaVencimiento { get; set; }
        public int? BancoBp { get; set; }
        [Display(Name = "Comentario Actualización")]
        public string ComentarioActualizacion { get; set; }
        [Display(Name = "Comentario Resolución")]
        public string ComentarioResolucion { get; set; }

        public string Colaborador { get; set; }

        public int? EsAdmin { get; set; }
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
        public SelectList CodigoAreaList { get; set; }

    }
}
