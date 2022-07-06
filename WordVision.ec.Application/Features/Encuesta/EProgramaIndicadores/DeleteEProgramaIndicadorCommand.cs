using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProgramaIndicadores
{
    public class DeleteEProgramaIndicadorCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteEProgramaIndicadorCommandHandler : IRequestHandler<DeleteEProgramaIndicadorCommand, Result<int>>
        {
            private readonly IEProgramaIndicadorRepository _eProgramaIndicadorRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEProgramaIndicadorCommandHandler(IEProgramaIndicadorRepository eProgramaIndicadorRepository, IUnitOfWork unitOfWork)
            {
                _eProgramaIndicadorRepository = eProgramaIndicadorRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEProgramaIndicadorCommand request, CancellationToken cancellationToken)
            {
                var EProgramaIndicador = await _eProgramaIndicadorRepository.GetByIdAsync(request.Id);

                if (EProgramaIndicador == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eProgramaIndicadorRepository.DeleteAsync(EProgramaIndicador);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EProgramaIndicador.Id);
                }

            }
        }

    }
}
