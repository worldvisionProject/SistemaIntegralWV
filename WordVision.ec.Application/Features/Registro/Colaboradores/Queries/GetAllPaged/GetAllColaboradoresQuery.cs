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

namespace WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllPaged
{
    public class GetAllColaboradoresQuery : IRequest<PaginatedResult<GetAllColaboradoresResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllColaboradoresQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GGetAllColaboradoresQueryHandler : IRequestHandler<GetAllColaboradoresQuery, PaginatedResult<GetAllColaboradoresResponse>>
    {
        private readonly IColaboradorRepository _repository;

        public GGetAllColaboradoresQueryHandler(IColaboradorRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllColaboradoresResponse>> Handle(GetAllColaboradoresQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Colaborador, GetAllColaboradoresResponse>> expression = e => new GetAllColaboradoresResponse
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
            var paginatedList = await _repository.Colaboradores
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}