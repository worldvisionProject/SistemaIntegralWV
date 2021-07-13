using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;

using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.DashBoards.Queries.GetAllDashBoards
{
    public class GetDashBoardsQuery : IRequest<Result<GetDashBoardsResponse>>
    {
        public GetDashBoardsQuery()
        {
        }
    }

    public class GetDashBoardsQueryHandler : IRequestHandler<GetDashBoardsQuery, Result<GetDashBoardsResponse>>
    {
        //private readonly IIdentityCacheRepository _usuarioCache;
        private readonly IDocumentoCacheRepository _documentoCache;
        private readonly IRespuestaRepository _respuestaCache;
        private readonly IColaboradorCacheRepository _colaboradorCache;
       // private readonly IMapper _mapper;

        public GetDashBoardsQueryHandler(IRespuestaRepository respuestaCache, IColaboradorCacheRepository colaboradorCache, IDocumentoCacheRepository documentoCache)//, IMapper mapper)
        {
           // _usuarioCache = usuarioCache;
            _documentoCache = documentoCache;
            _respuestaCache = respuestaCache;
            _colaboradorCache = colaboradorCache;
            //_mapper = mapper;
        }

        public async Task<Result<GetDashBoardsResponse>> Handle(GetDashBoardsQuery request, CancellationToken cancellationToken)
        {
            //var usuarioList = await _usuarioCache.GetCachedListAsync();
            int numusuarios = 100;// usuarioList.Count();

            var colaboradoresList = await _colaboradorCache.GetCachedListAsync();
            int numcolaboradores = colaboradoresList.Count();

            int numDocClaves = await _respuestaCache.GetCountByIdDocumentoAsync(3);
          
            int numPoliticas = await _respuestaCache.GetCountByIdDocumentoAsync(4);
          
            GetDashBoardsResponse respuesta = new GetDashBoardsResponse();
            respuesta.porcentajeIngreso = numcolaboradores * 100 / numusuarios;
            respuesta.pendientes = numusuarios - numcolaboradores;
            respuesta.documentosClaves = numDocClaves;
            respuesta.politicas = numPoliticas;
            respuesta.totalUsuario = numusuarios;

            return Result<GetDashBoardsResponse>.Success(respuesta);
        }


    }
}
