using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetById
{

    public class GetProductoByIdIndicadorQuery : IRequest<Result<List<GetProductoByIdResponse>>>
    {
        public int Id { get; set; }

        public class GetProductoByIdIndicadorQueryHandler : IRequestHandler<GetProductoByIdIndicadorQuery, Result<List<GetProductoByIdResponse>>>
        {
            private readonly IProductoRepository _ProductoRepository;

            private readonly IMapper _mapper;

            public GetProductoByIdIndicadorQueryHandler(IProductoRepository ProductoRepository, IMapper mapper)
            {
                _ProductoRepository = ProductoRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetProductoByIdResponse>>> Handle(GetProductoByIdIndicadorQuery query, CancellationToken cancellationToken)
            {
                var meta = await _ProductoRepository.GetListByIdAsync(query.Id);
                var mappedMeta = _mapper.Map<List<GetProductoByIdResponse>>(meta);

                return Result<List<GetProductoByIdResponse>>.Success(mappedMeta);
            }
        }
    }
}
