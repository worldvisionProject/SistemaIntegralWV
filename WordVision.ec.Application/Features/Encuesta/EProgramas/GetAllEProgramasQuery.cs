using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProgramas
{
    public class GetAllEProgramasResponse
    {
        public string Id { get; set; }
        public string pa_nombre { get; set; }

    }
    public class GetAllEProgramasQuery : IRequest<Result<List<GetAllEProgramasResponse>>>
    {
        public GetAllEProgramasQuery()
        {
        }
        public class GetAllEProgramasQueryHandler : IRequestHandler<GetAllEProgramasQuery, Result<List<GetAllEProgramasResponse>>>
        {
            private readonly IEProgramaRepository _ePrograma;
            private readonly IMapper _mapper;

            public GetAllEProgramasQueryHandler(IEProgramaRepository ePrograma,
                                                    IMapper mapper)
            {
                _ePrograma = ePrograma;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEProgramasResponse>>> Handle(GetAllEProgramasQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var EProgramaList = await _ePrograma.GetListAsync();

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEProgramasResponse
                var mappedEProgramas = _mapper.Map<List<GetAllEProgramasResponse>>(EProgramaList);

                return Result<List<GetAllEProgramasResponse>>.Success(mappedEProgramas);
            }
        }




    }
}
