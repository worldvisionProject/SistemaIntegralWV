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

    }

    public class CreateEObjetivoCommandHandler : IRequestHandler<CreateEObjetivoCommand, Result<int>>
    {
        private readonly IEObjetivoRepository _eObjetivoRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEObjetivoCommandHandler(IEObjetivoRepository eObjetivoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _eObjetivoRepository = eObjetivoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEObjetivoCommand request, CancellationToken cancellationToken)
        {
            var EObjetivo = _mapper.Map<EObjetivo>(request);    //mapea los datos recibidos a la estructura de la bbdd
            await _eObjetivoRepository.InsertAsync(EObjetivo);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EObjetivo.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
