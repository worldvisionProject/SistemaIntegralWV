﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetById
{
    public class GetTiposIndicadorByIdResponse
    {
        public int Id { get; set; }
        public int CodigoTipoIndicador { get; set; }
       public string CodigoIndicador { get; set; }
        public string Descripcion { get; set; }
    }
}