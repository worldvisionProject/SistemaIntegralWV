using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Web.Areas.Valoracion.Models;

namespace WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard
{
    public class Objetivo_1Step : StepViewModel
    {
        public int IdColaborador { get; set; }
        public int IdObjetivo { get; set; }
        public string NumeroObjetivo { get; set; }
        public string Objetivo { get; set; }
        public string DescObjetivo { get; set; }
        public int IdObjetivoAnioFiscal { get; set; }
        public int AnioFiscal { get; set; }
        public decimal? PonderacionObjetivo { get; set; }
        public int EstadoProceso { get; set; }
        public string DescEstadoProceso { get; set; }
        public int Perfil { get; set; }

        public string ComentarioColaborador { get; set; }
        public string ComentarioLider1 { get; set; }
        public string ComentarioLider2 { get; set; }
        public string ComentarioLiderMatricial { get; set; }
        public decimal? ValorValoracionFinal { get; set; }
        public string ValoracionFinal { get; set; }
        public string ValoracionLider1 { get; set; }
        public List<PlanificacionResultadoResponse> PlanificacionResultados { get; set; }
        public Objetivo_1Step()
        {
            Position = 0;
           
        }
    }
}
