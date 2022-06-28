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
    public partial class CreateEEvaluacionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string eva_Nombre { get; set; }
        public DateTime eva_Desde { get; set; }
        public DateTime eva_Hasta { get; set; }

    }

    public class CreateEEvaluacionCommandHandler : IRequestHandler<CreateEEvaluacionCommand, Result<int>>
    {
        private readonly IEEvaluacionRepository _eEvaluacionRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEEvaluacionCommandHandler(IEEvaluacionRepository eEvaluacionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _eEvaluacionRepository = eEvaluacionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEEvaluacionCommand request, CancellationToken cancellationToken)
        {
            var EEvaluacion = _mapper.Map<EEvaluacion>(request);    //mapea los datos recibidos a la estructura de la bbdd
            await _eEvaluacionRepository.InsertAsync(EEvaluacion);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EEvaluacion.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
