using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.Estructuras.Commands.Update
{
    public class UpdateEstructuraCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Designacion { get; set; }
        public int ReportaID { get; set; }
        public int Estado { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateEstructuraCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEstructuraRepository _EstructuraRepository;

            public UpdateProductCommandHandler(IEstructuraRepository EstructuraRepository, IUnitOfWork unitOfWork)
            {
                _EstructuraRepository = EstructuraRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateEstructuraCommand command, CancellationToken cancellationToken)
            {
                var estructura = await _EstructuraRepository.GetByIdAsync(command.Id);

                if (estructura == null)
                {
                    return Result<int>.Fail($"Estructura no encontrado.");
                }
                else
                {
                    estructura.Designacion = command.Designacion ?? estructura.Designacion;
                    estructura.ReportaID = command.ReportaID == 0 ? estructura.ReportaID : command.ReportaID;
                    estructura.Estado = command.Estado == 0 ? estructura.Estado : command.Estado;

                    await _EstructuraRepository.UpdateAsync(estructura);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(estructura.Id);
                }
            }
        }

    }
}
