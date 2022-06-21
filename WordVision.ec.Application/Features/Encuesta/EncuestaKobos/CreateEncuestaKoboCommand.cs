using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EncuestaKobos
{
    public partial class CreateEncuestaKoboCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string enk_Id_string { get; set; }
        public string enk_Title { get; set; }
        public string enk_Description { get; set; }
        public string enk_Url { get; set; }
        public DateTime enk_Fecha { get; set; }
    }

    public class CreateEncuestaKoboCommandHandler : IRequestHandler<CreateEncuestaKoboCommand, Result<int>>
    {
        private readonly IEncuestaKoboRepository _encuestaKoboRepository;
        private readonly IMapper _mapper;    //Con los campos de la interfaz y el modelo hace un mapeo
        private IUnitOfWork _unitOfWork { get; set; }  // hace la transaccionabilidad crea la cabecera y luego detalle

        public CreateEncuestaKoboCommandHandler(IEncuestaKoboRepository encuestaKoboRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _encuestaKoboRepository = encuestaKoboRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Ejecuta la operacion, en request esta el objeto con la info para insertar en la base de datos
        public async Task<Result<int>> Handle(CreateEncuestaKoboCommand request, CancellationToken cancellationToken)
        {
            //var encuestaKobo = _mapper.Map<EncuestaKobo>(request);    //mapea los datos recibidos a la estructura de la bbdd
            EncuestaKobo encuestaKobo = new EncuestaKobo();
            encuestaKobo.Id = request.Id;
            encuestaKobo.enk_Id_string = request.enk_Id_string;
            encuestaKobo.enk_Title = request.enk_Title; 
            encuestaKobo.enk_Description = request.enk_Description; 
            encuestaKobo.enk_Url = request.enk_Url;
            //encuestaKobo.enk_Fecha = request.enk_Fecha; 
            encuestaKobo.enk_Fecha = null;
            await _encuestaKoboRepository.InsertAsync(encuestaKobo);  //Insertar a la BBDD

            await _unitOfWork.Commit(cancellationToken);    //commit
            return Result<int>.Success(encuestaKobo.Id);    //devuelve le id existoso del registro insertado
        }


    }

}
