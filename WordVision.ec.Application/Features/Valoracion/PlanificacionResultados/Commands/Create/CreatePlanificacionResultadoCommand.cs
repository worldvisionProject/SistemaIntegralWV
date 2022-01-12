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
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Commands.Create
{
    public partial class CreatePlanificacionResultadoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdResultado { get; set; }

        public decimal? Meta { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public decimal? Ponderacion { get; set; }
        public Resultado Resultados { get; set; }
    }
    public class CreatePlanificacionResultadoCommandHandler : IRequestHandler<CreatePlanificacionResultadoCommand, Result<int>>
    {
        private readonly IPlanificacionResultadoRepository _entidadRepository;
        
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreatePlanificacionResultadoCommandHandler(IPlanificacionResultadoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _entidadRepository = entidadRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePlanificacionResultadoCommand request, CancellationToken cancellationToken)
        {
            var objEntidad = _mapper.Map<PlanificacionResultado>(request);
            await _entidadRepository.InsertAsync(objEntidad);

            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(objEntidad.Id);
        }

    }
}
