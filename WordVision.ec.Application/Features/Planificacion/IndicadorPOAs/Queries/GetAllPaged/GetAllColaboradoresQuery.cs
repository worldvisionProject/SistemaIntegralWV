using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WordVision.Application.Extensions;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllPaged
{
    public class GetAllIndicadorEstrategicoesQuery : IRequest<PaginatedResult<GetAllIndicadorEstrategicoesResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllIndicadorEstrategicoesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GGetAllIndicadorEstrategicoesQueryHandler : IRequestHandler<GetAllIndicadorEstrategicoesQuery, PaginatedResult<GetAllIndicadorEstrategicoesResponse>>
    {
        private readonly IIndicadorEstrategicoRepository _repository;

        public GGetAllIndicadorEstrategicoesQueryHandler(IIndicadorEstrategicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllIndicadorEstrategicoesResponse>> Handle(GetAllIndicadorEstrategicoesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<IndicadorEstrategico, GetAllIndicadorEstrategicoesResponse>> expression = e => new GetAllIndicadorEstrategicoesResponse
            {
                Id = e.Id,
                Apellidos = e.Apellidos,
                PrimerNombre = e.PrimerNombre,
                SegundoNombre = e.SegundoNombre,
                Identificacion = e.Identificacion,
                Cargo=e.Cargo,
                Area=e.Area,
                LugarTrabajo=e.LugarTrabajo
            };
            var paginatedList = await _repository.IndicadorEstrategicoes
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}