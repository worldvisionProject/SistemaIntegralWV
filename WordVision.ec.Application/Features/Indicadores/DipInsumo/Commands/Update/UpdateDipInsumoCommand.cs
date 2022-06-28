using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.DipInsumo.Commands.Update
{
    public class UpdateDipInsumoCommand : DipInsumoResponse, IRequest<Result<int>>
    {
    }

    public class UpdateDipInsumoCommandHandler : IRequestHandler<UpdateDipInsumoCommand, Result<int>>
    {
        private readonly IDipInsumoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateDipInsumoCommandHandler(IDipInsumoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateDipInsumoCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id);

            if (entity == null)
            {
                return Result<int>.Fail($"DipInsumo no encontrada.");
            }
            else
            {
                entity.Dip = update.Dip;
                entity.AnualMensual = update.AnualMensual;
                entity.IdLogFrameOutCome = update.IdLogFrameOutCome;
                entity.IdLogFrameOutPut = update.IdLogFrameOutPut;
                entity.DetalleDipInsumos = _mapper.Map<List<Domain.Entities.Indicadores.DetalleDipInsumo>>(update.DetalleDipInsumos); ;

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
