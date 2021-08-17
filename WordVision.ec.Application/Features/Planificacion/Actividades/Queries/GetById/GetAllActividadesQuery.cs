﻿using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetAllCached
{
    public class GetAllActividadesQuery : IRequest<Result<List<GetActividadByIdResponse>>>
    {
        public int IdObjetivoEstrategico { get; set; }
    }

    public class GetAllActividadesQueryHandler : IRequestHandler<GetAllActividadesQuery, Result<List<GetActividadByIdResponse>>>
    {
        private readonly IActividadRepository _actividadCache;
        private readonly IMapper _mapper;

        public GetAllActividadesQueryHandler(IActividadRepository actividadCache, IMapper mapper)
        {
            _actividadCache = actividadCache;
            _mapper = mapper;

        }

        public async Task<Result<List<GetActividadByIdResponse>>> Handle(GetAllActividadesQuery request, CancellationToken cancellationToken)
        {
            var actividadList = await _actividadCache.GetListxObjetivoAsync(request.IdObjetivoEstrategico);
            var mappedactividads = _mapper.Map<List<GetActividadByIdResponse>>(actividadList);

            return Result<List<GetActividadByIdResponse>>.Success(mappedactividads);
        }
    }
}