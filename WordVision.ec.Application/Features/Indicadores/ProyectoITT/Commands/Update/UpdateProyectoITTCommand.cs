﻿using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.ProyectoITT.Commands.Update
{
    public class UpdateProyectoITTCommand : ProyectoITTResponse, IRequest<Result<int>>
    {
    }

    public class UpdateProyectoITTCommandHandler : IRequestHandler<UpdateProyectoITTCommand, Result<int>>
    {
        private readonly IProyectoITTRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateProyectoITTCommandHandler(IProyectoITTRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateProyectoITTCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id);

            if (entity == null)
            {
                return Result<int>.Fail($"ProyectoITT no encontrada.");
            }
            else
            {
                entity.IdProgramaArea = update.IdProgramaArea;
                entity.IdProyectoTecnico = update.IdProyectoTecnico;
                entity.DetalleProyectoITTs = _mapper.Map<List<Domain.Entities.Indicadores.DetalleProyectoITT>>(update.DetalleProyectoITTs); ;

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
