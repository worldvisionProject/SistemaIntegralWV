using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class EstrategiaNacionalViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
       
        public string MetaRegional { get; set; }
        public string MetaNacional { get; set; }
        public int IdEmpresa { get; set; }
        public string Estado { get; set; }

        public string DescEstado { get; set; }

        public List<SelectList> EstadoList { get; set; }

        public virtual List<GestionViewModel> Gestiones { get; set; }
        public virtual List<ObjetivoEstrategicoViewModel> ObjetivoEstrategicos { get; set; }

        public string AnioGestion { get; set; }
        public string DescGestion { get; set; }
        public string EstadoGestion { get; set; }


        public string DescripcionO { get; set; }
        public string CategoriaO { get; set; }
        public string AreaPrioridadO { get; set; }
        public string DimensionO { get; set; }
        public int CargoResponsableO { get; set; }
    }

    public class EstrategiaNacionalList
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

}
