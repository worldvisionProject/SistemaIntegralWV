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

namespace WordVision.ec.Application.Features.Encuesta.EProgramaIndicadores
{
    public class GetAllEProgramaIndicadoresResponse : GenericResponse
    {
        public int Id { get; set; }
        public int pi_Poblacion { get; set; }


        public string EIndicadorId { get; set; }
        public EIndicador EIndicador { get; set; }


        public string EProgramaId { get; set; }
        public EPrograma EPrograma { get; set; }

    }
    public class GetAllEProgramaIndicadoresQuery : GetAllEProgramaIndicadoresResponse, IRequest<Result<List<GetAllEProgramaIndicadoresResponse>>>
    {
        public GetAllEProgramaIndicadoresQuery()
        {
        }
        public class GetAllEProgramaIndicadoresQueryHandler : IRequestHandler<GetAllEProgramaIndicadoresQuery, Result<List<GetAllEProgramaIndicadoresResponse>>>
        {
            private readonly IEProgramaIndicadorRepository _eProgramaIndicador;
            private readonly IMapper _mapper;

            public GetAllEProgramaIndicadoresQueryHandler(IEProgramaIndicadorRepository eProgramaIndicador,
                                                    IMapper mapper)
            {
                _eProgramaIndicador = eProgramaIndicador;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEProgramaIndicadoresResponse>>> Handle(GetAllEProgramaIndicadoresQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                List<EProgramaIndicador> EProgramaIndicadorList = await _eProgramaIndicador.GetListAsync(request.Include);

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEProgramaIndicadoresResponse
                var mappedEProgramaIndicadores = _mapper.Map<List<GetAllEProgramaIndicadoresResponse>>(EProgramaIndicadorList);

                return Result<List<GetAllEProgramaIndicadoresResponse>>.Success(mappedEProgramaIndicadores);
            }
        }




    }
}
