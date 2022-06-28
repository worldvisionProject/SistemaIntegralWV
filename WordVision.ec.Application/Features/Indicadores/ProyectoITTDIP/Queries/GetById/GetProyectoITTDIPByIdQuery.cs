using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.ProyectoITTDIP.Queries.GetById
{
    public class GetProyectoITTDIPByIdQuery : ProyectoITTDIPResponse, IRequest<Result<ProyectoITTDIPResponse>>
    {
    }

    public class GetProyectoITTDIPByIdQueryHandler : IRequestHandler<GetProyectoITTDIPByIdQuery, Result<ProyectoITTDIPResponse>>
    {
        private readonly IProyectoITTDIPRepository _repository;
        private readonly IMapper _mapper;

        public GetProyectoITTDIPByIdQueryHandler(IProyectoITTDIPRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ProyectoITTDIPResponse>> Handle(GetProyectoITTDIPByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<ProyectoITTDIPResponse>(result);

            return Result<ProyectoITTDIPResponse>.Success(response);
        }
    }
}
