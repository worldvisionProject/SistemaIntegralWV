using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Documentos.Commands.Update
{
    public partial class UpdateDocumentoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAcepto { get; set; }
        public string Estado { get; set; }


        public class UpdateDocumentoCommandHandler : IRequestHandler<UpdateDocumentoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IDocumentoRepository _documentoRepository;

            public UpdateDocumentoCommandHandler(IDocumentoRepository documentoRepository, IUnitOfWork unitOfWork)
            {
                _documentoRepository = documentoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateDocumentoCommand command, CancellationToken cancellationToken)
            {
                var documento = await _documentoRepository.GetByIdAsync(command.Id);

                if (documento == null)
                {
                    return Result<int>.Fail($"Documento no encontrado.");
                }
                else
                {
                    documento.Titulo = command.Titulo ?? documento.Titulo;
                    documento.Descripcion = command.Descripcion ?? documento.Descripcion;
                    documento.DescripcionAcepto = command.DescripcionAcepto ?? documento.DescripcionAcepto;
                    documento.Estado = command.Estado ?? documento.Estado;
                   
                    await _documentoRepository.UpdateAsync(documento);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(documento.Id);
                }
            }
        }
    }
}
