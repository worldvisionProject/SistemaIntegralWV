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
    public class UpdateEComunidadCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string com_nombre { get; set; }
        public string EParroquiaId { get; set; }


        public class UpdateEComunidadCommandHandler : IRequestHandler<UpdateEComunidadCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEComunidadRepository _eComunidadRepository;
            private readonly IEParroquiaRepository _eParroquiaRepository;
            private readonly IMapper _mapper;

            public UpdateEComunidadCommandHandler(
                                                    IEComunidadRepository eComunidadRepository,
                                                    IEParroquiaRepository eParroquiaRepository,
                                                    IUnitOfWork unitOfWork, 
                                                    IMapper mapper)
            {
                _eComunidadRepository = eComunidadRepository;
                _eParroquiaRepository = eParroquiaRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEComunidadCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EComunidad = await _eComunidadRepository.GetByIdAsync(request.Id);

                if (EComunidad == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    EComunidad.Id = request.Id;
                    EComunidad.com_nombre = request.com_nombre;

                    EParroquia eParroquia = await _eParroquiaRepository.GetByIdAsync(request.EParroquiaId);
                    EComunidad.eParroquia = eParroquia;

                    //Actualizamos el registro en la base de datos
                    await _eComunidadRepository.UpdateAsync(EComunidad);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EComunidad.Id);
                }
            }
        }



    }
}
