using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Registro.Formularios.Commands.Create
{
   public class CreateFormularioCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string EstadoCivil { get; set; }
        public string FormacionAcademica { get; set; }
        public string PaisResidencia { get; set; }
        public string ProvinciaResidencia { get; set; }
        public string CiudadResidencia { get; set; }
        public string CalleResidencia { get; set; }
        public string NumCasaResidencia { get; set; }
        public string CalleSecundariaResidencia { get; set; }
        public string InfoResidencia { get; set; }
        public string SectorResidencia { get; set; }
        public string ReferenciaResidencia { get; set; }
        public string CodigoArea { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string CuentaBancaria { get; set; }

        public string CedulaExtranjero { get; set; }
        public string CiudadaniaExtranjero { get; set; }
        public DateTime? VigenciaDesde { get; set; }
        public DateTime? VigenciaHasta { get; set; }

        public string DobleCiudadaniaSN { get; set; }
        public string PaisCiudadania { get; set; }

        public string TipoDependiente { get; set; }
        public string PrimerApellidoDependiente { get; set; }
        public string SegundoApellidoDependiente { get; set; }
        public string PrimerNombreDependiente { get; set; }
        public string SegundoNombreDependiente { get; set; }
        public DateTime FecNacimientoDependiente { get; set; }
        public string CedulaDependiente { get; set; }
        public DateTime VigDesdeDependiente { get; set; }
        public DateTime VigHastaDependiente { get; set; }
        public string GeneroDependiente { get; set; }

        public string TipoSangre { get; set; }
        public string Preexistencia { get; set; }
        public string Alergias { get; set; }
        public string TipoContacto { get; set; }
        public string PrimerApellidoContacto { get; set; }
        public string SegundoApellidoContacto { get; set; }
        public string PrimerNombreContacto { get; set; }
        public string SegundoNombreContacto { get; set; }
        public int EdadContacto { get; set; }
        public string CodigoAreaContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public string CelularContacto { get; set; }
        public string EmailContacto { get; set; }

        public string Idioma { get; set; }
        public int PorcentajeHablado { get; set; }
        public int PorcentajeEscrito { get; set; }
        public string CreenciaReligiosa { get; set; }
        public string Iglesia { get; set; }
        public string Etnia { get; set; }
        public string DiscapacidadSN { get; set; }
        public string TipoDiscapacidad { get; set; }
        public int PorcentajeDiscapacidad { get; set; }
        public string FamiliaDiscapacidadSN { get; set; }
        public string FamiliaTipoDiscapacidad { get; set; }
        public int FamiliaPorcentajeDiscapacidad { get; set; }
        public string FamiliaDiscapacidad { get; set; }
        public string FamiliaDiscapacidadRelacion { get; set; }

        public int IdColaborador { get; set; }
        public byte[] Image { get; set; }
        public byte[] Pdf { get; set; }
    }

    public class CreateFormuarioCommandHandler : IRequestHandler<CreateFormularioCommand, Result<int>>
    {
        private readonly IFormularioRepository _formularioRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateFormuarioCommandHandler(IFormularioRepository formularioRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _formularioRepository = formularioRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateFormularioCommand request, CancellationToken cancellationToken)
        {
            var formulario = _mapper.Map<Formulario>(request);
            await _formularioRepository.InsertAsync(formulario);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(formulario.Id);
        }
    }
}
