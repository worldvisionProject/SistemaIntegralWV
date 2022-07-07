using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProyectos
{
    public class UpdateEProyectoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string py_nombre { get; set; }


        public class UpdateEProyectoCommandHandler : IRequestHandler<UpdateEProyectoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEProyectoRepository _eProyectoRepository;
            private readonly IMapper _mapper;

            public UpdateEProyectoCommandHandler(IEProyectoRepository eProyectoRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _eProyectoRepository = eProyectoRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEProyectoCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EProyecto = await _eProyectoRepository.GetByIdAsync(request.Id);

                if (EProyecto == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Listado de campos que se va a actualizar con los nuevos datos traidos en request
                    EProyecto.py_nombre = request.py_nombre;

                    //Actualizamos el registro en la base de datos
                    await _eProyectoRepository.UpdateAsync(EProyecto);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EProyecto.Id);
                }
            }
        }



    }
}
