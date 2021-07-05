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

namespace WordVision.ec.Application.Features.Planificacion.IndicadorAFes.Commands.Create
{
  
    public partial class CreateIndicadorAFCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public decimal? Meta { get; set; }
        public string Entregable { get; set; }
        public int Anio { get; set; }
        public int IdIndicadorEstrategico { get; set; }
    }

    public class CreateIndicadorAFCommandHandler : IRequestHandler<CreateIndicadorAFCommand, Result<int>>
    {
        private readonly IIndicadorAFRepository _IndicadorAFRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateIndicadorAFCommandHandler(IIndicadorAFRepository IndicadorAFRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _IndicadorAFRepository = IndicadorAFRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateIndicadorAFCommand request, CancellationToken cancellationToken)
        {
            var IndicadorAF = _mapper.Map<IndicadorAF>(request);
            await _IndicadorAFRepository.InsertAsync(IndicadorAF);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(IndicadorAF.Id);
        }
    }
}
