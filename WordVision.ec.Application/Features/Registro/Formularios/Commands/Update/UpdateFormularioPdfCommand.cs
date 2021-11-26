using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Formularios.Commands.Update
{
    public class UpdateFormularioPdfCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public byte[] Pdf { get; set; }
        public int IdColaborador { get; set; }

        public class UpdateFormularioPdfCommandHandler : IRequestHandler<UpdateFormularioPdfCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IFormularioRepository _formularioRepository;

            public UpdateFormularioPdfCommandHandler(IFormularioRepository formularioRepository, IUnitOfWork unitOfWork)
            {
                _formularioRepository = formularioRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateFormularioPdfCommand command, CancellationToken cancellationToken)
            {
                var formulario = await _formularioRepository.GetByIdAsync(command.IdColaborador);

                if (formulario == null)
                {
                    return Result<int>.Fail($"Formulario no encontrado.");
                }
                else
                {
                    formulario.Pdf = command.Pdf;

                    await _formularioRepository.UpdateAsync(formulario);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(formulario.Id);
                }
            }
        }
    }
}
