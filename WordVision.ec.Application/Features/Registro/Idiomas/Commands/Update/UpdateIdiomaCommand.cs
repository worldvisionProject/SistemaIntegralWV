using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Idiomas.Commands.Update
{
    public class UpdateIdiomaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Hablado { get; set; }
        public decimal Escrito { get; set; }
        public int IdFormulario { get; set; }
        public class UpdateIdiomaCommandHandler : IRequestHandler<UpdateIdiomaCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IIdiomaRepository _idiomaRepository;

            public UpdateIdiomaCommandHandler(IIdiomaRepository idiomaRepository, IUnitOfWork unitOfWork)
            {
                _idiomaRepository = idiomaRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateIdiomaCommand command, CancellationToken cancellationToken)
            {
                var idioma = await _idiomaRepository.GetByIdAsync(command.Id);

                if (idioma == null)
                {
                    return Result<int>.Fail($"Idioma no encontrado.");
                }
                else
                {
                    idioma.Nombre = command.Nombre ?? idioma.Nombre;
                    idioma.Hablado = command.Hablado==0 ? idioma.Hablado:command.Hablado;
                    idioma.Escrito = command.Escrito == 0 ? idioma.Escrito : command.Escrito;

                    await _idiomaRepository.UpdateAsync(idioma);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(idioma.Id);
                }
            }

        }
    }
}
