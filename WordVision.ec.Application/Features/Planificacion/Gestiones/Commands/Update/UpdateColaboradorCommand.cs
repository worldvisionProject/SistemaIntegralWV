using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Update
{
    public class UpdateGestionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Anio { get; set; }

        public string Estado { get; set; }
        public decimal? Meta { get; set; }
        public decimal? Logro { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int IdEstrategia { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateGestionCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IGestionRepository _GestionRepository;

            public UpdateProductCommandHandler(IGestionRepository GestionRepository, IUnitOfWork unitOfWork)
            {
                _GestionRepository = GestionRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateGestionCommand command, CancellationToken cancellationToken)
            {
                var Gestion = await _GestionRepository.GetByIdAsync(command.Id);

                if (Gestion == null)
                {
                    return Result<int>.Fail($"Gestion no encontrado.");
                }
                else
                {
                    Gestion.Descripcion = command.Descripcion;
                    Gestion.Anio = command.Anio;
                    Gestion.Estado = command.Estado;
                    Gestion.Meta = command.Meta;
                    Gestion.Logro = command.Logro; 
                    Gestion.FechaDesde = command.FechaDesde;
                    Gestion.FechaHasta = command.FechaHasta;

                    await _GestionRepository.UpdateAsync(Gestion);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(Gestion.Id);
                }
            }
        }

    }
}
