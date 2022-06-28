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

namespace WordVision.ec.Application.Features.Maestro.OtroIndicador.Commands.Create
{
    public class CreateOtroIndicadorCommand : OtroIndicadorResponse, IRequest<Result<int>>
    {
    }

    public class CreateOtroIndicadorCommandHandler : IRequestHandler<CreateOtroIndicadorCommand, Result<int>>
    {
        private readonly IOtroIndicadorRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateOtroIndicadorCommandHandler(IOtroIndicadorRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateOtroIndicadorCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.OtroIndicador>(request);
            if (!await ValidateInsert(entity))
            {
                await _repository.InsertAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
            }
            else
                return Result<int>.Fail($"Indicador con Código: {request.Codigo} ya existe.");

            return Result<int>.Success(entity.Id);
        }

        private async Task<bool> ValidateInsert(Domain.Entities.Maestro.OtroIndicador entity)
        {
            bool exist = false;
            var list = await _repository.GetListAsync(entity);
            if (list.Count > 0)
                exist = true;
            return exist;

        }
    }
}
