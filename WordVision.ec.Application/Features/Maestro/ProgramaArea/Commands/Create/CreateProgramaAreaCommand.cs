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

namespace WordVision.ec.Application.Features.Maestro.ProgramaArea.Commands.Create
{
    public class CreateProgramaAreaCommand : ProgramaAreaResponse, IRequest<Result<int>>
    {
    }

    public class CreateProgramaAreaCommandHandler : IRequestHandler<CreateProgramaAreaCommand, Result<int>>
    {
        private readonly IProgramaAreaRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateProgramaAreaCommandHandler(IProgramaAreaRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateProgramaAreaCommand request, CancellationToken cancellationToken)
        {
            var programaArea = _mapper.Map<Domain.Entities.Maestro.ProgramaArea>(request);
            if (!await ValidateInsert(programaArea))
            {
                await _repository.InsertAsync(programaArea);
                await _unitOfWork.Commit(cancellationToken);
            }
            else
                return Result<int>.Fail($"ProgramaArea con Código: {request.Codigo} ya existe.");

            return Result<int>.Success(programaArea.Id);
        }

        private async Task<bool> ValidateInsert(Domain.Entities.Maestro.ProgramaArea programaArea)
        {
            bool exist = false;
            var list = await _repository.GetListAsync(programaArea);
            if (list.Count > 0)
                exist = true;
            return exist;

        }
    }
}
