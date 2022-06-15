using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Queries.GetAll;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Commands.Update
{
    public class UpdateRCNinoPatrocinadoCommand : RCNinoPatrocinadoResponse, IRequest<Result<int>>
    {

    }

    public class UpdateRCNinoPatrocinadoCommandCommandHandler : IRequestHandler<UpdateRCNinoPatrocinadoCommand, Result<int>>
    {
        private readonly IRCNinoPatrocinadoRepository _rCNinoPatrocinadoRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateRCNinoPatrocinadoCommandCommandHandler(IRCNinoPatrocinadoRepository rCNinoPatrocinadoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _rCNinoPatrocinadoRepository = rCNinoPatrocinadoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateRCNinoPatrocinadoCommand update, CancellationToken cancellationToken)
        {
            var rcPatrocinado = await _rCNinoPatrocinadoRepository.GetByIdAsync(update.Id);

            if (rcPatrocinado == null)
            {
                return Result<int>.Fail($"RC Niño Patrocinado no encontrado.");
            }
            else
            {

                var list = await _rCNinoPatrocinadoRepository.GetListAsync(new Domain.Entities.Maestro.RCNinoPatrocinado());
                if(list.Where(r=> (r.Codigo == update.Codigo || r.Cedula == update.Cedula) && r.Id != update.Id).Count() > 0)
                  return Result<int>.Fail($"RC Niño Patrocinado con Código: {update.Codigo} o Cédula: {update.Cedula} ya existe.");

                rcPatrocinado.Codigo = update.Codigo;
                rcPatrocinado.Cedula = update.Cedula;
                rcPatrocinado.Nombre = update.Nombre;
                rcPatrocinado.Comunidad = update.Comunidad;
                rcPatrocinado.Edad = update.Edad;
                rcPatrocinado.Patrocinado = update.Patrocinado;
                rcPatrocinado.IdEstado = update.IdEstado;
                rcPatrocinado.IdProgramaArea = update.IdProgramaArea;
                rcPatrocinado.IdGenero = update.IdGenero;
                rcPatrocinado.IdGrupoEtario = update.IdGrupoEtario;

                await _rCNinoPatrocinadoRepository.UpdateAsync(rcPatrocinado);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(rcPatrocinado.Id);
            }
        }
    }
}
