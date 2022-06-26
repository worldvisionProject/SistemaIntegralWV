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
        public string ind_proyecto { get; set; }


        public string EObjetivoId { get; set; }

        public class UpdateEIndicadorCommandHandler : IRequestHandler<UpdateEIndicadorCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEIndicadorRepository _eIndicadorRepository;
            private readonly IMapper _mapper;

            public UpdateEIndicadorCommandHandler(IEIndicadorRepository eIndicadorRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _eIndicadorRepository = eIndicadorRepository;
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
                    var EIndicadorUpdate = _mapper.Map<EIndicador>(request);    //mapea los datos recibidos a la estructura de la bbdd

                    //Actualizamos el registro en la base de datos
                    await _eIndicadorRepository.UpdateAsync(EIndicadorUpdate);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EIndicadorUpdate.Id);
                }
            }
        }



    }
}
