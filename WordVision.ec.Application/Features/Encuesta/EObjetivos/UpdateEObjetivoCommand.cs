using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EObjetivos
{
    public class UpdateEObjetivoCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string obj_Nombre { get; set; }

        public string obj_Nivel { get; set; }
        public string obj_Outcome { get; set; }
        public string obj_Output { get; set; }
        public string obj_Activity { get; set; }

        public int EProyectoId { get; set; }


        public class UpdateEObjetivoCommandHandler : IRequestHandler<UpdateEObjetivoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEObjetivoRepository _eObjetivoRepository;
            private readonly IEProyectoRepository _eProyectoRepository;
            private readonly IMapper _mapper;

            public UpdateEObjetivoCommandHandler(
                                                    IEObjetivoRepository eObjetivoRepository,
                                                    IEProyectoRepository eProyectoRepository,
                                                    IUnitOfWork unitOfWork, 
                                                    IMapper mapper)
            {
                _eObjetivoRepository = eObjetivoRepository;
                _eProyectoRepository = eProyectoRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEObjetivoCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EObjetivo = await _eObjetivoRepository.GetByIdAsync(request.Id);

                if (EObjetivo == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Listado de campos que se va a actualizar con los nuevos datos traidos en request
                    EObjetivo.obj_Nombre = request.obj_Nombre;
                    EObjetivo.obj_Nivel = request.obj_Nivel;
                    EObjetivo.obj_Outcome = request.obj_Outcome;
                    EObjetivo.obj_Output = request.obj_Output;
                    EObjetivo.obj_Activity = request.obj_Activity;

                    EProyecto eEProyecto = await _eProyectoRepository.GetByIdAsync(request.EProyectoId);
                    EObjetivo.EProyecto = eEProyecto;


                    //Actualizamos el registro en la base de datos
                    await _eObjetivoRepository.UpdateAsync(EObjetivo);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EObjetivo.Id);
                }
            }
        }



    }
}
