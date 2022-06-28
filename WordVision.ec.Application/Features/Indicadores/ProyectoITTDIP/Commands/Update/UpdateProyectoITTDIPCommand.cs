using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.ProyectoITTDIP.Commands.Update
{
    public class UpdateProyectoITTDIPCommand : ProyectoITTDIPResponse, IRequest<Result<int>>
    {
    }

    public class UpdateProyectoITTDIPCommandHandler : IRequestHandler<UpdateProyectoITTDIPCommand, Result<int>>
    {
        private readonly IProyectoITTDIPRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateProyectoITTDIPCommandHandler(IProyectoITTDIPRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateProyectoITTDIPCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id);

            if (entity == null)
            {
                return Result<int>.Fail($"ProyectoITTDIP no encontrada.");
            }
            else
            {
                entity.IdProgramaArea = update.IdProgramaArea;
                entity.IdProyectoTecnico = update.IdProyectoTecnico;
                entity.DetalleProyectoITTDIPs = _mapper.Map<List<Domain.Entities.Indicadores.DetalleProyectoITTDIP>>(update.DetalleProyectoITTDIPs); ;

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
