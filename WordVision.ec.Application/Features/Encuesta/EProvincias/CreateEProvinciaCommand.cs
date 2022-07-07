using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProvincias
{
    public partial class CreateEProvinciaCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string pro_nombre { get; set; }
        public int ERegionId { get; set; }
    }

    public class CreateEProvinciaCommandHandler : IRequestHandler<CreateEProvinciaCommand, Result<int>>
    {
        private readonly IEProvinciaRepository _eProvinciaRepository;
        private readonly IERegionRepository _eRegionRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEProvinciaCommandHandler(
                                                IEProvinciaRepository eProvinciaRepository,
                                                IERegionRepository eRegionRepository,
                                                IUnitOfWork unitOfWork, 
                                                IMapper mapper)
        {
            _eProvinciaRepository = eProvinciaRepository;
            _eRegionRepository = eRegionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEProvinciaCommand request, CancellationToken cancellationToken)
        {
            var EProvincia = _mapper.Map<EProvincia>(request);    //mapea los datos recibidos a la estructura de la bbdd

            ERegion eRegion = await _eRegionRepository.GetByIdAsync(request.ERegionId);
            EProvincia.eRegion = eRegion;

            await _eProvinciaRepository.InsertAsync(EProvincia);  //Insertar a la BBDD
            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(EProvincia.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
