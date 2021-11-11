using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Ponentes.Commands.Update
{
    public class UpdatePonenteCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string NombreApellido { get; set; }
        public string Cargo { get; set; }

        public string Perfil { get; set; }
        public string Tema { get; set; }

        public int IdComunicacion { get; set; }


        public class UpdatePonenteCommandHandler : IRequestHandler<UpdatePonenteCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPonenteRepository _entidadRepository;
          
            private readonly IMapper _mapper;

            public UpdatePonenteCommandHandler(IPonenteRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
            
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdatePonenteCommand command, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(command.Id);

                if (obj == null)
                {
                    return Result<int>.Fail($"Ponente no encontrado.");
                }

                obj.NombreApellido = command.NombreApellido;
                obj.Cargo = command.Cargo;
                obj.Perfil = command.Perfil;
                obj.Tema = command.Tema;
              
               
                await _entidadRepository.UpdateAsync(obj);


                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(obj.Id);

            }
        }
    }
}
