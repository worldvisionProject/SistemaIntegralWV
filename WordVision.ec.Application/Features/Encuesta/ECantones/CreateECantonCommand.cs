using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.ECantones
{
    public partial class CreateECantonCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string can_nombre { get; set; }
        public string EProvinciaId { get; set; }
    }

    public class CreateECantonCommandHandler : IRequestHandler<CreateECantonCommand, Result<int>>
    {
        private readonly IECantonRepository _eCantonRepository;
        private readonly IEProvinciaRepository _eProvinciaRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateECantonCommandHandler(
                                            IECantonRepository eCantonRepository,
                                            IEProvinciaRepository eProvinciaRepository,
                                            IUnitOfWork unitOfWork, 
                                            IMapper mapper)
        {
            _eCantonRepository = eCantonRepository;
            _eProvinciaRepository = eProvinciaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateECantonCommand request, CancellationToken cancellationToken)
        {
            var ECanton = _mapper.Map<ECanton>(request);    //mapea los datos recibidos a la estructura de la bbdd

            EProvincia eProvincia = await _eProvinciaRepository.GetByIdAsync(request.EProvinciaId);
            ECanton.EProvincia = eProvincia;


            await _eCantonRepository.InsertAsync(ECanton);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(ECanton.Id);    //devuelve le id existoso del registro insertado
        }


    }
}
