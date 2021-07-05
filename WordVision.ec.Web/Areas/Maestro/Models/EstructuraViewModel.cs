using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class EstructuraViewModel
    {
        public int Id { get; set; }
        public string Designacion { get; set; }
        public int ReportaID { get; set; }
        public int Estado { get; set; }
        public virtual ICollection<ColaboradorViewModel> Colaboradores { get; set; }
    }
}
