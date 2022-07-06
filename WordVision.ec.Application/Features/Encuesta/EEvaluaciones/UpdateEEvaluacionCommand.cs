using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EEvaluaciones
{
    public class UpdateEEvaluacionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string eva_Nombre { get; set; }
        public DateTime eva_Desde { get; set; }
        public DateTime eva_Hasta { get; set; }


        public class UpdateEEvaluacionCommandHandler : IRequestHandler<UpdateEEvaluacionCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEEvaluacionRepository _eEvaluacionRepository;
            private readonly IMapper _mapper;

            public UpdateEEvaluacionCommandHandler(IEEvaluacionRepository eEvaluacionRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _eEvaluacionRepository = eEvaluacionRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEEvaluacionCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EEvaluacion = await _eEvaluacionRepository.GetByIdAsync(request.Id);

                if (EEvaluacion == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Listado de campos que se va a actualizar con los nuevos datos traidos en request
                    EEvaluacion.eva_Nombre = request.eva_Nombre;
                    EEvaluacion.eva_Desde = request.eva_Desde;
                    EEvaluacion.eva_Hasta = request.eva_Hasta;

                    //Actualizamos el registro en la base de datos
                    await _eEvaluacionRepository.UpdateAsync(EEvaluacion);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EEvaluacion.Id);
                }
            }
        }



    }
}
