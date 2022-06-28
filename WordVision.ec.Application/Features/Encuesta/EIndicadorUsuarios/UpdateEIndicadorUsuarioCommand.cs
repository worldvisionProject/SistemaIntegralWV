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
    public class UpdateEIndicadorUsuarioCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public EIndicador EIndicador { get; set; }


        public class UpdateEIndicadorUsuarioCommandHandler : IRequestHandler<UpdateEIndicadorUsuarioCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEIndicadorUsuarioRepository _eIndicadorUsuarioRepository;
            private readonly IMapper _mapper;

            public UpdateEIndicadorUsuarioCommandHandler(IEIndicadorUsuarioRepository eIndicadorUsuarioRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _eIndicadorUsuarioRepository = eIndicadorUsuarioRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEIndicadorUsuarioCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EIndicadorUsuario = await _eIndicadorUsuarioRepository.GetByIdAsync(request.Id);

                if (EIndicadorUsuario == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    var EIndicadorUsuarioUpdate = _mapper.Map<EIndicadorUsuario>(request);    //mapea los datos recibidos a la estructura de la bbdd

                    //Actualizamos el registro en la base de datos
                    await _eIndicadorUsuarioRepository.UpdateAsync(EIndicadorUsuarioUpdate);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EIndicadorUsuarioUpdate.Id);
                }
            }
        }



    }
}
