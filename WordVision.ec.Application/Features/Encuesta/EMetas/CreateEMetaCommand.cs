using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EMetas
{
    public partial class CreateEMetaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public decimal met_valor { get; set; }
        public int EEvaluacionId { get; set; }
        public string EIndicadorId { get; set; }
        public string EProgramaId { get; set; }

    }

    public class CreateEMetaCommandHandler : IRequestHandler<CreateEMetaCommand, Result<int>>
    {
        private readonly IEMetaRepository _eMetaRepository;
        private readonly IEEvaluacionRepository _eEvaluacionRepository;
        private readonly IEIndicadorRepository _eIndicadorRepository;
        private readonly IEProgramaRepository _eProgramaRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEMetaCommandHandler(   IEMetaRepository eMetaRepository,
                                            IEEvaluacionRepository eEvaluacionRepository,
                                            IEIndicadorRepository eIndicadorRepository,
                                            IEProgramaRepository eProgramaRepository,
                                            IUnitOfWork unitOfWork, 
                                            IMapper mapper)
        {
            _eMetaRepository = eMetaRepository;

            _eEvaluacionRepository = eEvaluacionRepository;
            _eIndicadorRepository = eIndicadorRepository;
            _eProgramaRepository = eProgramaRepository;

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEMetaCommand request, CancellationToken cancellationToken)
        {
            var EMeta = _mapper.Map<EMeta>(request);    //mapea los datos recibidos a la estructura de la bbdd

            EEvaluacion eEvaluacion = await _eEvaluacionRepository.GetByIdAsync(request.EEvaluacionId);
            EMeta.EEvaluacion = eEvaluacion;

            EIndicador eIndicador = await _eIndicadorRepository.GetByIdAsync(request.EIndicadorId);
            EMeta.EIndicador = eIndicador;

            EPrograma ePrograma = await _eProgramaRepository.GetByIdAsync(request.EProgramaId);
            EMeta.EPrograma = ePrograma;

            await _eMetaRepository.InsertAsync(EMeta);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EMeta.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
