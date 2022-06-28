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
                int reportaA = 0;
                var estructura = await _ColaboradorCache.GetByEstructuraAsync(Colaborador.Estructuras.ReportaID);
                if (estructura != null)
                {
                    reportaA = estructura.Id;
                }
               
                var mappedColaborador = _mapper.Map<GetColaboradorByIdResponse>(Colaborador);
                mappedColaborador.CodReportaA = reportaA;
                var ColaboradorReporta = await _ColaboradorCache.GetByIdAsync(reportaA);
                mappedColaborador.ApellidoMaternoReporta = ColaboradorReporta.ApellidoMaterno;
                mappedColaborador.ApellidosReporta = ColaboradorReporta.Apellidos;
                mappedColaborador.PrimerNombreReporta = ColaboradorReporta.PrimerNombre;
                mappedColaborador.SegundoNombreReporta = ColaboradorReporta.SegundoNombre;
                mappedColaborador.EmailReporta = ColaboradorReporta.Email;
                return Result<GetColaboradorByIdResponse>.Success(mappedColaborador);
            }
        }
    }
}