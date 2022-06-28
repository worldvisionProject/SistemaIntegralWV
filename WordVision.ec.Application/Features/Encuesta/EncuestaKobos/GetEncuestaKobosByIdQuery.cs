using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EncuestaKobos
{
    public class GetEncuestaKobosByIdResponse
    {
        public int Id { get; set; }
        public string enk_Id_string { get; set; }
        public string enk_Title { get; set; }
        public string enk_Description { get; set; }
        public string enk_Url { get; set; }
        public DateTime enk_Fecha { get; set; }
    }

    public class GetEncuestaKobosByIdQuery : IRequest<Result<GetEncuestaKobosByIdResponse>>
    {
        public int Id { get; set; }

        public class GetEncuestaKobosByIdQueryHandler : IRequestHandler<GetEncuestaKobosByIdQuery, Result<GetEncuestaKobosByIdResponse>>
        {
            private readonly IEncuestaKoboRepository _encuestaKobosRepository;
            private readonly IMapper _mapper;

            public GetEncuestaKobosByIdQueryHandler(IEncuestaKoboRepository encuestaKobosRepository, IMapper mapper)
            {
                _encuestaKobosRepository = encuestaKobosRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEncuestaKobosByIdResponse>> Handle(GetEncuestaKobosByIdQuery query, CancellationToken cancellationToken)
            {
                var encuestaKoboModel = await _encuestaKobosRepository.GetByIdAsync(query.Id);
                var mappedEncuestaKobos = _mapper.Map<GetEncuestaKobosByIdResponse>(encuestaKoboModel);
                //GetEncuestaKobosByIdResponse mappedEncuestaKobos = new GetEncuestaKobosByIdResponse();
                //mappedEncuestaKobos.Id = encuestaKoboModel.Id;
                //mappedEncuestaKobos.enk_Id_string= encuestaKoboModel.enk_Id_string;
                //mappedEncuestaKobos.enk_Title= encuestaKoboModel.enk_Title;
                //mappedEncuestaKobos.enk_Description= encuestaKoboModel.enk_Description;
                //mappedEncuestaKobos.enk_Url= encuestaKoboModel.enk_Url;
                //mappedEncuestaKobos.enk_Fecha= encuestaKoboModel.enk_Fecha;

                return Result<GetEncuestaKobosByIdResponse>.Success(mappedEncuestaKobos);
            }
        }

    }
}
