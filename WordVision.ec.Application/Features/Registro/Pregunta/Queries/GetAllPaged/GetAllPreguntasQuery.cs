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

namespace WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetAllPaged
{
    public class GetAllPreguntasQuery : IRequest<PaginatedResult<GetAllPreguntasResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPreguntasQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPreguntasQueryHandler : IRequestHandler<GetAllPreguntasQuery, PaginatedResult<GetAllPreguntasResponse>>
    {
        private readonly IPreguntasRepository _repository;

        public GetAllPreguntasQueryHandler(IPreguntasRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllPreguntasResponse>> Handle(GetAllPreguntasQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Documento, GetAllPreguntasResponse>> expression = e => new GetAllPreguntasResponse
            {
                Id = e.Id,
                Titulo = e.Titulo,
                Descripcion = e.Descripcion,
                DescripcionAcepto = e.DescripcionAcepto,
                Estado = e.Estado
               
            };
            var paginatedList = await _repository.Documentos
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}