using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetById
{
    public class GetDebitosByIdQuery : IRequest<Result<GetDebitosByIdResponse>>
    {


        public int Id { get; set; }

        public class GetDebitosByIdQueryHandler : IRequestHandler<GetDebitosByIdQuery, Result<GetDebitosByIdResponse>>
        {
            private readonly IDebitoRepository _debitosRepository;



            private readonly IMapper _mapper;

            public GetDebitosByIdQueryHandler(IDebitoRepository debitosRepository, IMapper mapper)
            {
                _debitosRepository = debitosRepository;

                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            //Devuelve todos la información de las entidades. 
            public async Task<Result<GetDebitosByIdResponse>> Handle(GetDebitosByIdQuery query, CancellationToken cancellationToken)
            {
                var debitos = await _debitosRepository.GetByIdAsync(query.Id);


                var mappedDebitos = _mapper.Map<GetDebitosByIdResponse>(debitos);

                return Result<GetDebitosByIdResponse>.Success(mappedDebitos);
            }
        }
    }
}
