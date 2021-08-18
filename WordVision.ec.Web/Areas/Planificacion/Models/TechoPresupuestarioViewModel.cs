using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class TechoPresupuestarioViewModel
    {
        public int Id { get; set; }
        public string CodigoCC { get; set; }
        public string DescripcionCC { get; set; }

        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Techo { get; set; }

        //campos no de entidad
        public SelectList CentroCostosList { get; set; }
    }
}
