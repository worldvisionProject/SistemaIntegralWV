using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EParroquias
{
    public class GetEParroquiasByIdResponse
    {
        public string Id { get; set; }
        public string par_nombre { get; set; }
        public string EProgramaId { get; set; }
        public string ECantonId { get; set; }
        public virtual List<EComunidad> EComunidades { get; set; }


    }

    public class GetEParroquiasByIdQuery : IRequest<Result<GetEParroquiasByIdResponse>>
    {
        public string Id { get; set; }

        public class GetEParroquiasByIdQueryHandler : IRequestHandler<GetEParroquiasByIdQuery, Result<GetEParroquiasByIdResponse>>
        {
            private readonly IEParroquiaRepository _eParroquiasRepository;
            private readonly IMapper _mapper;

            public GetEParroquiasByIdQueryHandler(IEParroquiaRepository eParroquiasRepository, IMapper mapper)
            {
                _eParroquiasRepository = eParroquiasRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEParroquiasByIdResponse>> Handle(GetEParroquiasByIdQuery query, CancellationToken cancellationToken)
            {
                var EParroquiaModel = await _eParroquiasRepository.GetByIdAsync(query.Id);
                var mappedEParroquias = _mapper.Map<GetEParroquiasByIdResponse>(EParroquiaModel);

                return Result<GetEParroquiasByIdResponse>.Success(mappedEParroquias);
            }
        }

    }





}
