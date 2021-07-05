using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Commands.Create
{
  
    public partial class CreateEstrategiaNacionalCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Programa { get; set; }
        public string Cwbo { get; set; }
        public string MetaRegional { get; set; }
        public string MetaNacional { get; set; }
        public int IdEmpresa { get; set; }
        public string Estado { get; set; }

    }

    public class CreateEstrategiaNacionalCommandHandler : IRequestHandler<CreateEstrategiaNacionalCommand, Result<int>>
    {
        private readonly IEstrategiaNacionalRepository _EstrategiaNacionalRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateEstrategiaNacionalCommandHandler(IEstrategiaNacionalRepository EstrategiaNacionalRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _EstrategiaNacionalRepository = EstrategiaNacionalRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateEstrategiaNacionalCommand request, CancellationToken cancellationToken)
        {
            var EstrategiaNacional = _mapper.Map<EstrategiaNacional>(request);
            await _EstrategiaNacionalRepository.InsertAsync(EstrategiaNacional);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(EstrategiaNacional.Id);
        }
    }
}
