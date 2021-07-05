using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Registro.Respuestas.Commands.Create
{
    public partial class CreateRespuestaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdDocumento { get; set; }
        public int IdPregunta { get; set; }
        public string DescRespuesta { get; set; }

    }

    public class CreateRespuestaCommandHandler : IRequestHandler<CreateRespuestaCommand, Result<int>>
    {
        private readonly IRespuestaRepository _respuestaRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateRespuestaCommandHandler(IRespuestaRepository respuestaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _respuestaRepository = respuestaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateRespuestaCommand request, CancellationToken cancellationToken)
        {
            var respuesta = _mapper.Map<Respuesta>(request);
            await _respuestaRepository.InsertAsync(respuesta);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(respuesta.Id);
        }
    }
}
