using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Queries.GetAll
{
    public class GetAllPresupuestoProyectoQuery : PresupuestoProyectoResponse, IRequest<Result<List<PresupuestoProyectoResponse>>>
    {
        
    }

    public class GetAllPresupuestoProyectoQueryHandler : IRequestHandler<GetAllPresupuestoProyectoQuery, Result<List<PresupuestoProyectoResponse>>>
    {
        private readonly IPresupuestoProyectoRepository _repository;
        private readonly IMapper _mapper;      

        public GetAllPresupuestoProyectoQueryHandler(IPresupuestoProyectoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<PresupuestoProyectoResponse>>> Handle(GetAllPresupuestoProyectoQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.PresupuestoProyecto>(request);
            var list = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<PresupuestoProyectoResponse>>(list);

            return Result<List<PresupuestoProyectoResponse>>.Success(responseList);
        }
    }
}
