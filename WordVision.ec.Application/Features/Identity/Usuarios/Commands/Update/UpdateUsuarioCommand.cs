using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Identity;

namespace WordVision.ec.Application.Features.Identity.Usuarios.Commands.Update
{
    public class UpdateUsuarioCommand : IRequest<Result<int>>
    {

        public int OID { get; set; }
        public string DisplayName { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }
        public string Company { get; set; }
        public string PhysicalDeliveryOfficeName { get; set; }
        public string Department { get; set; }
        public string UserName { get; set; }
        public string UserNameRegular { get; set; }
        public string Cedula { get; set; }

        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }


        public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IIdentityRepository _usuarioRepository;

            public UpdateUsuarioCommandHandler(IIdentityRepository usuarioRepository, IUnitOfWork unitOfWork)
            {
                _usuarioRepository = usuarioRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateUsuarioCommand command, CancellationToken cancellationToken)
            {
                var respuesta = await _usuarioRepository.GetByIdAsync(command.UserNameRegular);

                if (respuesta == null)
                {
                    return Result<int>.Fail($"Usuario no encontrado.");
                }
                else
                {
                    respuesta.ApellidoPaterno = command.ApellidoPaterno ?? respuesta.ApellidoPaterno;
                    respuesta.ApellidoMaterno = command.ApellidoMaterno ?? respuesta.ApellidoMaterno;
                    respuesta.PrimerNombre = command.PrimerNombre ?? respuesta.PrimerNombre;
                    respuesta.SegundoNombre = command.SegundoNombre ?? respuesta.SegundoNombre;

                    await _usuarioRepository.UpdateAsync(respuesta);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(respuesta.UserNameRegular);
                }
            }
        }
    }
}
