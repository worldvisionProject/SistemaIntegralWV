using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetById
{

    public class GetProductoByIdObjetivoQuery : IRequest<Result<List<GetProductoByIdResponse>>>
    {
        public int IdObjetivoEstrategico { get; set; }
        public int IdColaborador { get; set; }

        public class GetProductoByIdObjetivoQueryHandler : IRequestHandler<GetProductoByIdObjetivoQuery, Result<List<GetProductoByIdResponse>>>
        {
            private readonly IProductoRepository _ProductoRepository;

            private readonly IMapper _mapper;

            public GetProductoByIdObjetivoQueryHandler(IProductoRepository ProductoRepository, IMapper mapper)
            {
                _ProductoRepository = ProductoRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetProductoByIdResponse>>> Handle(GetProductoByIdObjetivoQuery query, CancellationToken cancellationToken)
            {
                var meta = await _ProductoRepository.GetListByIdObjetivoAsync(query.IdObjetivoEstrategico, query.IdColaborador);
                var mappedMeta = _mapper.Map<List<GetProductoByIdResponse>>(meta);

                return Result<List<GetProductoByIdResponse>>.Success(mappedMeta);
            }
        }
    }
}
