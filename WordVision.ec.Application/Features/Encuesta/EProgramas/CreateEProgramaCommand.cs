using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProgramas
{
    public partial class CreateEProgramaCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string pa_nombre { get; set; }

    }

    public class CreateEProgramaCommandHandler : IRequestHandler<CreateEProgramaCommand, Result<int>>
    {
        private readonly IEProgramaRepository _eProgramaRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEProgramaCommandHandler(IEProgramaRepository eProgramaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _eProgramaRepository = eProgramaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEProgramaCommand request, CancellationToken cancellationToken)
        {
            var EPrograma = _mapper.Map<EPrograma>(request);    //mapea los datos recibidos a la estructura de la bbdd
            await _eProgramaRepository.InsertAsync(EPrograma);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EPrograma.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
