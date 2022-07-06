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
    public class UpdateERegionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string reg_nombre { get; set; }


        public class UpdateERegionCommandHandler : IRequestHandler<UpdateERegionCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IERegionRepository _eRegionRepository;
            private readonly IMapper _mapper;

            public UpdateERegionCommandHandler(IERegionRepository eRegionRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _eRegionRepository = eRegionRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateERegionCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var ERegion = await _eRegionRepository.GetByIdAsync(request.Id);

                if (ERegion == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    ERegion.reg_nombre = request.reg_nombre;

                    //Actualizamos el registro en la base de datos
                    await _eRegionRepository.UpdateAsync(ERegion);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(ERegion.Id);
                }
            }
        }



    }
}
