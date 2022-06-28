using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.ERegiones
{
    public partial class CreateERegionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string reg_nombre { get; set; }

    }

    public class CreateERegionCommandHandler : IRequestHandler<CreateERegionCommand, Result<int>>
    {
        private readonly IERegionRepository _eRegionRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateERegionCommandHandler(IERegionRepository eRegionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _eRegionRepository = eRegionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateERegionCommand request, CancellationToken cancellationToken)
        {
            var ERegion = _mapper.Map<ERegion>(request);    //mapea los datos recibidos a la estructura de la bbdd
            await _eRegionRepository.InsertAsync(ERegion);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(ERegion.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
