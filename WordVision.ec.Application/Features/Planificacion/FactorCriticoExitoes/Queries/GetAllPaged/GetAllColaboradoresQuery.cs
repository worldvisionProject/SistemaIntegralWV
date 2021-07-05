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

namespace WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetAllPaged
{
    public class GetAllFactorCriticoExitoesQuery : IRequest<PaginatedResult<GetAllFactorCriticoExitoesResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllFactorCriticoExitoesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GGetAllFactorCriticoExitoesQueryHandler : IRequestHandler<GetAllFactorCriticoExitoesQuery, PaginatedResult<GetAllFactorCriticoExitoesResponse>>
    {
        private readonly IFactorCriticoExitoRepository _repository;

        public GGetAllFactorCriticoExitoesQueryHandler(IFactorCriticoExitoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllFactorCriticoExitoesResponse>> Handle(GetAllFactorCriticoExitoesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<FactorCriticoExito, GetAllFactorCriticoExitoesResponse>> expression = e => new GetAllFactorCriticoExitoesResponse
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
            var paginatedList = await _repository.FactorCriticoExitoes
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}