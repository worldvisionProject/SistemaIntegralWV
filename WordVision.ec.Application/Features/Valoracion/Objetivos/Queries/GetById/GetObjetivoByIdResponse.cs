using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById
{
    public class GetObjetivoByIdResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Estado { get; set; }
        public ICollection<ObjetivoAnioFiscal> ObjetivoAnioFiscales { get; set; }
    }
}
