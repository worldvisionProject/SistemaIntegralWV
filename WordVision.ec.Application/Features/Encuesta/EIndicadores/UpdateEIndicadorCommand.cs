using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EIndicadores
{
    public class UpdateEIndicadorCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string ind_LogFrame { get; set; }
        public string ind_Nombre { get; set; }
        public string ind_Resultado { get; set; }
        public string ind_Definicion { get; set; }
        public string ind_Fuente { get; set; }
        public string ind_Seccion { get; set; }
        public string ind_Preguntas { get; set; }
        public string ind_Medicion { get; set; }
        public string int_PlanTabulados { get; set; }
        public string ind_UnidadMedida { get; set; }
        public int ind_Frecuencia { get; set; }
        public string ind_tipo { get; set; }
        public string ind_Operacion { get; set; }


        public string EObjetivoId { get; set; }

        public class UpdateEIndicadorCommandHandler : IRequestHandler<UpdateEIndicadorCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEIndicadorRepository _eIndicadorRepository;
            private readonly IMapper _mapper;
            private readonly IEObjetivoRepository _eObjetivoRepository;

            public UpdateEIndicadorCommandHandler(  IEIndicadorRepository eIndicadorRepository,
                                                    IEObjetivoRepository eObjetivoRepository,
                                                    IUnitOfWork unitOfWork, 
                                                    IMapper mapper)
            {
                _eIndicadorRepository = eIndicadorRepository;
                _eObjetivoRepository = eObjetivoRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEIndicadorCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EIndicador = await _eIndicadorRepository.GetByIdAsync(request.Id);

                if (EIndicador == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    EIndicador.Id = request.Id;
                    
                    EIndicador.ind_Nombre = request.ind_Nombre;
                    EIndicador.ind_Resultado = request.ind_Resultado;
                    EIndicador.ind_Definicion = request.ind_Definicion;
                    EIndicador.ind_Fuente = request.ind_Fuente;
                    EIndicador.ind_Seccion = request.ind_Seccion;
                    EIndicador.ind_Preguntas = request.ind_Preguntas;
                    EIndicador.ind_Medicion = request.ind_Medicion;
                    EIndicador.int_PlanTabulados = request.int_PlanTabulados;
                    EIndicador.ind_UnidadMedida = request.ind_UnidadMedida;
                    EIndicador.ind_Frecuencia = request.ind_Frecuencia;
                    EIndicador.ind_tipo = request.ind_tipo;
                    EIndicador.ind_Operacion = request.ind_Operacion;

                    EObjetivo eObjetivo = await _eObjetivoRepository.GetByIdAsync(request.EObjetivoId);
                    EIndicador.EObjetivo = eObjetivo;
                    EIndicador.ind_LogFrame = eObjetivo.Id;

                    //Actualizamos el registro en la base de datos
                    await _eIndicadorRepository.UpdateAsync(EIndicador);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EIndicador.Id);
                }
            }
        }



    }
}
