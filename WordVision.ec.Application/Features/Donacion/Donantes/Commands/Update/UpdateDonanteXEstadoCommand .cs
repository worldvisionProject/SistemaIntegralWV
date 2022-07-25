using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Donacion.Donantes.Commands.Update
{
    public class UpdateDonanteXEstadoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int EstadoDonante { get; set; }

     

        public class UpdateDonanteXEstadoCommandHandler : IRequestHandler<UpdateDonanteXEstadoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IDonanteRepository _donanteRepository;
            private readonly IMapper _mapper;

            public UpdateDonanteXEstadoCommandHandler(IDonanteRepository donanteRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _donanteRepository = donanteRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateDonanteXEstadoCommand command, CancellationToken cancellationToken)
            {
                
                 await _donanteRepository.UpdateAsyncXEstado(command.Id, command.EstadoDonante);

                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(command.Id);
             
            }
        }


    }
}
