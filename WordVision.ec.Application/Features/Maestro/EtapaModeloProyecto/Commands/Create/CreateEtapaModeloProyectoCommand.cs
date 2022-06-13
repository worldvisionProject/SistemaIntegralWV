using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Create
{
    public class CreateEtapaModeloProyectoCommand : EtapaModeloProyectoResponse, IRequest<Result<int>>
    {
    }

    public class CreateEtapaModeloProyectoCommandHandler : IRequestHandler<CreateEtapaModeloProyectoCommand, Result<int>>
    {
        private readonly IEtapaModeloProyectoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateEtapaModeloProyectoCommandHandler(IEtapaModeloProyectoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateEtapaModeloProyectoCommand request, CancellationToken cancellationToken)
        {
            var etapaModeloProyecto = _mapper.Map<Domain.Entities.Maestro.EtapaModeloProyecto>(request);
            await _repository.InsertAsync(etapaModeloProyecto);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(etapaModeloProyecto.Id);
        }
    }
}
