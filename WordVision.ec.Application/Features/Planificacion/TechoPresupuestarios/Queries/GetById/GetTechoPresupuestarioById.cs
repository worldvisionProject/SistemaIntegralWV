using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Queries.GetById
{
    public class GetTechoPresupuestarioById : IRequest<Result<GetTechoPresupuestarioByIdResponse>>
    {
        public int Id { get; set; }

        public class GetTechoPresupuestarioByIdHandler : IRequestHandler<GetTechoPresupuestarioById, Result<GetTechoPresupuestarioByIdResponse>>
        {
            private readonly ITechoPresupuestarioRepository _techoPresupuestarioRepository;
          
            private readonly IMapper _mapper;

            public GetTechoPresupuestarioByIdHandler(ITechoPresupuestarioRepository techoPresupuestarioRepository, IMapper mapper)
            {
                _techoPresupuestarioRepository = techoPresupuestarioRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetTechoPresupuestarioByIdResponse>> Handle(GetTechoPresupuestarioById query, CancellationToken cancellationToken)
            {
                var meta = await _techoPresupuestarioRepository.GetByIdAsync(query.Id);
                var mappedMeta = _mapper.Map<GetTechoPresupuestarioByIdResponse>(meta);

                return Result<GetTechoPresupuestarioByIdResponse>.Success(mappedMeta);
            }
        }
    }
}
