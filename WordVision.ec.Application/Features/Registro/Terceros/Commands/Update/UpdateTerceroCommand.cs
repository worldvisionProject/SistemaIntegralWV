using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Terceros.Commands.Update
{
    public class UpdateTerceroCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Identificacion { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public DateTime? FecNacimiento { get; set; }
        public string? Genero { get; set; }
        public DateTime? VigDesde { get; set; }
        public DateTime? VigHasta { get; set; }

        public string CodigoArea { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public byte[] ImageCedula { get; set; }

        public class UpdateTerceroCommandHandler : IRequestHandler<UpdateTerceroCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ITerceroRepository _terceroRepository;

            public UpdateTerceroCommandHandler(ITerceroRepository terceroRepository, IUnitOfWork unitOfWork)
            {
                _terceroRepository = terceroRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateTerceroCommand command, CancellationToken cancellationToken)
            {
                var tercero = await _terceroRepository.GetByIdAsync(command.Id);

                if (tercero == null)
                {
                    return Result<int>.Fail($"Tercero no encontrado.");
                }
                else
                {
                    tercero.PrimerApellido = command.PrimerApellido ?? tercero.PrimerApellido;
                    tercero.SegundoApellido = command.SegundoApellido ?? tercero.SegundoApellido;
                    tercero.PrimerNombre = command.PrimerNombre ?? tercero.PrimerNombre;
                    tercero.SegundoNombre = command.SegundoNombre ?? tercero.SegundoNombre;
                    tercero.Identificacion = command.Identificacion ?? tercero.Identificacion;
                    tercero.FecNacimiento = command.FecNacimiento;
                    tercero.Genero = command.Genero ?? tercero.Genero;
                    tercero.VigDesde = command.VigDesde;
                    tercero.VigHasta = command.VigHasta;
                    tercero.CodigoArea = command.CodigoArea ?? tercero.CodigoArea;
                    tercero.Telefono = command.Telefono ?? tercero.Telefono;
                    tercero.Celular = command.Celular ?? tercero.Celular;
                    tercero.Email = command.Email ?? tercero.Email;
                    tercero.Tipo = command.Tipo ?? tercero.Tipo;
                    tercero.ImageCedula = command.ImageCedula ?? tercero.ImageCedula;

                    await _terceroRepository.UpdateAsync(tercero);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(tercero.Id);
                }
            }

        }
    }
}
