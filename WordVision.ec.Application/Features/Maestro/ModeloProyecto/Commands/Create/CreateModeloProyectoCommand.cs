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

namespace WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Create
{
    public class CreateModeloProyectoCommand : ModeloProyectoResponse, IRequest<Result<int>>
    {
    }

    public class CreateModeloProyectoCommandHandler : IRequestHandler<CreateModeloProyectoCommand, Result<int>>
    {
        private readonly IModeloProyectoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateModeloProyectoCommandHandler(IModeloProyectoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateModeloProyectoCommand request, CancellationToken cancellationToken)
        {
            var modeloProyecto = _mapper.Map<Domain.Entities.Maestro.ModeloProyecto>(request);
            if (!await ValidateInsert(modeloProyecto))
            {
                await _repository.InsertAsync(modeloProyecto);
                await _unitOfWork.Commit(cancellationToken);
            }
            else
                return Result<int>.Fail($"ModeloProyecto con Código: {request.Codigo} ya existe.");

            return Result<int>.Success(modeloProyecto.Id);
        }

        private async Task<bool> ValidateInsert(Domain.Entities.Maestro.ModeloProyecto modeloProyecto)
        {
            bool exist = false;
            var list = await _repository.GetListAsync(modeloProyecto);
            if (list.Count > 0)
                exist = true;
            return exist;

        }
    }
}
