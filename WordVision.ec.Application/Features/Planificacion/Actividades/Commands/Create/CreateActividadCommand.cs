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

namespace WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Create
{
    public partial class CreateActividadCommand : IRequest<Result<int>>
    {
        public string DescripcionActividad { get; set; }
        public string Entregable { get; set; }
        public int IdCargoResponsable { get; set; }
        public DateTime Plazo { get; set; }
        public decimal? Ponderacion { get; set; }
        public string SNPresupuesto { get; set; }
        public decimal? TechoPresupuestoCC { get; set; }
        public decimal? Saldo { get; set; }

        public int IdIndicadorPOA { get; set; }
        public ICollection<Recurso> Recursos { get; set; }
    }
    public class CreateActividadCommandHandler : IRequestHandler<CreateActividadCommand, Result<int>>
    {
        private readonly IActividadRepository _actividadRepository;
        private readonly IRecursoRepository _recursoRepository;

        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateActividadCommandHandler(IActividadRepository actividadRepository, IRecursoRepository recursoRepository,  IUnitOfWork unitOfWork, IMapper mapper)
        {
            _actividadRepository = actividadRepository;
            _recursoRepository = recursoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateActividadCommand request, CancellationToken cancellationToken)
        {
            var actividad = _mapper.Map<Actividad>(request);
            await _actividadRepository.InsertAsync(actividad);

            foreach (var a in request.Recursos)
            {
                var recurso = _mapper.Map<Recurso>(a);
                recurso.IdActividad = actividad.Id;
                await _recursoRepository.InsertAsync(recurso);
            }

            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(actividad.Id);
        }
    }

}
