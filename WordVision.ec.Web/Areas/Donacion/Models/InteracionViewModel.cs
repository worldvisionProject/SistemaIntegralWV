﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Donacion.Models
{
    public class InteracionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Gestión")]
        public int Gestion { get; set; }

        public int Tipo { get; set; }

        [Display(Name = "Observación")]
        public string Observacion { get; set; }

        public SelectList interacionesList { get; set; }

        public SelectList tipoList { get; set; }
        public int IdDonante { get; set; }
        public int vieneDe { get; set; }

        public int TipoPantalla { get; set; }

        [Display(Name = "Fecha de Entrega")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntregaKit { get; set; }

        [Display(Name = "Estado del Courier")]
        public int EstadoKitCourier { get; set; }

        [Display(Name = "Número de Guía")]
        public string NumeroGuiaKit { get; set; }

        public SelectList EstadoCourierList { get; set; }
        public List<InteracionListaViewModel> ListaInteracciones { get; set; }
    }

    public class InteracionListaViewModel
    {
        public int Id { get; set; }


        public int Gestion { get; set; }

        public int Tipo { get; set; }


        public string Observacion { get; set; }
        public DateTime? FechaEntregaKit { get; set; }


        public int EstadoKitCourier { get; set; }

        public string NumeroGuiaKit { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }

}
