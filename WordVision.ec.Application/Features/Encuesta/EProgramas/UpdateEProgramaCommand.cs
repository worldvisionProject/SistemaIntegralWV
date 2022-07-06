using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;
using System.Collections.Generic;

namespace WordVision.ec.Application.Features.Encuesta.EProgramas
{
    public class UpdateEProgramaCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string pa_nombre { get; set; }


        public class UpdateEProgramaCommandHandler : IRequestHandler<UpdateEProgramaCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEProgramaRepository _eProgramaRepository;
            private readonly IMapper _mapper;

            public UpdateEProgramaCommandHandler(IEProgramaRepository eProgramaRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _eProgramaRepository = eProgramaRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEProgramaCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EPrograma = await _eProgramaRepository.GetByIdAsync(request.Id);

                if (EPrograma == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Listado de campos que se va a actualizar con los nuevos datos traidos en request
                    EPrograma.pa_nombre = request.pa_nombre;

                    //Actualizamos el registro en la base de datos
                    await _eProgramaRepository.UpdateAsync(EPrograma);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EPrograma.Id);
                }
            }
        }



    }
}
