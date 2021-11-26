using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Queries.GetById
{


    public partial class GetProductoObjetivoByIdObjetivoQuery : IRequest<Result<List<GetProductoObjetivoByIdResponse>>>
    {
        public int IdObjetivo { get; set; }

        public class GetProductoObjetivoByIdObjetivoQueryHandler : IRequestHandler<GetProductoObjetivoByIdObjetivoQuery, Result<List<GetProductoObjetivoByIdResponse>>>
        {
            private readonly IProductoObjetivoRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetProductoObjetivoByIdObjetivoQueryHandler(IProductoObjetivoRepository entidadRepository, IMapper mapper)
            {

                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetProductoObjetivoByIdResponse>>> Handle(GetProductoObjetivoByIdObjetivoQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdObjetivoAsync(query.IdObjetivo);
                var mappedObj = _mapper.Map<List<GetProductoObjetivoByIdResponse>>(obj);

                return Result<List<GetProductoObjetivoByIdResponse>>.Success(mappedObj);
            }
        }
    }
}
