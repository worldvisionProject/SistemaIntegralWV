using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EMetas
{
    public class UpdateEMetaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public decimal met_valor { get; set; }
        public EEvaluacion EEvaluacion { get; set; }
        public EIndicador EIndicador { get; set; }
        public EPrograma EPrograma { get; set; }


        public class UpdateEMetaCommandHandler : IRequestHandler<UpdateEMetaCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEMetaRepository _eMetaRepository;
            private readonly IMapper _mapper;

            public UpdateEMetaCommandHandler(IEMetaRepository eMetaRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _eMetaRepository = eMetaRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEMetaCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EMeta = await _eMetaRepository.GetByIdAsync(request.Id);

                if (EMeta == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    var EMetaUpdate = _mapper.Map<EMeta>(request);    //mapea los datos recibidos a la estructura de la bbdd

                    //Actualizamos el registro en la base de datos
                    await _eMetaRepository.UpdateAsync(EMetaUpdate);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EMetaUpdate.Id);
                }
            }
        }



    }
}
