using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;

namespace WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetAllCached
{
    public  class GetAllInteracionesQuery : IRequest<Result<List<GetAllInteracionesResponse>>>
    {

        public GetAllInteracionesQuery()
        {
        }
        public class GetAllInteracionesQueryHandler : IRequestHandler<GetAllInteracionesQuery, Result<List<GetAllInteracionesResponse>>>
        {
            private readonly IInteracionRepository _interacion;
            private readonly IMapper _mapper;


            //Ejecuta el select
            public GetAllInteracionesQueryHandler(IInteracionRepository interacion, IMapper mapper)
            {
                _interacion = interacion;
                _mapper = mapper;

            }

            public Task<Result<List<GetAllInteracionesResponse>>> Handle(GetAllInteracionesQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }


            //public  Task<Result<List<GetAllInteracionesResponse>>> Handle(GetAllInteracionesQuery request, CancellationToken cancellationToken)
            //{
            //    //var interacionList = await _interacion.GetListAsync();
            //    //var mappedInteracion= _mapper.Map<List<GetAllInteracionesResponse>>(interacionList);

            //    //return Result<List<GetAllInteracionesResponse>>.Success(mappedInteracion);
            //}
        }
    }
}
