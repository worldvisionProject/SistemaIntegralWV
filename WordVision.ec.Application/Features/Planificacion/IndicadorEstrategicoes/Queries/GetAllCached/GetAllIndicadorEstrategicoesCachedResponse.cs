﻿using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached
{
    public class GetAllIndicadorEstrategicoesCachedResponse
    {
        public int Id { get; set; }
        public string IndicadorResultado { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public int? UnidadMedida { get; set; }
        public decimal? LineaBase { get; set; }
        public decimal? Meta { get; set; }
        public int IdFactorCritico { get; set; }
        public int Codigo { get; set; }
        public int Tipo { get; set; }
        public int Actor { get; set; }
        public int TipoMeta { get; set; }
        public int? Seleccionado { get; set; }
        public ICollection<IndicadorVinculadoE> IndicadorVinculadoEs { get; set; }
    }
}