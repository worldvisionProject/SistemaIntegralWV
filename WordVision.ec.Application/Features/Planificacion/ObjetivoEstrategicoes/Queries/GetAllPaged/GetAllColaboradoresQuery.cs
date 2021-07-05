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

namespace WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetAllPaged
{
    public class GetAllObjetivoEstrategicoesQuery : IRequest<PaginatedResult<GetAllObjetivoEstrategicoesResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllObjetivoEstrategicoesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GGetAllObjetivoEstrategicoesQueryHandler : IRequestHandler<GetAllObjetivoEstrategicoesQuery, PaginatedResult<GetAllObjetivoEstrategicoesResponse>>
    {
        private readonly IObjetivoEstrategicoRepository _repository;

        public GGetAllObjetivoEstrategicoesQueryHandler(IObjetivoEstrategicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllObjetivoEstrategicoesResponse>> Handle(GetAllObjetivoEstrategicoesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<ObjetivoEstrategico, GetAllObjetivoEstrategicoesResponse>> expression = e => new GetAllObjetivoEstrategicoesResponse
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
            var paginatedList = await _repository.ObjetivoEstrategicoes
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}