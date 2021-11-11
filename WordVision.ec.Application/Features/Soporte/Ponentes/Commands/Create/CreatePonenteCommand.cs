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
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Ponentes.Commands.Create
{
    public partial class CreatePonenteCommand : IRequest<Result<int>>
    {
        public string NombreApellido { get; set; }
        public string Cargo { get; set; }

        public string Perfil { get; set; }
        public string Tema { get; set; }

        public int IdComunicacion { get; set; }
    }


    public class CreatePonenteCommandHandler : IRequestHandler<CreatePonenteCommand, Result<int>>
    {
        private readonly IPonenteRepository _entidadRepository;
       
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreatePonenteCommandHandler(IPonenteRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _entidadRepository = entidadRepository;
                    _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePonenteCommand request, CancellationToken cancellationToken)
        {


            var entidad = _mapper.Map<Ponente>(request);
            await _entidadRepository.InsertAsync(entidad);

        
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(entidad.Id);
        }

    }
}
