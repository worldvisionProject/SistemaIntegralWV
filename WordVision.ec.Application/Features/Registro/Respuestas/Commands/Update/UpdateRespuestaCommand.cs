using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Respuestas.Commands.Update
{
    public class UpdateRespuestaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdDocumento { get; set; }
        public int IdPregunta { get; set; }
        public string DescRespuesta { get; set; }

        public class UpdateRespuestaCommandHandler : IRequestHandler<UpdateRespuestaCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRespuestaRepository _respuestaRepository;

            public UpdateRespuestaCommandHandler(IRespuestaRepository respuestaRepository, IUnitOfWork unitOfWork)
            {
                _respuestaRepository = respuestaRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateRespuestaCommand command, CancellationToken cancellationToken)
            {
                var respuesta = await _respuestaRepository.GetByIdColaboradorAsync(command.IdColaborador, command.IdDocumento, command.IdPregunta);

                if (respuesta == null)
                {
                    return Result<int>.Fail($"Respuesta no encontrado.");
                }
                else
                {
                    respuesta.IdColaborador = command.IdColaborador == 0 ? respuesta.IdColaborador : command.IdColaborador;
                    respuesta.IdPregunta = command.IdPregunta == 0 ? respuesta.IdPregunta : command.IdPregunta;
                    respuesta.IdDocumento = command.IdDocumento == 0 ? respuesta.IdDocumento : command.IdDocumento;
                    respuesta.DescRespuesta = command.DescRespuesta;//?? respuesta.DescRespuesta;

                    await _respuestaRepository.UpdateAsync(respuesta);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(respuesta.Id);
                }
            }
        }
    }
}
