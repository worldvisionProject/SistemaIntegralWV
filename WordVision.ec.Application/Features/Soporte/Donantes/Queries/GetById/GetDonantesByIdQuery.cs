using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Donantes.Queries.GetById
{
    public class GetDonantesByIdQuery : IRequest<Result<GetDonantesByIdResponse>>
    {


        public int Id { get; set; }

        public class GetDonantesByIdQueryHandler : IRequestHandler<GetDonantesByIdQuery, Result<GetDonantesByIdResponse>>
        {
            private readonly IDonanteRepository _donantesRepository;



            private readonly IMapper _mapper;

            public GetDonantesByIdQueryHandler(IDonanteRepository donantesRepository, IMapper mapper)
            {
                _donantesRepository = donantesRepository;

                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            //Devuelve todos la información de las entidades. 
            public async Task<Result<GetDonantesByIdResponse>> Handle(GetDonantesByIdQuery query, CancellationToken cancellationToken)
            {
                var donantes = await _donantesRepository.GetByIdAsync(query.Id);


                var mappedDonantes = _mapper.Map<GetDonantesByIdResponse>(donantes);

                return Result<GetDonantesByIdResponse>.Success(mappedDonantes);
            }
        }
    }
}
