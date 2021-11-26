using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById
{
    public class GetColaboradorByIdQuery : IRequest<Result<GetColaboradorByIdResponse>>
    {
        public int Id { get; set; }

        public class GetColaboradorByIdQueryHandler : IRequestHandler<GetColaboradorByIdQuery, Result<GetColaboradorByIdResponse>>
        {
            private readonly IColaboradorRepository _ColaboradorCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetColaboradorByIdQueryHandler(IColaboradorRepository ColaboradorCache, IMapper mapper)
            {
                _ColaboradorCache = ColaboradorCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetColaboradorByIdResponse>> Handle(GetColaboradorByIdQuery query, CancellationToken cancellationToken)
            {
                var Colaborador = await _ColaboradorCache.GetByIdAsync(query.Id);
                var mappedColaborador = _mapper.Map<GetColaboradorByIdResponse>(Colaborador);

                return Result<GetColaboradorByIdResponse>.Success(mappedColaborador);
            }
        }
    }
}