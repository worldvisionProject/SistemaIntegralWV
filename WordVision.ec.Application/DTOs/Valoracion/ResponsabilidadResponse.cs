using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Valoracion
{
    public class ResponsabilidadResponse
    {
        public int Id { get; set; }
        public int IdResponsabilidad { get; set; }
        public string NombreResponsabilidad { get; set; }
        public string Descripcion { get; set; }
        public int EsObligatorio { get; set; }
    }
}
