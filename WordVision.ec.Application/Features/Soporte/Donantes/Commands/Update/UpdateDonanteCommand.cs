using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Soporte.Donantes.Commands.Update
{
    public class UpdateDonanteCommand : IRequest<Result<int>>
    {
        public int IDHubspot { get; set; }

        public DateTime FechaConversion { get; set; }

        public int Canal { get; set; }
        public string Responsable { get; set; }
        public int Tipo { get; set; }
        public int Categoria { get; set; }
        public int Campana { get; set; }
        public int EstadoDonante { get; set; }

        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Genero { get; set; }
        public int Cedula { get; set; }
        public int RUC { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public int Region { get; set; }
        public int Provincia { get; set; }

        public int Ciudad { get; set; }
        public string Direccion { get; set; }
        public int TelefonoConvencional { get; set; }
        public int TelefonoCelular { get; set; }
        public bool WhatsApp { get; set; }
        public string Email { get; set; }
        public int FrecuenciaDonacion { get; set; }
        public int Cantidad { get; set; }
        public DateTime MesInicialDebito { get; set; }

        public int FormaPago { get; set; }
        public int NumReferencia { get; set; }
        public int TipoCuenta { get; set; }
        public int NumeroCuenta { get; set; }
        public int TiposTarjetasCredito { get; set; }
        public int NumeroTarjeta { get; set; }

        public DateTime FechaCaducidad { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Banco { get; set; }
        public class UpdateDonanteCommandHandler : IRequestHandler<UpdateDonanteCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IDonanteRepository _donanteRepository;
            private readonly IMapper _mapper;

            public UpdateDonanteCommandHandler(IDonanteRepository donanteRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _donanteRepository = donanteRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateDonanteCommand command, CancellationToken cancellationToken)
            {
                //devuelve toda la fila
                var Donante = await _donanteRepository.GetByIdAsync(command.IDHubspot);

                if (Donante == null)
                {
                    return Result<int>.Fail($"Donante no encontrado.");
                }
                else
                {
                    Donante.EstadoDonante = command.EstadoDonante == 0 ? Donante.EstadoDonante : command.EstadoDonante;
                    Donante.FrecuenciaDonacion = command.FrecuenciaDonacion == 0 ? Donante.FrecuenciaDonacion : command.FrecuenciaDonacion;
                    Donante.Cantidad = command.Cantidad == 0 ? Donante.Cantidad : command.Cantidad;
                    Donante.Campana = command.Campana == 0 ? Donante.Campana : command.Campana;
                    Donante.Canal = command.Canal == 0 ? Donante.Canal : command.Canal;
                    Donante.Categoria = command.Categoria == 0 ? Donante.Categoria : command.Categoria;
                    Donante.FormaPago = command.FormaPago == 0 ? Donante.FormaPago : command.FormaPago;

                    

                    await _donanteRepository.UpdateAsync(Donante);

                    
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(Donante.Id);
                }
            }
        }


    }
}
