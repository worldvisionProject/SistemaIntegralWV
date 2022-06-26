using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProgramas
{
    public class DeleteEProgramaCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }

        public class DeleteEProgramaCommandHandler : IRequestHandler<DeleteEProgramaCommand, Result<int>>
        {
            private readonly IEProgramaRepository _eProgramaRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEProgramaCommandHandler(IEProgramaRepository eProgramaRepository, IUnitOfWork unitOfWork)
            {
                _eProgramaRepository = eProgramaRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEProgramaCommand request, CancellationToken cancellationToken)
            {
                var EPrograma = await _eProgramaRepository.GetByIdAsync(request.Id);

                if (EPrograma == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eProgramaRepository.DeleteAsync(EPrograma);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EPrograma.Id);
                }

            }
        }

    }
}
