using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
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

    public class UpdateAbrirEdicionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int ReportaId { get; set; }
        public int IdResultado { get; set; }

        public decimal? Meta { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public decimal? Ponderacion { get; set; }
        public string DatoManual1 { get; set; }

        public string DatoManual2 { get; set; }
        public int DatoManual3 { get; set; }
        public int TipoObjetivo { get; set; }
        public int IdObjetivoAnioFiscal { get; set; }
        public ObjetivoAnioFiscal ObjetivoAnioFiscales { get; set; }
        public int Estado { get; set; }
        public string ObservacionLider { get; set; }
        //public Resultado Resultados { get; set; }
        public DateTime? FechaCumplimiento { get; set; }
        public decimal? PorcentajeCumplimiento { get; set; }
        public decimal? PonderacionResultado { get; set; }
        public ICollection<AvanceObjetivo> AvanceObjetivos { get; set; }
        public ICollection<PlanificacionHito> PlanificacionHitos { get; set; }
        public ICollection<PlanificacionComportamiento> PlanificacionComportamientos { get; set; }
        public int AnioFiscal { get; set; }
        public int Proceso { get; set; }
        public string ComentarioColaborador { get; set; }
        public string ComentarioLider1 { get; set; }
        public string ComentarioLider2 { get; set; }
        public string ComentarioLiderMatricial { get; set; }
        public decimal? ValorValoracionFinal { get; set; }
        public string ValoracionFinal { get; set; }
        public string ValoracionLider1 { get; set; }
        public class UpdateAbrirEdicionCommandCommandHandler : IRequestHandler<UpdateAbrirEdicionCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPlanificacionResultadoRepository _entidadRepository;
            private readonly ISeguimientoObjetivoRepository _entidadSeguimientoRepository;
            
            private readonly IMapper _mapper;

            public UpdateAbrirEdicionCommandCommandHandler(ISeguimientoObjetivoRepository entidadSeguimientoRepository, IPlanificacionResultadoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _entidadSeguimientoRepository = entidadSeguimientoRepository;
              
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateAbrirEdicionCommand command, CancellationToken cancellationToken)
            {
                

                    await _entidadRepository.UpdatexColaboradorAsync(command.IdColaborador, command.Estado, command.AnioFiscal);

                    await _entidadSeguimientoRepository.UpdatexTodoAsync(command.IdColaborador, command.AnioFiscal);

                    var seguimiento = new SeguimientoObjetivo();
                    seguimiento.Estado = command.Estado;
                    seguimiento.Ultimo = 1;
                    seguimiento.IdColaborador = command.IdColaborador;
                    seguimiento.AnioFiscal = command.AnioFiscal;
                    
                    
                    await _entidadSeguimientoRepository.InsertAsync(seguimiento);

                    await _unitOfWork.Commit(cancellationToken);
       
                return Result<int>.Success(command.Id);

            }
        }

    }
}
