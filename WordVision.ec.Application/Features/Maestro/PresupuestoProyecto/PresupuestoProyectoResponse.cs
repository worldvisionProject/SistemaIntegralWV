using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;

namespace WordVision.ec.Application.Features.Maestro.PresupuestoProyecto
{
    public class PresupuestoProyectoResponse : GenericResponse
    {
        public int Id { get; set; }

        public decimal Total { get; set; }

        public decimal CostoSoporte { get; set; }

        public decimal Nomina { get; set; }

        public decimal TI { get; set; }

        public decimal Administracion { get; set; }

        public decimal LineamientosOnAdmistrativos { get; set; }

        public decimal LineamientosOnOperativos { get; set; }

        public decimal TechoPresupuestario { get; set; }

        public int IdProgramaArea { get; set; }
        public ProgramaAreaResponse ProgramaArea { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }
    }
}
