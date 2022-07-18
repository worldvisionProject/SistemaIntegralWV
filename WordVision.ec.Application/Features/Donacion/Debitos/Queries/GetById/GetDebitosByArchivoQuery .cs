using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetById
{
    public class GetDebitosByArchivoQuery : IRequest<Result<int>> 
    {

        public int FormadePago { get; set; }
        public int Banco { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string Contrapartida { get; set; }
        public class GetDebitosByArchivoQueryHandler : IRequestHandler<GetDebitosByArchivoQuery, Result<int>>
        {
            private readonly IDebitoRepository _debitosRepository;



            private readonly IMapper _mapper;

            public GetDebitosByArchivoQueryHandler(IDebitoRepository debitosRepository, IMapper mapper)
            {
                _debitosRepository = debitosRepository;

                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            //Devuelve todos la información de las entidades. 
            public async Task<Result<int>> Handle(GetDebitosByArchivoQuery query, CancellationToken cancellationToken)
            {
                var debitos = await _debitosRepository.GetByPersonaAsync(query.FormadePago, query.Banco, query.Anio, query.Mes ,query.Contrapartida);
                var mappedDebitos = _mapper.Map<int>(debitos);

                return Result<int>.Success(mappedDebitos);
            }
        }
    }
}
