using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Donantes.Commands.Create
{
    public partial class CreateDonanteCommand : IRequest<Result<int>>
    {
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
        public decimal? Cantidad { get; set; }
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
        public string ComentarioActualizacion { get; set; }
        public string ComentarioResolucion { get; set; }
    }
    public class CreateDonanteCommandHandler : IRequestHandler<CreateDonanteCommand, Result<int>>
    {
        private readonly IDonanteRepository _donanteRepository;


        private readonly IMapper _mapper;//coge los campos de la interfaz con la bbdd hace un mapeo

        private IUnitOfWork _unitOfWork { get; set; }// hace la transaccionabilidad crea la cabecera y luego detalle



        public CreateDonanteCommandHandler(IDonanteRepository donanteRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _donanteRepository = donanteRepository;

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //ejecuta directamene desde a interfaz el controaldor
        public async Task<Result<int>> Handle(CreateDonanteCommand request, CancellationToken cancellationToken)
        {
            var donante = _mapper.Map<Donante>(request);//mapea
            await _donanteRepository.InsertAsync(donante);//INsertar a la BBDD


            await _unitOfWork.Commit(cancellationToken);//commit
            return Result<int>.Success(donante.Id);//devuelve le id existoso de la persona
        }
    }

}
