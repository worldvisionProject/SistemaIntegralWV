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

namespace WordVision.ec.Application.Features.Planificacion.IndicadorAFes.Queries.GetAllPaged
{
    public class GetAllIndicadorAFesQuery : IRequest<PaginatedResult<GetAllIndicadorAFesResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllIndicadorAFesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GGetAllIndicadorAFesQueryHandler : IRequestHandler<GetAllIndicadorAFesQuery, PaginatedResult<GetAllIndicadorAFesResponse>>
    {
        private readonly IIndicadorAFRepository _repository;

        public GGetAllIndicadorAFesQueryHandler(IIndicadorAFRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllIndicadorAFesResponse>> Handle(GetAllIndicadorAFesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<IndicadorAF, GetAllIndicadorAFesResponse>> expression = e => new GetAllIndicadorAFesResponse
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
            var paginatedList = await _repository.IndicadorAFes
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}