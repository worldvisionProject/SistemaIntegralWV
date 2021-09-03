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

namespace WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Commands.Create
{
  
    public class CreateIndicadorProductoObjetivoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Indicador { get; set; }

        public int AnioFiscal { get; set; }
        public int IdProductoObjetivo { get; set; }
        public ProductoObjetivo ProductoObjetivos { get; set; }
    }

    public class CreateIndicadorProductoObjetivoCommandHandler : IRequestHandler<CreateIndicadorProductoObjetivoCommand, Result<int>>
    {
        private readonly IIndicadorProductoObjetivoRepository _entidadRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateIndicadorProductoObjetivoCommandHandler(IIndicadorProductoObjetivoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _entidadRepository = entidadRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateIndicadorProductoObjetivoCommand request, CancellationToken cancellationToken)
        {
           
                var obj = _mapper.Map<IndicadorProductoObjetivo>(request);
                await _entidadRepository.InsertAsync(obj);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success();
        }
    }
}
