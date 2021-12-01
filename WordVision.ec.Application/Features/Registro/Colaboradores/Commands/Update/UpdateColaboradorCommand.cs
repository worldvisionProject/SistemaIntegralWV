using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Update
{
    public class UpdateColaboradorCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Apellidos { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string Identificacion { get; set; }

        public string Email { get; set; }
        public int Cargo { get; set; }

        public int Area { get; set; }

        public int LugarTrabajo { get; set; }

        public int IdEstructura { get; set; }
        public int Estado { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateColaboradorCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IColaboradorRepository _colaboradorRepository;

            public UpdateProductCommandHandler(IColaboradorRepository colaboradorRepository, IUnitOfWork unitOfWork)
            {
                _colaboradorRepository = colaboradorRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateColaboradorCommand command, CancellationToken cancellationToken)
            {
                var colaborador = await _colaboradorRepository.GetByIdAsync(command.Id);

                if (colaborador == null)
                {
                    return Result<int>.Fail($"Colaborador no encontrado.");
                }
                else
                {
                    colaborador.Apellidos = command.Apellidos ?? colaborador.Apellidos;
                    colaborador.ApellidoMaterno = command.ApellidoMaterno ?? colaborador.ApellidoMaterno;
                    colaborador.PrimerNombre = command.PrimerNombre ?? colaborador.PrimerNombre;
                    colaborador.SegundoNombre = command.SegundoNombre ?? colaborador.SegundoNombre;
                    colaborador.Identificacion = command.Identificacion ?? colaborador.Identificacion;
                    colaborador.Cargo = command.Cargo == 0 ? colaborador.Cargo : Convert.ToInt32(command.Cargo);
                    colaborador.Area = command.Area == 0 ? colaborador.Area : Convert.ToInt32(command.Area);
                    colaborador.LugarTrabajo = command.LugarTrabajo == 0 ? colaborador.LugarTrabajo : Convert.ToInt32(command.LugarTrabajo);
                    colaborador.Estado = command.Estado;
                    colaborador.IdEstructura = Convert.ToInt32(command.IdEstructura) == 0 ? colaborador.IdEstructura : Convert.ToInt32(command.IdEstructura);

                    await _colaboradorRepository.UpdateAsync(colaborador);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(colaborador.Id);
                }
            }
        }

    }
}
