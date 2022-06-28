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
    public class GetAllEParroquiasResponse
    {
        public string Id { get; set; }
        public string par_nombre { get; set; }
        public string EProgramaId { get; set; }
        public string ECantonId { get; set; }
        public virtual List<EComunidad> EComunidades { get; set; }
    }
    public class GetAllEParroquiasQuery : IRequest<Result<List<GetAllEParroquiasResponse>>>
    {
        public GetAllEParroquiasQuery()
        {
        }
        public class GetAllEParroquiasQueryHandler : IRequestHandler<GetAllEParroquiasQuery, Result<List<GetAllEParroquiasResponse>>>
        {
            private readonly IEParroquiaRepository _eParroquia;
            private readonly IMapper _mapper;

            public GetAllEParroquiasQueryHandler(IEParroquiaRepository eParroquia,
                                                    IMapper mapper)
            {
                _eParroquia = eParroquia;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEParroquiasResponse>>> Handle(GetAllEParroquiasQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var EParroquiaList = await _eParroquia.GetListAsync();

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEParroquiasResponse
                var mappedEParroquias = _mapper.Map<List<GetAllEParroquiasResponse>>(EParroquiaList);

                return Result<List<GetAllEParroquiasResponse>>.Success(mappedEParroquias);
            }
        }




    }
}
