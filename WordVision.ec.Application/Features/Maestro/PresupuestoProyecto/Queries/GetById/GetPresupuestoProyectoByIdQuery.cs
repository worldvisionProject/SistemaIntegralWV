using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Queries.GetAll;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Queries.GetById
{
    public class GetPresupuestoProyectoByIdQuery : PresupuestoProyectoResponse, IRequest<Result<PresupuestoProyectoResponse>>
    {

    }

    public class GetPresupuestoProyectoByIdQueryHandler : IRequestHandler<GetPresupuestoProyectoByIdQuery, Result<PresupuestoProyectoResponse>>
    {
        private readonly IPresupuestoProyectoRepository _repository;
        private readonly IMapper _mapper;

        public GetPresupuestoProyectoByIdQueryHandler(IPresupuestoProyectoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<PresupuestoProyectoResponse>> Handle(GetPresupuestoProyectoByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<PresupuestoProyectoResponse>(result);

            return Result<PresupuestoProyectoResponse>.Success(response);
        }
    }
}
