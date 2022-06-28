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

namespace WordVision.ec.Application.Features.Maestro.ModeloProyecto.Queries.GetAll
{
    public class GetAllModeloProyectoQuery : ModeloProyectoResponse, IRequest<Result<List<ModeloProyectoResponse>>>
    {
    }

    public class GetAllModeloProyectoQueryHandler : IRequestHandler<GetAllModeloProyectoQuery, Result<List<ModeloProyectoResponse>>>
    {
        private readonly IModeloProyectoRepository _repository;
        private readonly IMapper _mapper;

        public GetAllModeloProyectoQueryHandler(IModeloProyectoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ModeloProyectoResponse>>> Handle(GetAllModeloProyectoQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.ModeloProyecto>(request);
            var list = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<ModeloProyectoResponse>>(list);

            return Result<List<ModeloProyectoResponse>>.Success(responseList);
        }
    }
}
