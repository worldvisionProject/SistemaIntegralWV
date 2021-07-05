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

namespace WordVision.ec.Application.Features.Registro.Formularios.Queries.GetAllPaged
{
    public class GetAllFormulariosQuery : IRequest<PaginatedResult<GetAllFormulariosResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllFormulariosQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllFormulariosQueryHandler : IRequestHandler<GetAllFormulariosQuery, PaginatedResult<GetAllFormulariosResponse>>
    {
        private readonly IFormularioRepository _repository;

        public GetAllFormulariosQueryHandler(IFormularioRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllFormulariosResponse>> Handle(GetAllFormulariosQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Formulario, GetAllFormulariosResponse>> expression = e => new GetAllFormulariosResponse
            {
                Id = e.Id,
               
               
            };
            var paginatedList = await _repository.Formularios
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}