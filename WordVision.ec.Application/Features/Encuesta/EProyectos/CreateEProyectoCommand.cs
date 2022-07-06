using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProyectos
{
    public partial class CreateEProyectoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string py_nombre { get; set; }

    }

    public class CreateEProyectoCommandHandler : IRequestHandler<CreateEProyectoCommand, Result<int>>
    {
        private readonly IEProyectoRepository _eProyectoRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEProyectoCommandHandler(IEProyectoRepository eProyectoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _eProyectoRepository = eProyectoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEProyectoCommand request, CancellationToken cancellationToken)
        {
            var EProyecto = _mapper.Map<EProyecto>(request);    //mapea los datos recibidos a la estructura de la bbdd
            await _eProyectoRepository.InsertAsync(EProyecto);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EProyecto.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
