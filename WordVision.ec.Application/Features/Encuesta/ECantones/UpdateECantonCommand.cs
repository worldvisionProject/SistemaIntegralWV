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
    public class UpdateECantonCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string can_nombre { get; set; }
        public string EProvinciaId { get; set; }


        public class UpdateECantonCommandHandler : IRequestHandler<UpdateECantonCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IECantonRepository _eCantonRepository;
            private readonly IEProvinciaRepository _eProvinciaRepository;
            private readonly IMapper _mapper;

            public UpdateECantonCommandHandler(
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

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateECantonCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var ECanton = await _eCantonRepository.GetByIdAsync(request.Id);

                if (ECanton == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    ECanton.Id = request.Id;
                    ECanton.can_nombre = request.can_nombre;

                    EProvincia eProvincia = await _eProvinciaRepository.GetByIdAsync(request.EProvinciaId);
                    ECanton.EProvincia = eProvincia;


                    //Actualizamos el registro en la base de datos
                    await _eCantonRepository.UpdateAsync(ECanton);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(ECanton.Id);
                }
            }
        }



    }
}
