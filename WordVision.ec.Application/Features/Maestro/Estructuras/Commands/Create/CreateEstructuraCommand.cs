using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.Estructuras.Commands.Create
{

    public partial class CreateEstructuraCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Designacion { get; set; }
        public int ReportaID { get; set; }
        public int Estado { get; set; }

    }

    public class CreateEstructuraCommandHandler : IRequestHandler<CreateEstructuraCommand, Result<int>>
    {
        private readonly IEstructuraRepository _EstructuraRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateEstructuraCommandHandler(IEstructuraRepository EstructuraRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _EstructuraRepository = EstructuraRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateEstructuraCommand request, CancellationToken cancellationToken)
        {
            var estructura = _mapper.Map<Estructura>(request);
            await _EstructuraRepository.InsertAsync(estructura);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(estructura.Id);
        }
    }
}
