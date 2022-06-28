using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;


namespace WordVision.ec.Application.Features.Encuesta.EncuestaKobos
{
    public class DeleteRelatedDataEncuestaKoboCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class SyncAllEncuestaKoboCommandHandler : IRequestHandler<DeleteRelatedDataEncuestaKoboCommand, Result<int>>
        {
            private readonly IEncuestaKoboRepository _encuestaKoboRepository;
            private readonly IPreguntaKoboRepository _preguntaKoboRepository;
            private readonly IEncuestadoKoboRepository _encuestadoKoboRepository;
            private readonly IEncuestadoPreguntaKoboRepository _encuestadoPreguntaKoboRepository;

            private readonly IUnitOfWork _unitOfWork;

            public SyncAllEncuestaKoboCommandHandler(IEncuestaKoboRepository encuestaKoboRepository,
                                                    IPreguntaKoboRepository preguntaKoboRepository,
                                                    IEncuestadoKoboRepository encuestadoKoboRepository,
                                                    IEncuestadoPreguntaKoboRepository encuestadoPreguntaKoboRepository,
                                                    IUnitOfWork unitOfWork)
            {
                _encuestaKoboRepository = encuestaKoboRepository;
                _preguntaKoboRepository = preguntaKoboRepository;
                _encuestadoKoboRepository = encuestadoKoboRepository;
                _encuestadoPreguntaKoboRepository = encuestadoPreguntaKoboRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteRelatedDataEncuestaKoboCommand command, CancellationToken cancellationToken)
            {
                var encuestaKoboModel = await _encuestaKoboRepository.GetByIdAsync(command.Id);

                //*******************************************************************************************************
                //*** Eliminamos todos los registros relacionados en todas las tablas de la encuesta seleccionada  ******
                //*******************************************************************************************************

                //Obtenemos un listado de todos los encuestados relacionados con la encuesta seleccionada
                List<EncuestadoKobo> encuestadosKoboList = await _encuestadoKoboRepository.GetListAsync(encuestaKoboModel.Id);
                
                //Eliminamos todos los registros de la tabla EncuestadoPreguntaKobos que esta relacionado con cada encuestadoKobo del listado
                foreach(EncuestadoKobo encuestadoKobo in encuestadosKoboList)
                {
                    List<EncuestadoPreguntaKobo> encuestadoPreguntaKoboList = await _encuestadoPreguntaKoboRepository.GetListAsyncByEncuestadoKobo(encuestadoKobo.Id);
                    await _encuestadoPreguntaKoboRepository.DeleteAllAsync(encuestadoPreguntaKoboList);
                }
                await _unitOfWork.Commit(cancellationToken);

                //Eliminamos todos los encuestados relacionados con la encuesta seleccionada
                await _encuestadoKoboRepository.DeleteAllAsync(encuestadosKoboList);

                //Obtenemos un listado de todas las preguntas relacionadas con la encuesta seleccionada
                List<PreguntaKobo> preguntasKoboList = await _preguntaKoboRepository.GetListAsync(encuestaKoboModel.Id);

                //Eliminamos todas las preguntas relacionadas con la encuesta seleccionada
                await _preguntaKoboRepository.DeleteAllAsync(preguntasKoboList);

                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(0);
            }
        }




    }
}
