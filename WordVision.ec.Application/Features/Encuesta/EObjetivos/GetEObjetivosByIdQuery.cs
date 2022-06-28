using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EObjetivos
{
    public class GetEObjetivosByIdResponse
    {
        public string Id { get; set; }
        public string obj_Nombre { get; set; }

        public virtual List<EIndicador> EIndicadores { get; set; }
    }

    public class GetEObjetivosByIdQuery : IRequest<Result<GetEObjetivosByIdResponse>>
    {
        public string Id { get; set; }

        public class GetEObjetivosByIdQueryHandler : IRequestHandler<GetEObjetivosByIdQuery, Result<GetEObjetivosByIdResponse>>
        {
            private readonly IEObjetivoRepository _eObjetivosRepository;
            private readonly IMapper _mapper;

            public GetEObjetivosByIdQueryHandler(IEObjetivoRepository eObjetivosRepository, IMapper mapper)
            {
                _eObjetivosRepository = eObjetivosRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEObjetivosByIdResponse>> Handle(GetEObjetivosByIdQuery query, CancellationToken cancellationToken)
            {
                var EObjetivoModel = await _eObjetivosRepository.GetByIdAsync(query.Id);
                var mappedEObjetivos = _mapper.Map<GetEObjetivosByIdResponse>(EObjetivoModel);

                return Result<GetEObjetivosByIdResponse>.Success(mappedEObjetivos);
            }
        }

    }


}
