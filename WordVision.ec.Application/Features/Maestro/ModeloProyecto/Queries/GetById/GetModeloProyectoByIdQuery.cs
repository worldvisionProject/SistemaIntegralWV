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

namespace WordVision.ec.Application.Features.Maestro.ModeloProyecto.Queries.GetById
{
    public class GetModeloProyectoByIdQuery : ModeloProyectoResponse, IRequest<Result<ModeloProyectoResponse>>
    {
    }

    public class GetModeloProyectoByIdQueryHandler : IRequestHandler<GetModeloProyectoByIdQuery, Result<ModeloProyectoResponse>>
    {
        private readonly IModeloProyectoRepository _repository;
        private readonly IMapper _mapper;

        public GetModeloProyectoByIdQueryHandler(IModeloProyectoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ModeloProyectoResponse>> Handle(GetModeloProyectoByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<ModeloProyectoResponse>(result);

            return Result<ModeloProyectoResponse>.Success(response);
        }
    }
}
