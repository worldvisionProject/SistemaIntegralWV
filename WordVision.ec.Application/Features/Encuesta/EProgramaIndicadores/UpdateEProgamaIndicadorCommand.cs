using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProgramaIndicadores
{
    public class UpdateEProgramaIndicadorCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int pi_Poblacion { get; set; }
        public string EIndicadorId { get; set; }
        public string EProgramaId { get; set; }


        public class UpdateEProgramaIndicadorCommandHandler : IRequestHandler<UpdateEProgramaIndicadorCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEProgramaIndicadorRepository _eProgramaIndicadorRepository;
            private readonly IEIndicadorRepository _eIndicadorRepository;
            private readonly IEProgramaRepository _eProgramaRepository;
            private readonly IMapper _mapper;

            public UpdateEProgramaIndicadorCommandHandler(
                                                IEProgramaIndicadorRepository eProgramaIndicadorRepository,
                                                IEIndicadorRepository eIndicadorRepository,
                                                IEProgramaRepository eProgramaRepository,
                                                IUnitOfWork unitOfWork,
                                                IMapper mapper)
            {
                _eProgramaIndicadorRepository = eProgramaIndicadorRepository;

                _eIndicadorRepository = eIndicadorRepository;
                _eProgramaRepository = eProgramaRepository;

                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEProgramaIndicadorCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EProgramaIndicador = await _eProgramaIndicadorRepository.GetByIdAsync(request.Id);

                if (EProgramaIndicador == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    EProgramaIndicador.pi_Poblacion = request.pi_Poblacion;

                    EIndicador eIndicador = await _eIndicadorRepository.GetByIdAsync(request.EIndicadorId);
                    EProgramaIndicador.EIndicador = eIndicador;

                    EPrograma ePrograma = await _eProgramaRepository.GetByIdAsync(request.EProgramaId);
                    EProgramaIndicador.EPrograma = ePrograma;


                    //Actualizamos el registro en la base de datos
                    await _eProgramaIndicadorRepository.UpdateAsync(EProgramaIndicador);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EProgramaIndicador.Id);
                }
            }
        }



    }
}
