using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProgramas
{
    public class GetAllEProgramasResponse : GenericResponse
    {
        public string Id { get; set; }
        public string pa_nombre { get; set; }

        public string NombreCompleto { get; set; }
        public virtual List<EProgramaIndicador> EProgramaIndicadores { get; set; }
        public virtual List<EParroquia> EParroquias { get; set; }


    }
    public class GetAllEProgramasQuery : GetAllEProgramasResponse, IRequest<Result<List<GetAllEProgramasResponse>>>
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
                var EProgramaList = await _ePrograma.GetListAsync(request.Include);

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEProgramasResponse
                var mappedEProgramas = _mapper.Map<List<GetAllEProgramasResponse>>(EProgramaList);

                //Cambiamos el Nombre Completo
                foreach (GetAllEProgramasResponse fila in mappedEProgramas)
                {
                    fila.NombreCompleto = "(" + fila.Id + ") " + fila.pa_nombre;
                }

                return Result<List<GetAllEProgramasResponse>>.Success(mappedEProgramas);
            }
        }




    }
}
