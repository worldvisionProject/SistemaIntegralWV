using System;
using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Registro.Terceros.Queries.GetById
{
    public class GetByIdResponse
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Identificacion { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public DateTime? FecNacimiento { get; set; }
        public string? Genero { get; set; }
        public DateTime? VigDesde { get; set; }
        public DateTime? VigHasta { get; set; }

        public string CodigoArea { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public byte[] ImageCedula { get; set; }
        public virtual ICollection<FormularioTercero> FormularioTerceros { get; set; }
    }
}
