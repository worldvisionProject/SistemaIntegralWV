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
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Commands.Create
{
    public class CreateLogFrameIndicadorPRCommand : LogFrameIndicadorPRResponse, IRequest<Result<int>>
    {
    }

    public class CreateLogFrameIndicadorPRCommandHandler : IRequestHandler<CreateLogFrameIndicadorPRCommand, Result<int>>
    {
        private readonly ILogFrameIndicadorPRRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateLogFrameIndicadorPRCommandHandler(ILogFrameIndicadorPRRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateLogFrameIndicadorPRCommand request, CancellationToken cancellationToken)
        {

            //request.LogFrameIndicadorPRIndicadores = request.LogFrameIndicadorPRIndicadores.Where(l => l.Selected).ToList();
            var entity = _mapper.Map<Domain.Entities.Maestro.LogFrameIndicadorPR>(request);
            await _repository.InsertAsync(entity);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(entity.Id);
        }
    }
}
