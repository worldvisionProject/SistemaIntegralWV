using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EProgramaViewModel
    {
        public string Id { get; set; }
        [Display(Name = "PA")]
        public string pa_nombre { get; set; }

    }
}
