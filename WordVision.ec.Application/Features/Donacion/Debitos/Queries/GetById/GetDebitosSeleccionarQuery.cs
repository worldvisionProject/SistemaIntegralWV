using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetById
{
    public class GetDebitosSeleccionarQuery : IRequest<Result<List<DebitoResponse>>>
    {


        public int Id { get; set; }
        public int formaPago { get; set; }
        public int bancoTarjeta { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public class GetDebitosSeleccionarQueryHandler : IRequestHandler<GetDebitosSeleccionarQuery, Result<List<DebitoResponse>>>
        {
            private readonly IDebitoRepository _debitosRepository;



            private readonly IMapper _mapper;

            public GetDebitosSeleccionarQueryHandler(IDebitoRepository debitosRepository, IMapper mapper)
            {
                _debitosRepository = debitosRepository;

                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            //Devuelve todos la información de las entidades. 
            public async Task<Result<List<DebitoResponse>>> Handle(GetDebitosSeleccionarQuery query, CancellationToken cancellationToken)
            {
                var debitos = await _debitosRepository.GetListDebitosSeleccionarAsync(query.formaPago,query.bancoTarjeta,query.anio,query.mes);

                var mappedDebitos = _mapper.Map<List<DebitoResponse>>(debitos);

                return Result<List<DebitoResponse>>.Success(mappedDebitos);
            }
        }
    }
}
