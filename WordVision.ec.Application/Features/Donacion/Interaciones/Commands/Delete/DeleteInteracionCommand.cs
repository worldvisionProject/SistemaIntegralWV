using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Donacion.Interaciones.Commands.Delete
{
    public  class DeleteInteracionCommand :  IRequest<Result<int>>
    {
        public int Id { get; set; }

    public class DeleteInteracionCommandHandler : IRequestHandler<DeleteInteracionCommand, Result<int>>
    {
        private readonly IDonanteRepository _interacionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInteracionCommandHandler(IDonanteRepository interacionRepository, IUnitOfWork unitOfWork)
        {
                _interacionRepository = interacionRepository;
            _unitOfWork = unitOfWork;
        }


            public async Task<Result<int>> Handle(DeleteInteracionCommand command, CancellationToken cancellationToken)
            {
                var interacion = await _interacionRepository.GetByIdAsync(command.Id);
                await _interacionRepository.DeleteAsync(interacion);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(interacion.Id);
            }
        }
        }
}
