using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EIndicadorUsuarios
{
    public partial class CreateEIndicadorUsuarioCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public EIndicador EIndicador { get; set; }

    }

    public class CreateEIndicadorUsuarioCommandHandler : IRequestHandler<CreateEIndicadorUsuarioCommand, Result<int>>
    {
        private readonly IEIndicadorUsuarioRepository _eIndicadorUsuarioRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEIndicadorUsuarioCommandHandler(IEIndicadorUsuarioRepository eIndicadorUsuarioRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _eIndicadorUsuarioRepository = eIndicadorUsuarioRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEIndicadorUsuarioCommand request, CancellationToken cancellationToken)
        {
            var EIndicadorUsuario = _mapper.Map<EIndicadorUsuario>(request);    //mapea los datos recibidos a la estructura de la bbdd
            await _eIndicadorUsuarioRepository.InsertAsync(EIndicadorUsuario);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EIndicadorUsuario.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
