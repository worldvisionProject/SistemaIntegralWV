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
    public partial class CreateEObjetivoCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string obj_Nombre { get; set; }

        public string obj_Nivel { get; set; }
        public string obj_Outcome { get; set; }
        public string obj_Output { get; set; }
        public string obj_Activity { get; set; }

        public int EProyectoId { get; set; }


    }

    public class CreateEObjetivoCommandHandler : IRequestHandler<CreateEObjetivoCommand, Result<int>>
    {
        private readonly IEObjetivoRepository _eObjetivoRepository;
        private readonly IEProyectoRepository _eProyectoRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEObjetivoCommandHandler(
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

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEObjetivoCommand request, CancellationToken cancellationToken)
        {
            var EObjetivo = _mapper.Map<EObjetivo>(request);    //mapea los datos recibidos a la estructura de la bbdd


            EProyecto eProyecto = await _eProyectoRepository.GetByIdAsync(request.EProyectoId);
            EObjetivo.EProyecto = eProyecto;

            EObjetivo.obj_Outcome = "";
            EObjetivo.obj_Output = "";
            EObjetivo.obj_Activity = "";

            EObjetivo.obj_Outcome = EObjetivo.Id.Substring(0, 2);
            if (EObjetivo.Id.Length > 3) EObjetivo.obj_Output = EObjetivo.Id.Substring(3, 2);
            if (EObjetivo.Id.Length > 6) EObjetivo.obj_Activity = EObjetivo.Id.Substring(6, 2);

            if (EObjetivo.obj_Activity.Length > 0)
                EObjetivo.obj_Nivel = "Activity";
            else if (EObjetivo.obj_Output.Length > 0)
                EObjetivo.obj_Nivel = "Output";
            else
                EObjetivo.obj_Nivel = "Outcome";


            await _eObjetivoRepository.InsertAsync(EObjetivo);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EObjetivo.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
