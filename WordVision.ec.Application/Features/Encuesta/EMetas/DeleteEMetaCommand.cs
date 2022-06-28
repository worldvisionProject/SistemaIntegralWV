using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EMetas
{
    public class DeleteEMetaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteEMetaCommandHandler : IRequestHandler<DeleteEMetaCommand, Result<int>>
        {
            private readonly IEMetaRepository _eMetaRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEMetaCommandHandler(IEMetaRepository eMetaRepository, IUnitOfWork unitOfWork)
            {
                _eMetaRepository = eMetaRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEMetaCommand request, CancellationToken cancellationToken)
            {
                var EMeta = await _eMetaRepository.GetByIdAsync(request.Id);

                if (EMeta == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eMetaRepository.DeleteAsync(EMeta);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EMeta.Id);
                }

            }
        }

    }
}
