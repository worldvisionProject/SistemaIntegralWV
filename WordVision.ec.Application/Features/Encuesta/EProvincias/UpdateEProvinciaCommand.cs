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
    public class UpdateEProvinciaCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string pro_nombre { get; set; }
        public ERegion eRegion { get; set; }


        public class UpdateEProvinciaCommandHandler : IRequestHandler<UpdateEProvinciaCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEProvinciaRepository _eProvinciaRepository;
            private readonly IMapper _mapper;

            public UpdateEProvinciaCommandHandler(IEProvinciaRepository eProvinciaRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _eProvinciaRepository = eProvinciaRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEProvinciaCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EProvincia = await _eProvinciaRepository.GetByIdAsync(request.Id);

                if (EProvincia == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    var EProvinciaUpdate = _mapper.Map<EProvincia>(request);    //mapea los datos recibidos a la estructura de la bbdd

                    //Actualizamos el registro en la base de datos
                    await _eProvinciaRepository.UpdateAsync(EProvinciaUpdate);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EProvinciaUpdate.Id);
                }
            }
        }



    }
}
