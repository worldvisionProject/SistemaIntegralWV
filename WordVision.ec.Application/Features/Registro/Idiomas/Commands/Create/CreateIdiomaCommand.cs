using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Registro.Idiomas.Commands.Create
{
    public class CreateIdiomaCommand : IRequest<Result<int>>
    {
        public string Nombre { get; set; }
        public decimal Hablado { get; set; }
        public decimal Escrito { get; set; }
        public int IdFormulario { get; set; }
    }

    public class CreateIdiomaCommandHandler : IRequestHandler<CreateIdiomaCommand, Result<int>>
    {
        private readonly IIdiomaRepository _idiomaRepository;

        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateIdiomaCommandHandler(IIdiomaRepository idiomaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _idiomaRepository = idiomaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateIdiomaCommand request, CancellationToken cancellationToken)
        {
            var idioma = _mapper.Map<Idioma>(request);
            await _idiomaRepository.InsertAsync(idioma);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(idioma.Id);
        }
    }
}
