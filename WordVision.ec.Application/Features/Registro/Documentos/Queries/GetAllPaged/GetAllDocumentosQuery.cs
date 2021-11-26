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

namespace WordVision.ec.Application.Features.Registro.Documentos.Queries.GetAllPaged
{
    public class GetAllDocumentosQuery : IRequest<PaginatedResult<GetAllDocumentosResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllDocumentosQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllDocumentosQueryHandler : IRequestHandler<GetAllDocumentosQuery, PaginatedResult<GetAllDocumentosResponse>>
    {
        private readonly IDocumentoRepository _repository;

        public GetAllDocumentosQueryHandler(IDocumentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllDocumentosResponse>> Handle(GetAllDocumentosQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Documento, GetAllDocumentosResponse>> expression = e => new GetAllDocumentosResponse
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