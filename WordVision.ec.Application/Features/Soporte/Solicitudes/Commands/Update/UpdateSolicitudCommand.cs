using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update
{
   
    public class UpdateSolicitudCommand : IRequest<Result<int>>
    {
		public int Id { get; set; }
        public string TipoSistema { get; set; }

        //Estructura de Mensajeria

        public int Solicitante { get; set; }

        public string PersonaaContactar { get; set; }

        public string Telefono { get; set; }
        public string Celular { get; set; }

        public DateTime FechaRequerida { get; set; }

        public byte[] Archivo { get; set; }
        public int TiposTramites { get; set; }

        public string DescripcionTramite { get; set; }

        public string Direccion { get; set; }

        public string InformacionAdicional { get; set; }

        public int IdAsignadoA { get; set; }


        public int Estado { get; set; }

        public string DescripcionSolucion { get; set; }


        public string ObservacionesSolucion { get; set; }
        public string ComentarioSatisfaccion { get; set; }
        public int EstadoSatisfaccion { get; set; }


        //Estructura de Comunicaciones

        public int NumSolicitud { get; set; }

        public int TipoSolicitud { get; set; }

        public int AreaSolicitante { get; set; }

        public DateTime FechaSolicitud { get; set; }
        public decimal Presupuesto { get; set; }
        public string DisponibilidadPresupuestaria { get; set; }
        public string AutorizacióndelLíderInmediato { get; set; }
        public string Informativo { get; set; }

        public int Responsable { get; set; }

        public int NumdeTicketTI { get; set; }

        public string NombredelEvento { get; set; }
        public DateTime FechadelEvento { get; set; }
        public DateTime HoradelEvento { get; set; }

        public string LugarEvento { get; set; }
        public string ObjetivodelEvento { get; set; }
        public string PúblicoObjetivo { get; set; }
        public int NúmerodeParticipantesEstimado { get; set; }
        public bool TransmisiónVirtual { get; set; }
        public string GuionMinuto_a_MinutoEvento { get; set; }
        public string LogosSociosInvolucrados { get; set; }
        public string PersonasAutoridadesAsistirán { get; set; }
        public string PersonalWVInvolucrado { get; set; }
        public string SituacionesInteresParaWorldVision { get; set; }

        public string SociosQuienesInteractuar { get; set; }
        public DateTime FechaRequiereProducto { get; set; }
        public string DescripciónProducto { get; set; }
        public string ObjetivoProducto { get; set; }
        public string PublicoObjetivo { get; set; }
        public string MensajeClave { get; set; }
        public string DocumentoBasedeTrabajo { get; set; }
        public class UpdateSolicitudeCommandHandler : IRequestHandler<UpdateSolicitudCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ISolicitudRepository _entidadRepository;
            private readonly IEstadosSolicitudRepository _entidadRepositoryE;
            private readonly IColaboradorRepository _entidadRepositoryC;
            private readonly IMapper _mapper;

            public UpdateSolicitudeCommandHandler(IEstadosSolicitudRepository entidadRepositoryE,IColaboradorRepository entidadRepositoryC,ISolicitudRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _entidadRepositoryC = entidadRepositoryC;
                _entidadRepositoryE = entidadRepositoryE;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateSolicitudCommand command, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(command.Id);

                if (obj == null)
                {
                    return Result<int>.Fail($"Solicitude no encontrado.");
                }

                var objColaborador = await _entidadRepositoryC.GetByIdAsync(command.IdAsignadoA);
                var mappedColaborador = _mapper.Map<GetColaboradorByIdResponse>(objColaborador);

                obj.IdAsignadoA = command.IdAsignadoA==0? obj.IdAsignadoA: command.IdAsignadoA;
                obj.AsignadoA = command.IdAsignadoA == 0 ? obj.AsignadoA: mappedColaborador.Apellidos + " " + mappedColaborador.ApellidoMaterno + " " + mappedColaborador.PrimerNombre + " " + mappedColaborador.SegundoNombre;
                obj.ComentarioSatisfaccion = command.ComentarioSatisfaccion ?? obj.ComentarioSatisfaccion;
                obj.EstadoSatisfaccion = command.EstadoSatisfaccion;
                obj.Estado = command.Estado;
                obj.ObservacionesSolucion = command.ObservacionesSolucion?? obj.ObservacionesSolucion;
                obj.DescripcionSolucion = command.DescripcionSolucion ?? obj.DescripcionSolucion;

                EstadosSolicitud e = new()
                {
                    IdSolicitud = command.Id,
                    Estado = command.Estado
                };

                var objEstados = _mapper.Map<EstadosSolicitud>(e);
                await _entidadRepositoryE.InsertAsync(objEstados);


                await _entidadRepository.UpdateAsync(obj);


                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(obj.Id);

            }
        }

    }
}
