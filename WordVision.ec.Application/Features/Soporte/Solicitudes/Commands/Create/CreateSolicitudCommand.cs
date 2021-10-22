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
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Create
{
  
    public class CreateSolicitudCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public int IdAsignadoA { get; set; }
        public string AsignadoA { get; set; }
        public int Estado { get; set; }
        public string DescripcionSolucion { get; set; }
        public string ObservacionesSolucion { get; set; }
        public string ComentarioSatisfaccion { get; set; }
        public int EstadoSatisfaccion { get; set; }
        public ICollection<EstadosSolicitud> EstadosSolicitudes { get; set; }

        public Mensajeria Mensajerias { get; set; }

        public Comunicacion Comunicaciones { get; set; }
        public int IdColaborador { get; set; }
      
    }

    public class CreateSolicitudCommandHandler : IRequestHandler<CreateSolicitudCommand, Result<int>>
    {
        private readonly ISolicitudRepository _entidadRepository;
        private readonly IMensajeriaRepository _entidadRepositoryM;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateSolicitudCommandHandler(ISolicitudRepository entidadRepository, IMensajeriaRepository entidadRepositoryM, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _entidadRepository = entidadRepository;
            _entidadRepositoryM = entidadRepositoryM;

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateSolicitudCommand request, CancellationToken cancellationToken)
        {
           
                var obj = _mapper.Map<Solicitud>(request);
                await _entidadRepository.InsertAsync(obj);
            if (request.Mensajerias!=null)
            {
                var objMensajeria = _mapper.Map<Mensajeria>(request.Mensajerias);
                objMensajeria.IdSolicitud = obj.Id;
                await _entidadRepositoryM.InsertAsync(objMensajeria);
            }


            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(obj.Id);
        }
    }
}
