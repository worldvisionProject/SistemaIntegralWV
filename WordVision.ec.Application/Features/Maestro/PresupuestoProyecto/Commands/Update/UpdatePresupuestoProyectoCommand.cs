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

namespace WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Commands.Update
{
    public class UpdatePresupuestoProyectoCommand : PresupuestoProyectoResponse, IRequest<Result<int>>
    {

    }

    public class UpdatePresupuestoProyectoCommandCommandHandler : IRequestHandler<UpdatePresupuestoProyectoCommand, Result<int>>
    {
        private readonly IPresupuestoProyectoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdatePresupuestoProyectoCommandCommandHandler(IPresupuestoProyectoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdatePresupuestoProyectoCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id);

            if (entity == null)
            {
                return Result<int>.Fail($"Presupuesto no encontrado.");
            }
            else
            {

                //var list = await _PresupuestoProyectoRepository.GetListAsync(new Domain.Entities.Maestro.PresupuestoProyecto());
                //if(list.Where(r=> (r.Codigo == update.Codigo || r.Cedula == update.Cedula) && r.Id != update.Id).Count() > 0)
                //  return Result<int>.Fail($"RC Niño Patrocinado con Código: {update.Codigo} o Cédula: {update.Cedula} ya existe.");

                entity.Total = update.Total;
                entity.CostoSoporte = update.CostoSoporte;
                entity.Nomina = update.Nomina;
                entity.TI = update.TI;
                entity.Administracion = update.Administracion;
                entity.LineamientosOnAdmistrativos = update.LineamientosOnAdmistrativos;
                entity.LineamientosOnOperativos = update.LineamientosOnOperativos;
                entity.TechoPresupuestario = update.TechoPresupuestario;
                entity.IdProgramaArea = update.IdProgramaArea;               
                entity.IdEstado = update.IdEstado;

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
