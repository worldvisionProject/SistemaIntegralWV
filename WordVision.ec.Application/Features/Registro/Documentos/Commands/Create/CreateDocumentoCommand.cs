using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Contexts;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Registro.Documentos.Commands.Create
{
    public partial class CreateDocumentoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAcepto { get; set; }
        public string Estado { get; set; }
        public ICollection<WordVision.ec.Domain.Entities.Registro.Pregunta> Preguntas { get; set; }
    }

    public class CreateDocumentoCommandHandler : IRequestHandler<CreateDocumentoCommand, Result<int>>
    {
        private readonly IDocumentoRepository _documentoRepository;
        private readonly IPreguntaRepository _preguntaRepository;
        private readonly IMapper _mapper;
        private readonly IRegistroDbContext _context;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreateDocumentoCommandHandler(IDocumentoRepository documentoRepository, IPreguntaRepository preguntaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _documentoRepository = documentoRepository;
            _preguntaRepository = preguntaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateDocumentoCommand request, CancellationToken cancellationToken)
        {

            var documento = _mapper.Map<Documento>(request);
            await _documentoRepository.InsertAsync(documento);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(documento.Id);
        }
    }
}
