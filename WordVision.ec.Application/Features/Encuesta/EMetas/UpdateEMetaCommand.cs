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
        public int EEvaluacionId { get; set; }
        public string EIndicadorId { get; set; }
        public string EProgramaId { get; set; }


        public class UpdateEMetaCommandHandler : IRequestHandler<UpdateEMetaCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEMetaRepository _eMetaRepository;
            private readonly IEEvaluacionRepository _eEvaluacionRepository;
            private readonly IEIndicadorRepository _eIndicadorRepository;
            private readonly IEProgramaRepository _eProgramaRepository;
            private readonly IMapper _mapper;

            public UpdateEMetaCommandHandler(
                                                IEMetaRepository eMetaRepository,
                                                IEEvaluacionRepository eEvaluacionRepository,
                                                IEIndicadorRepository eIndicadorRepository,
                                                IEProgramaRepository eProgramaRepository,
                                                IUnitOfWork unitOfWork, 
                                                IMapper mapper)
            {
                _eMetaRepository = eMetaRepository;

                _eEvaluacionRepository = eEvaluacionRepository;
                _eIndicadorRepository = eIndicadorRepository;
                _eProgramaRepository = eProgramaRepository;

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
                    EMeta.met_valor = request.met_valor;

                    EEvaluacion eEvaluacion = await _eEvaluacionRepository.GetByIdAsync(request.EEvaluacionId);
                    EMeta.EEvaluacion = eEvaluacion;

                    EIndicador eIndicador = await _eIndicadorRepository.GetByIdAsync(request.EIndicadorId);
                    EMeta.EIndicador = eIndicador;

                    EPrograma ePrograma = await _eProgramaRepository.GetByIdAsync(request.EProgramaId);
                    EMeta.EPrograma = ePrograma;


                    //Actualizamos el registro en la base de datos
                    await _eMetaRepository.UpdateAsync(EMeta);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EMeta.Id);
                }
            }
        }



    }
}
