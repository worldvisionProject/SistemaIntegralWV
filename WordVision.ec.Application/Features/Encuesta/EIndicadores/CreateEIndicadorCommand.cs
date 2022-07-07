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
    public partial class CreateEIndicadorCommand : IRequest<Result<int>>
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
    }

    public class CreateEIndicadorCommandHandler : IRequestHandler<CreateEIndicadorCommand, Result<int>>
    {
        private readonly IEIndicadorRepository _eIndicadorRepository;
        private readonly IEObjetivoRepository _eObjetivoRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEIndicadorCommandHandler(
                                                IEIndicadorRepository eIndicadorRepository,
                                                IEObjetivoRepository eObjetivoRepository,
                                                IUnitOfWork unitOfWork, 
                                                IMapper mapper)
        {
            _eIndicadorRepository = eIndicadorRepository;
            _eObjetivoRepository = eObjetivoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEIndicadorCommand request, CancellationToken cancellationToken)
        {
            var EIndicador = _mapper.Map<EIndicador>(request);    //mapea los datos recibidos a la estructura de la bbdd

            EObjetivo eObjetivo = await _eObjetivoRepository.GetByIdAsync(request.EObjetivoId);
            EIndicador.EObjetivo = eObjetivo;
            EIndicador.ind_LogFrame = eObjetivo.Id;

            await _eIndicadorRepository.InsertAsync(EIndicador);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EIndicador.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
