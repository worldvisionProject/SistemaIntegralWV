using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EncuestaKobos
{
    public class UpdateEncuestaKoboCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string enk_Id_string { get; set; }
        public string enk_Title { get; set; }
        public string enk_Description { get; set; }
        public string enk_Url { get; set; }
        public DateTime enk_Fecha { get; set; }


        public class UpdateEncuestaKoboCommandHandler : IRequestHandler<UpdateEncuestaKoboCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEncuestaKoboRepository _encuestaKoboRepository;
            private readonly IMapper _mapper;

            public UpdateEncuestaKoboCommandHandler(IEncuestaKoboRepository encuestaKoboRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _encuestaKoboRepository = encuestaKoboRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(UpdateEncuestaKoboCommand command, CancellationToken cancellationToken)
            {

                //consultamos el registro con el id recibido.
                var EncuestaKobo = await _encuestaKoboRepository.GetByIdAsync(command.Id);

                if (EncuestaKobo == null)
                {
                    return Result<int>.Fail($"Encuesta no encontrada con el Id " + command.Id);
                }
                else
                {
                    EncuestaKobo.Id = command.Id;
                    EncuestaKobo.enk_Id_string = command.enk_Id_string;
                    EncuestaKobo.enk_Title = command.enk_Title;
                    EncuestaKobo.enk_Description = command.enk_Description;
                    EncuestaKobo.enk_Url = command.enk_Url;
                    //EncuestaKobo.enk_Fecha = DateTime.Now;


                    //Actualizamos el registro en la base de datos
                    await _encuestaKoboRepository.UpdateAsync(EncuestaKobo);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EncuestaKobo.Id);
                }
            }
        }



    }
}
