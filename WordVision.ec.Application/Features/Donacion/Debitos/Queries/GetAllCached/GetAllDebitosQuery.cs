using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetAllCached
{
    public class GetAllDebitosQuery : IRequest<Result<List<GetAllDebitosResponse>>>
    {
        public GetAllDebitosQuery()
        {
        }
        public class GetAllDebitosQueryHandler : IRequestHandler<GetAllDebitosQuery, Result<List<GetAllDebitosResponse>>>
        {
            private readonly IDebitoRepository _debito;
            private readonly IMapper _mapper;


            //Ejecuta el select
            public GetAllDebitosQueryHandler(IDebitoRepository debito, IMapper mapper)
            {
                _debito =debito;
                _mapper = mapper;

            }

            public async Task<Result<List<GetAllDebitosResponse>>> Handle(GetAllDebitosQuery request, CancellationToken cancellationToken)
            {
                var debitoList = await _debito.GetListAsync();
                var mappedDebitos = _mapper.Map<List<GetAllDebitosResponse>>(debitoList);

                return Result<List<GetAllDebitosResponse>>.Success(mappedDebitos);
            }
        }
    }
}
