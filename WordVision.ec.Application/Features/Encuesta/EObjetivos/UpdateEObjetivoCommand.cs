using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EObjetivos
{
    public class UpdateEObjetivoCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string obj_Nombre { get; set; }


        public class UpdateEObjetivoCommandHandler : IRequestHandler<UpdateEObjetivoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEObjetivoRepository _eObjetivoRepository;
            private readonly IMapper _mapper;

            public UpdateEObjetivoCommandHandler(IEObjetivoRepository eObjetivoRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _eObjetivoRepository = eObjetivoRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEObjetivoCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EObjetivo = await _eObjetivoRepository.GetByIdAsync(request.Id);

                if (EObjetivo == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    var EObjetivoUpdate = _mapper.Map<EObjetivo>(request);    //mapea los datos recibidos a la estructura de la bbdd

                    //Actualizamos el registro en la base de datos
                    await _eObjetivoRepository.UpdateAsync(EObjetivoUpdate);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EObjetivoUpdate.Id);
                }
            }
        }



    }
}
