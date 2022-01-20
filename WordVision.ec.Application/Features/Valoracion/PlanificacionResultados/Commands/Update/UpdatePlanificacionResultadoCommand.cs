using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Soporte;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update
{

    public class UpdatePlanificacionResultadoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdResultado { get; set; }

        public decimal? Meta { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public decimal? Ponderacion { get; set; }
        public string DatoManual1 { get; set; }

        public string DatoManual2 { get; set; }
        public int DatoManual3 { get; set; }
        public Resultado Resultados { get; set; }
        public class UpdatePlanificacionResultadoCommandHandler : IRequestHandler<UpdatePlanificacionResultadoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPlanificacionResultadoRepository _entidadRepository;
          
            private readonly IMapper _mapper;

            public UpdatePlanificacionResultadoCommandHandler(IPlanificacionResultadoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                 _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdatePlanificacionResultadoCommand command, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(command.Id);

                if (obj == null)
                {
                    return Result<int>.Fail($"PlanificacionResultado no encontrado.");
                }

                obj.Meta = command.Meta;
                obj.FechaInicio = command.FechaInicio;
                obj.FechaFin = command.FechaFin;
                obj.Ponderacion = command.Ponderacion;
                obj.DatoManual1 = command.DatoManual1;
                obj.DatoManual2 = command.DatoManual2;
                obj.DatoManual3 = command.DatoManual3;

                await _entidadRepository.UpdateAsync(obj);


                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(obj.Id);

            }
        }

    }
}
