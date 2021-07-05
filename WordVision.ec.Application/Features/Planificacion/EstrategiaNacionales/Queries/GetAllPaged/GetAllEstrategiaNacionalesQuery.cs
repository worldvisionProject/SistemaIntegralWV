using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WordVision.Application.Extensions;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetAllPaged
{
    public class GetAllEstrategiaNacionalesQuery : IRequest<PaginatedResult<GetAllEstrategiaNacionalesResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllEstrategiaNacionalesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GGetAllEstrategiaNacionalesQueryHandler : IRequestHandler<GetAllEstrategiaNacionalesQuery, PaginatedResult<GetAllEstrategiaNacionalesResponse>>
    {
        private readonly IEstrategiaNacionalRepository _repository;

        public GGetAllEstrategiaNacionalesQueryHandler(IEstrategiaNacionalRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllEstrategiaNacionalesResponse>> Handle(GetAllEstrategiaNacionalesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<EstrategiaNacional, GetAllEstrategiaNacionalesResponse>> expression = e => new GetAllEstrategiaNacionalesResponse
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
            var paginatedList = await _repository.EstrategiaNacionales
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}