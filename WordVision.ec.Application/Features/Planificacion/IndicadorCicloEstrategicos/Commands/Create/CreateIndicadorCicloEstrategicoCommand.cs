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

namespace WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Create
{
  
    public class CreateIndicadorCicloEstrategicoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string IndicadorCiclo { get; set; }
        public int IdEstrategia { get; set; }
        public ICollection<MetaCicloEstrategico> MetaCicloEstrategicos { get; set; }
    }

    public class CreateIndicadorCicloEstrategicoCommandHandler : IRequestHandler<CreateIndicadorCicloEstrategicoCommand, Result<int>>
    {
        private readonly IIndicadorCicloEstrategicoRepository _entidadRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateIndicadorCicloEstrategicoCommandHandler(IIndicadorCicloEstrategicoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _entidadRepository = entidadRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateIndicadorCicloEstrategicoCommand request, CancellationToken cancellationToken)
        {
           
                var obj = _mapper.Map<IndicadorCicloEstrategico>(request);
                await _entidadRepository.InsertAsync(obj);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success();
        }
    }
}
