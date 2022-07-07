using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EParroquias
{
    public class UpdateEParroquiaCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }
        public string par_nombre { get; set; }
        public string EProgramaId { get; set; }
        public string ECantonId { get; set; }


        public class UpdateEParroquiaCommandHandler : IRequestHandler<UpdateEParroquiaCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEParroquiaRepository _eParroquiaRepository;
            private readonly IEProgramaRepository _eProgramaRepository;
            private readonly IECantonRepository _eCantonRepository;
            private readonly IMapper _mapper;

            public UpdateEParroquiaCommandHandler(
                                                    IEParroquiaRepository eParroquiaRepository,
                                                    IEProgramaRepository eProgramaRepository,
                                                    IECantonRepository eCantonRepository,
                                                    IUnitOfWork unitOfWork, 
                                                    IMapper mapper)
            {
                _eParroquiaRepository = eParroquiaRepository;
                _eProgramaRepository = eProgramaRepository;
                _eCantonRepository = eCantonRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEParroquiaCommand request, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EParroquia = await _eParroquiaRepository.GetByIdAsync(request.Id);

                if (EParroquia == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    EParroquia.Id = request.Id;
                    EParroquia.par_nombre = request.par_nombre;

                    EPrograma ePrograma = await _eProgramaRepository.GetByIdAsync(request.EProgramaId);
                    EParroquia.EPrograma = ePrograma;

                    ECanton eCanton = await _eCantonRepository.GetByIdAsync(request.ECantonId);
                    EParroquia.ECanton = eCanton;

                    //Actualizamos el registro en la base de datos
                    await _eParroquiaRepository.UpdateAsync(EParroquia);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EParroquia.Id);
                }
            }
        }



    }
}
