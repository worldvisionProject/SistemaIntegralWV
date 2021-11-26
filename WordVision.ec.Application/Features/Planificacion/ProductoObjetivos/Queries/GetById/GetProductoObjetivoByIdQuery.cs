using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Queries.GetById
{


    public partial class GetProductoObjetivoByIdQuery : IRequest<Result<GetProductoObjetivoByIdResponse>>
    {
        public int Id { get; set; }

        public class GetProductoObjetivoByIdQueryHandler : IRequestHandler<GetProductoObjetivoByIdQuery, Result<GetProductoObjetivoByIdResponse>>
        {
            private readonly IProductoObjetivoRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetProductoObjetivoByIdQueryHandler(IProductoObjetivoRepository entidadRepository, IMapper mapper)
            {

                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetProductoObjetivoByIdResponse>> Handle(GetProductoObjetivoByIdQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(query.Id);
                var mappedObj = _mapper.Map<GetProductoObjetivoByIdResponse>(obj);

                return Result<GetProductoObjetivoByIdResponse>.Success(mappedObj);
            }
        }
    }
}
