using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetById
{
    public class GetExisteCargaRespuestaQuery : IRequest<Result<int>>
    {

        public int formaPago { get; set; }
        public int bancoTarjeta { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }

        public class GetExisteCargaRespuestaHandler : IRequestHandler<GetExisteCargaRespuestaQuery, Result<int>>
        {
            private readonly IDebitoRepository _debitosRepository;



            private readonly IMapper _mapper;

            public GetExisteCargaRespuestaHandler(IDebitoRepository debitosRepository, IMapper mapper)
            {
                _debitosRepository = debitosRepository;

                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            //Devuelve todos la información de las entidades. 
            public async Task<Result<int>> Handle(GetExisteCargaRespuestaQuery query, CancellationToken cancellationToken)
            {
              
                var exiten = await _debitosRepository.GetByExisteCargaRespuestaAsync(query.formaPago, query.bancoTarjeta, query.anio, query.mes);
                return Result<int>.Success(exiten);
            }
        }
    }
}
