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

namespace WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetAllPaged
{
    public class GetAllGestionesQuery : IRequest<PaginatedResult<GetAllGestionesResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllGestionesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GGetAllGestionesQueryHandler : IRequestHandler<GetAllGestionesQuery, PaginatedResult<GetAllGestionesResponse>>
    {
        private readonly IGestionRepository _repository;

        public GGetAllGestionesQueryHandler(IGestionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllGestionesResponse>> Handle(GetAllGestionesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Gestion, GetAllGestionesResponse>> expression = e => new GetAllGestionesResponse
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
            var paginatedList = await _repository.Gestiones
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}