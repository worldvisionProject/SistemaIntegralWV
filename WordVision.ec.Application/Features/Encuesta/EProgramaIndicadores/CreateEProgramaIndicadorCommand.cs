using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProgramaIndicadores
{
    public partial class CreateEProgramaIndicadorCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int pi_Poblacion { get; set; }
        public string EIndicadorId { get; set; }
        public string EProgramaId { get; set; }

    }

    public class CreateEProgramaIndicadorCommandHandler : IRequestHandler<CreateEProgramaIndicadorCommand, Result<int>>
    {
        private readonly IEProgramaIndicadorRepository _eProgramaIndicadorRepository;
        private readonly IEIndicadorRepository _eIndicadorRepository;
        private readonly IEProgramaRepository _eProgramaRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEProgramaIndicadorCommandHandler(IEProgramaIndicadorRepository eProgramaIndicadorRepository,
                                            IEIndicadorRepository eIndicadorRepository,
                                            IEProgramaRepository eProgramaRepository,
                                            IUnitOfWork unitOfWork,
                                            IMapper mapper)
        {
            _eProgramaIndicadorRepository = eProgramaIndicadorRepository;

            _eIndicadorRepository = eIndicadorRepository;
            _eProgramaRepository = eProgramaRepository;

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEProgramaIndicadorCommand request, CancellationToken cancellationToken)
        {
            var EProgramaIndicador = _mapper.Map<EProgramaIndicador>(request);    //mapea los datos recibidos a la estructura de la bbdd

            EIndicador eIndicador = await _eIndicadorRepository.GetByIdAsync(request.EIndicadorId);
            EProgramaIndicador.EIndicador = eIndicador;

            EPrograma ePrograma = await _eProgramaRepository.GetByIdAsync(request.EProgramaId);
            EProgramaIndicador.EPrograma = ePrograma;

            await _eProgramaIndicadorRepository.InsertAsync(EProgramaIndicador);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EProgramaIndicador.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
