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

namespace WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetById
{
    public  class GetInteracionesByIdQuery : IRequest<Result<GetInteracionesByIdResponse>>
    {
        public int Id { get; set; }

        public class GetInteracionesByIdQueryHandler : IRequestHandler<GetInteracionesByIdQuery, Result<GetInteracionesByIdResponse>>
        {
            private readonly IInteracionRepository _interacionRepository;



            private readonly IMapper _mapper;

            public GetInteracionesByIdQueryHandler(IInteracionRepository interacionRepository, IMapper mapper)
            {
                _interacionRepository = interacionRepository;

                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public Task<Result<GetInteracionesByIdResponse>> Handle(GetInteracionesByIdQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            //Devuelve todos la información de las entidades. 


            //public async Task<Result<GetInteracionesByIdResponse>> Handle(GetInteracionesByIdQuery query, CancellationToken cancellationToken)
            //{
            //    var interacion = await _interacionRepository.GetByIdAsync(query.Id);


            //    var mappedInteracion = _mapper.Map<GetInteracionesByIdResponse>(interacion);

            //    return Result<GetInteracionesByIdResponse>.Success(mappedInteracion);
            //}
        }
    }
}
