using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EMetas
{
    public class GetAllEMetasResponse : GenericResponse
    {
        public int Id { get; set; }
        public decimal met_valor { get; set; }


        public int EEvaluacionId { get; set; }
        public EEvaluacion EEvaluacion { get; set; }


        public string EIndicadorId { get; set; }
        public EIndicador EIndicador { get; set; }


        public string EProgramaId { get; set; }
        public EPrograma EPrograma { get; set; }   

    }
    public class GetAllEMetasQuery : GetAllEMetasResponse, IRequest<Result<List<GetAllEMetasResponse>>>
    {
        public GetAllEMetasQuery()
        {
        }
        public class GetAllEMetasQueryHandler : IRequestHandler<GetAllEMetasQuery, Result<List<GetAllEMetasResponse>>>
        {
            private readonly IEMetaRepository _eMeta;
            private readonly IMapper _mapper;

            public GetAllEMetasQueryHandler(IEMetaRepository eMeta,
                                                    IMapper mapper)
            {
                _eMeta = eMeta;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEMetasResponse>>> Handle(GetAllEMetasQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                List<EMeta> EMetaList = await _eMeta.GetListAsync(request.Include);

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEMetasResponse
                var mappedEMetas = _mapper.Map<List<GetAllEMetasResponse>>(EMetaList);
                
                return Result<List<GetAllEMetasResponse>>.Success(mappedEMetas);
            }
        }




    }
}
