using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Commands.Update
{
    public class UpdateEstrategiaNacionalCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Programa { get; set; }
        public string Cwbo { get; set; }
        public string MetaRegional { get; set; }
        public string MetaNacional { get; set; }
        public int IdEmpresa { get; set; }
        public string Estado { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateEstrategiaNacionalCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEstrategiaNacionalRepository _EstrategiaNacionalRepository;

            public UpdateProductCommandHandler(IEstrategiaNacionalRepository EstrategiaNacionalRepository, IUnitOfWork unitOfWork)
            {
                _EstrategiaNacionalRepository = EstrategiaNacionalRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateEstrategiaNacionalCommand command, CancellationToken cancellationToken)
            {
                var EstrategiaNacional = await _EstrategiaNacionalRepository.GetByIdAsync(command.Id);

                if (EstrategiaNacional == null)
                {
                    return Result<int>.Fail($"EstrategiaNacional no encontrado.");
                }
                else
                {
                    EstrategiaNacional.Nombre = command.Nombre;
                    //EstrategiaNacional.Causa = command.Causa;
                    EstrategiaNacional.MetaRegional = command.MetaRegional;
                    EstrategiaNacional.MetaNacional = command.MetaNacional;
                    EstrategiaNacional.Estado = command.Estado;

                    await _EstrategiaNacionalRepository.UpdateAsync(EstrategiaNacional);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EstrategiaNacional.Id);
                }
            }
        }

    }
}
