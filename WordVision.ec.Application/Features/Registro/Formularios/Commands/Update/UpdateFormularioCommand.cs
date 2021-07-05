using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Registro.Formularios.Commands.Update
{
    public class UpdateFormularioCommand : IRequest<Result<int>>
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
        public byte[] Image { get; set; }
        public byte[] Pdf { get; set; }
        public int IdColaborador { get; set; }

        public Colaborador Colaboradores { get; set; }
        public class UpdateFormularioCommandHandler : IRequestHandler<UpdateFormularioCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IFormularioRepository _formularioRepository;

            public UpdateFormularioCommandHandler(IFormularioRepository formularioRepository, IUnitOfWork unitOfWork)
            {
                _formularioRepository = formularioRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateFormularioCommand command, CancellationToken cancellationToken)
            {
                var formulario = await _formularioRepository.GetByIdAsync(command.IdColaborador);

                if (formulario == null)
                {
                    return Result<int>.Fail($"Formulario no encontrado.");
                }
                else
                {
                    formulario.Colaboradores.Apellidos = command.Colaboradores.Apellidos ?? formulario.Colaboradores.Apellidos;
                    formulario.Colaboradores.ApellidoMaterno = command.Colaboradores.ApellidoMaterno ?? formulario.Colaboradores.ApellidoMaterno;
                    formulario.Colaboradores.PrimerNombre = command.Colaboradores.PrimerNombre ?? formulario.Colaboradores.PrimerNombre;
                    formulario.Colaboradores.SegundoNombre = command.Colaboradores.SegundoNombre ?? formulario.Colaboradores.SegundoNombre;
                    formulario.Colaboradores.Identificacion = command.Colaboradores.Identificacion ?? formulario.Colaboradores.Identificacion;
                    formulario.FechaNacimiento = command.FechaNacimiento;
                    formulario.Nacionalidad = command.Nacionalidad ?? formulario.Nacionalidad;
                    formulario.EstadoCivil = command.EstadoCivil ?? formulario.EstadoCivil;
                    formulario.FormacionAcademica = command.FormacionAcademica ?? formulario.FormacionAcademica;
                    formulario.PaisResidencia = command.PaisResidencia ?? formulario.PaisResidencia;
                    formulario.ProvinciaResidencia = command.ProvinciaResidencia ?? formulario.ProvinciaResidencia;
                    formulario.CiudadResidencia = command.CiudadResidencia ?? formulario.CiudadResidencia;
                    formulario.CalleResidencia = command.CalleResidencia ?? formulario.CalleResidencia;
                    formulario.NumCasaResidencia = command.NumCasaResidencia ?? formulario.NumCasaResidencia;
                    formulario.CalleSecundariaResidencia = command.CalleSecundariaResidencia ?? formulario.CalleSecundariaResidencia;
                    formulario.InfoResidencia = command.InfoResidencia ?? formulario.InfoResidencia;
                    formulario.SectorResidencia = command.SectorResidencia ?? formulario.SectorResidencia;
                    formulario.ReferenciaResidencia = command.ReferenciaResidencia ?? formulario.ReferenciaResidencia;
                    formulario.CodigoArea = command.CodigoArea ?? formulario.CodigoArea;
                    formulario.Telefono = command.Telefono ?? formulario.Telefono;
                    formulario.Celular = command.Celular ?? formulario.Celular;
                    formulario.Colaboradores.Email = command.Email ?? formulario.Colaboradores.Email;
                    formulario.CuentaBancaria = command.CuentaBancaria ?? formulario.CuentaBancaria;
                    formulario.CedulaExtranjero = command.CedulaExtranjero;// ?? formulario.CedulaExtranjero;
                    formulario.CiudadaniaExtranjero = command.CiudadaniaExtranjero;// ?? formulario.CiudadaniaExtranjero;
                    formulario.VigenciaDesde = command.VigenciaDesde;
                    formulario.VigenciaHasta = command.VigenciaHasta;
                    formulario.DobleCiudadaniaSN = command.DobleCiudadaniaSN;//?? formulario.DobleCiudadaniaSN;
                    formulario.PaisCiudadania = command.PaisCiudadania;// ?? formulario.PaisCiudadania;
                    //formulario.TipoDependiente = command.TipoDependiente ?? formulario.TipoDependiente;
                    //formulario.PrimerApellidoDependiente = command.PrimerApellidoDependiente ?? formulario.PrimerApellidoDependiente;
                    //formulario.SegundoApellidoDependiente = command.SegundoApellidoDependiente ?? formulario.SegundoApellidoDependiente;
                    //formulario.PrimerNombreDependiente = command.PrimerNombreDependiente ?? formulario.PrimerNombreDependiente;
                    //formulario.SegundoNombreDependiente = command.SegundoNombreDependiente ?? formulario.SegundoNombreDependiente;
                    //formulario.FecNacimientoDependiente = command.FecNacimientoDependiente;
                    //formulario.CedulaDependiente = command.CedulaDependiente ?? formulario.CedulaDependiente;
                    //formulario.VigDesdeDependiente = command.VigDesdeDependiente;
                    //formulario.VigHastaDependiente = command.VigHastaDependiente ;
                    //formulario.GeneroDependiente = command.GeneroDependiente ?? formulario.GeneroDependiente;
                    formulario.TipoSangre = command.TipoSangre ?? formulario.TipoSangre;
                    formulario.Preexistencia = command.Preexistencia ?? formulario.Preexistencia;
                    formulario.Alergias = command.Alergias ?? formulario.Alergias;
                    //formulario.TipoContacto = command.TipoContacto ?? formulario.TipoContacto;
                    //formulario.PrimerApellidoContacto = command.PrimerApellidoContacto ?? formulario.PrimerApellidoContacto;
                    //formulario.SegundoApellidoContacto = command.SegundoApellidoContacto ?? formulario.SegundoApellidoContacto;
                    //formulario.PrimerNombreContacto = command.PrimerNombreContacto ?? formulario.PrimerNombreContacto;
                    //formulario.SegundoNombreContacto = command.SegundoNombreContacto ?? formulario.SegundoNombreContacto;
                    //formulario.EdadContacto = (command.EdadContacto==0) ? formulario.EdadContacto:command.EdadContacto;
                    //formulario.CodigoAreaContacto = command.CodigoAreaContacto ?? formulario.CodigoAreaContacto;
                    //formulario.TelefonoContacto = command.TelefonoContacto ?? formulario.TelefonoContacto;
                    //formulario.CelularContacto = command.CelularContacto ?? formulario.CelularContacto;
                    //formulario.EmailContacto = command.EmailContacto ?? formulario.EmailContacto;
                    formulario.Idioma = command.Idioma ?? formulario.Idioma;
                    formulario.PorcentajeHablado = command.PorcentajeHablado==0 ? formulario.PorcentajeHablado: command.PorcentajeHablado;
                    formulario.PorcentajeEscrito = command.PorcentajeEscrito == 0 ? formulario.PorcentajeEscrito: command.PorcentajeEscrito;
                    formulario.CreenciaReligiosa = command.CreenciaReligiosa ?? formulario.CreenciaReligiosa;
                    formulario.Iglesia = command.Iglesia ?? formulario.Iglesia;
                    formulario.Etnia = command.Etnia ?? formulario.Etnia;
                    formulario.DiscapacidadSN = command.DiscapacidadSN ?? formulario.DiscapacidadSN;
                    formulario.TipoDiscapacidad = command.TipoDiscapacidad ?? formulario.TipoDiscapacidad;
                    formulario.PorcentajeDiscapacidad = command.PorcentajeDiscapacidad==0 ? formulario.PorcentajeDiscapacidad: command.PorcentajeDiscapacidad;
                    formulario.FamiliaDiscapacidadSN = command.FamiliaDiscapacidadSN ?? formulario.FamiliaDiscapacidadSN;
                    formulario.FamiliaTipoDiscapacidad = command.FamiliaTipoDiscapacidad ?? formulario.FamiliaTipoDiscapacidad;
                    formulario.FamiliaPorcentajeDiscapacidad = command.FamiliaPorcentajeDiscapacidad==0 ? formulario.FamiliaPorcentajeDiscapacidad: command.FamiliaPorcentajeDiscapacidad;
                    formulario.FamiliaDiscapacidad = command.FamiliaDiscapacidad?? formulario.FamiliaDiscapacidad;
                    formulario.FamiliaDiscapacidadRelacion = command.FamiliaDiscapacidadRelacion ?? formulario.FamiliaDiscapacidadRelacion;
                    formulario.IdColaborador = command.IdColaborador==0 ? formulario.IdColaborador: command.IdColaborador;
                    formulario.Image = command.Image.Length== 0 ? formulario.Image : command.Image;
                   
                    await _formularioRepository.UpdateAsync(formulario);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(formulario.Id);
                }
            }
        }
    }
}
