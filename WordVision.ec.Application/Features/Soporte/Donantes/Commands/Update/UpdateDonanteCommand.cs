using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Donantes.Commands.Update
{
    public class UpdateDonanteCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }


        public DateTime? FechaConversion { get; set; }
        public byte[] EvidenciaConversion { get; set; }
        public int Canal { get; set; }
        public int Responsable { get; set; }
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
        public string RUC { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public int Region { get; set; }
        public int Provincia { get; set; }

        public int Ciudad { get; set; }
        public string Direccion { get; set; }
        public string CodigoArea { get; set; }
        public string TelefonoConvencional { get; set; }
        public string TelefonoCelular { get; set; }
        public bool WhatsApp { get; set; }
        public string Email { get; set; }
        public int FrecuenciaDonacion { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime? MesInicialDebito { get; set; }

        public int FormaPago { get; set; }
        public string NumReferencia { get; set; }
        public int? TipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public int? TiposTarjetasCredito { get; set; }
        public string NumeroTarjeta { get; set; }

        public DateTime? FechaCaducidad { get; set; }

        public int? Banco { get; set; }

        public string NumReferenciaBp { get; set; }
        public int? TipoCuentaBp { get; set; }
        public string NumeroCuentaBp { get; set; }
        public int? TiposTarjetasCreditoBp { get; set; }
        public string NumeroTarjetaBp { get; set; }
        public DateTime? FechaCaducidadBp { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? BancoBp { get; set; }
        public int? EsAdmin { get; set; }
        public string ComentarioActualizacion { get; set; }
        public string ComentarioResolucion { get; set; }

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
                var Donante = await _donanteRepository.GetByIdAsync(command.Id);

                if (Donante == null)
                {
                    return Result<int>.Fail($"Donante no encontrado.");
                }
                else
                {
                    if (command.EsAdmin==null)
                    {
                        Donante.EstadoDonante = command.EstadoDonante == 0 ? Donante.EstadoDonante : command.EstadoDonante;
                    Donante.FrecuenciaDonacion = command.FrecuenciaDonacion == 0 ? Donante.FrecuenciaDonacion : command.FrecuenciaDonacion;
                    Donante.Cantidad = command.Cantidad == 0 ? Donante.Cantidad : command.Cantidad;
                    Donante.Campana = command.Campana == 0 ? Donante.Campana : command.Campana;
                    Donante.Canal = command.Canal == 0 ? Donante.Canal : command.Canal;
                    Donante.Categoria = command.Categoria == 0 ? Donante.Categoria : command.Categoria;
                    Donante.FormaPago = command.FormaPago == 0 ? Donante.FormaPago : command.FormaPago;
                    Donante.Apellido1 = command.Apellido1;
                    Donante.Apellido2 = command.Apellido2;
                    Donante.Nombre1 = command.Nombre1;
                    Donante.Nombre2 = command.Nombre2;
                    Donante.Banco = command.Banco == 0 ? Donante.Banco : command.Banco;
                    Donante.Cedula = command.Cedula == 0 ? Donante.Cedula : command.Cedula;
                    Donante.Ciudad = command.Ciudad == 0 ? Donante.Ciudad : command.Ciudad;
                    Donante.Direccion = command.Direccion;
                    Donante.Edad = command.Edad == 0 ? Donante.Edad : command.Edad;
                    Donante.Email = command.Email;
                    Donante.EstadoDonante = command.EstadoDonante == 0 ? Donante.EstadoDonante : command.EstadoDonante;
                    Donante.FechaCaducidad = command.FechaCaducidad;
                    Donante.FechaConversion = command.FechaConversion;
                    Donante.FechaNacimiento = command.FechaNacimiento;
                    Donante.FechaVencimiento = command.FechaVencimiento;
                    Donante.Genero = command.Genero == 0 ? Donante.Genero : command.Genero;

                    Donante.NumeroCuenta = command.NumeroCuenta;
                    Donante.NumReferencia = command.NumReferencia;
                    Donante.Provincia = command.Provincia == 0 ? Donante.Provincia : command.Provincia;
                    Donante.Region = command.Region == 0 ? Donante.Region : command.Region;
                    Donante.Responsable = command.Responsable;
                    Donante.RUC = command.RUC;
                    Donante.TelefonoCelular = command.TelefonoCelular;
                    Donante.CodigoArea=command.CodigoArea;

                    Donante.TelefonoConvencional = command.TelefonoConvencional;
                    Donante.Tipo = command.Tipo == 0 ? Donante.Tipo : command.Tipo;
                    Donante.TipoCuenta = command.TipoCuenta == 0 ? Donante.TipoCuenta : command.TipoCuenta;
                    Donante.TiposTarjetasCredito = command.TiposTarjetasCredito == 0 ? Donante.TiposTarjetasCredito : command.TiposTarjetasCredito;
                    Donante.WhatsApp = command.WhatsApp;
                    Donante.NumeroTarjeta = command.NumeroTarjeta;

                    Donante.NumReferenciaBp = command.NumReferenciaBp;
                    Donante.TipoCuentaBp = command.TipoCuentaBp == 0 ? Donante.TipoCuentaBp : command.TipoCuentaBp;
                    Donante.NumeroCuentaBp = command.NumeroCuentaBp;
                    Donante.TiposTarjetasCreditoBp = command.TiposTarjetasCreditoBp == 0 ? Donante.TiposTarjetasCreditoBp : command.TiposTarjetasCreditoBp;
                    Donante.NumeroTarjetaBp = command.NumeroTarjetaBp;
                    Donante.FechaCaducidadBp = command.FechaCaducidadBp;
                    Donante.BancoBp = command.BancoBp == 0 ? Donante.BancoBp : command.BancoBp;
                        Donante.ComentarioResolucion = command.ComentarioResolucion;
                    }
                    else
                    {
                        Donante.ComentarioActualizacion = command.ComentarioActualizacion;
                        
                    }
                       

                    await _donanteRepository.UpdateAsync(Donante);


                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(Donante.Id);
                }
            }
        }


    }
}
