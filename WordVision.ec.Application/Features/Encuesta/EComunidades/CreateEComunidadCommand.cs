using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;


namespace WordVision.ec.Application.Features.Encuesta.EComunidades
{
    public partial class CreateEComunidadCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string com_nombre { get; set; }
        public string EParroquiaId { get; set; }

    }

    public class CreateEComunidadCommandHandler : IRequestHandler<CreateEComunidadCommand, Result<int>>
    {
        private readonly IEComunidadRepository _eComunidadRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEComunidadCommandHandler(IEComunidadRepository eComunidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _eComunidadRepository = eComunidadRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEComunidadCommand request, CancellationToken cancellationToken)
        {
            var EComunidad = _mapper.Map<EComunidad>(request);    //mapea los datos recibidos a la estructura de la bbdd
            await _eComunidadRepository.InsertAsync(EComunidad);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EComunidad.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
