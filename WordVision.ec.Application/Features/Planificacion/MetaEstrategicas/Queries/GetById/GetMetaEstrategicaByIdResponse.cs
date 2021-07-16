﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Queries.GetById
{
    public class GetMetaEstrategicaByIdResponse
    {
        public int Id { get; set; }
        public ICollection<MetaEstrategica> MetaEstrategicas { get; set; }
    }
}
