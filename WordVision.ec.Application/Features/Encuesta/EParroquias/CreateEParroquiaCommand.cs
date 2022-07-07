using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EParroquias
{
    public partial class CreateEParroquiaCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string par_nombre { get; set; }
        public string EProgramaId { get; set; }
        public string ECantonId { get; set; }
    }

    public class CreateEParroquiaCommandHandler : IRequestHandler<CreateEParroquiaCommand, Result<int>>
    {
        private readonly IEParroquiaRepository _eParroquiaRepository;
        private readonly IEProgramaRepository _eProgramaRepository;
        private readonly IECantonRepository _eCantonRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEParroquiaCommandHandler(
                                                IEParroquiaRepository eParroquiaRepository,
                                                IEProgramaRepository eProgramaRepository,
                                                IECantonRepository eCantonRepository,
                                                IUnitOfWork unitOfWork, 
                                                IMapper mapper)
        {
            _eParroquiaRepository = eParroquiaRepository;
            _eProgramaRepository = eProgramaRepository;
            _eCantonRepository = eCantonRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEParroquiaCommand request, CancellationToken cancellationToken)
        {
            var EParroquia = _mapper.Map<EParroquia>(request);    //mapea los datos recibidos a la estructura de la bbdd

            EPrograma ePrograma = await _eProgramaRepository.GetByIdAsync(request.EProgramaId);
            EParroquia.EPrograma = ePrograma;

            ECanton eCanton = await _eCantonRepository.GetByIdAsync(request.ECantonId);
            EParroquia.ECanton = eCanton;


            await _eParroquiaRepository.InsertAsync(EParroquia);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EParroquia.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
