using System.Collections.Generic;

using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    internal static class StepMapper
    {
        public static void EnrichClient(FormularioViewModel contact, IEnumerable<StepViewModel> steps)
        {
            foreach (var step in steps)
            {
                switch (step)
                {
                    case DatosPersonalesStep s:
                        contact.Colaboradores = s.Colaboradores;
                      
                        contact.EstadoCivil = s.EstadoCivil;
                        contact.FechaNacimiento = s.FechaNacimiento;
                        contact.FormacionAcademica = s.FormacionAcademica;
                        contact.Identificacion = s.Identificacion;
                        contact.Nacionalidad = s.Nacionalidad;
                        

                        break;
                    case DatosContactoStep s:
                        contact.CalleResidencia = s.CalleResidencia;
                        contact.CalleSecundariaResidencia = s.CalleSecundariaResidencia;
                        contact.Celular = s.Celular;
                        contact.CiudadResidencia = s.CiudadResidencia;
                        contact.CodigoArea = s.CodigoArea;
                        contact.CuentaBancaria = s.CuentaBancaria;
                        contact.Email = s.Email;
                        contact.InfoResidencia = s.InfoResidencia;
                        contact.NumCasaResidencia = s.NumCasaResidencia;
                        contact.PaisResidencia = s.PaisResidencia;
                        contact.ProvinciaResidencia = s.ProvinciaResidencia;
                        contact.ReferenciaResidencia = s.ReferenciaResidencia;
                        contact.SectorResidencia = s.SectorResidencia;
                        contact.Telefono = s.Telefono;
                        break;

                    case OtrosPaisStep s:
                        contact.CedulaExtranjero = s.CedulaExtranjero;
                        contact.CiudadaniaExtranjero = s.CiudadaniaExtranjero;
                        contact.DobleCiudadaniaSN = s.DobleCiudadaniaSN;
                        contact.PaisCiudadania = s.PaisCiudadania;
                        contact.VigenciaDesde = s.VigenciaDesde;
                        contact.VigenciaHasta = s.VigenciaHasta;

                        break;

                    case DependientesInformacionStep s:
                        contact.Id = s.Id;
                        contact.IdColaborador = s.IdColaborador;
                        contact.FormularioTerceros = s.FormularioTerceros;
                        break;

                    case SaludStep s:
                        contact.Alergias = s.Alergias;
                        contact.Preexistencia = s.Preexistencia;
                        contact.TipoSangre = s.TipoSangre;

                        break;

                    case ContactosStep s:
                        contact.Id = s.Id;
                        contact.IdColaborador = s.IdColaborador;
                        contact.FormularioTerceros = s.FormularioTerceros;

                        break;

                    case InformacionAdicionalStep s:
                        contact.CreenciaReligiosa = s.CreenciaReligiosa;
                        contact.DiscapacidadSN = s.DiscapacidadSN;
                        contact.Etnia = s.Etnia;
                        contact.FamiliaDiscapacidad = s.FamiliaDiscapacidad;
                        contact.FamiliaDiscapacidadRelacion = s.FamiliaDiscapacidadRelacion;
                        contact.FamiliaDiscapacidadSN = s.FamiliaDiscapacidadSN;
                        contact.FamiliaPorcentajeDiscapacidad = s.FamiliaPorcentajeDiscapacidad;
                        contact.FamiliaTipoDiscapacidad = s.FamiliaTipoDiscapacidad;
                        contact.Idioma = s.Idioma;
                        contact.Iglesia = s.Iglesia;
                        contact.PorcentajeDiscapacidad = s.PorcentajeDiscapacidad;
                        contact.PorcentajeEscrito = s.PorcentajeEscrito;
                        contact.PorcentajeHablado = s.PorcentajeHablado;
                        contact.TipoDiscapacidad = s.TipoDiscapacidad;
                        contact.Image = contact.Image;
                        //contact.Colaborador = s.Colaboradores.Apellidos + " " + contact.Colaboradores.ApellidoMaterno + " " + contact.Colaboradores.PrimerNombre + " " + contact.Colaboradores.SegundoNombre;
                        //contact.Identificacion = s.Colaboradores.Identificacion;
                        contact.ImageDiscapacidad = s.ImageDiscapacidad;
                        contact.ImageDiscapacidadFamiliar = s.ImageDiscapacidadFamiliar; 
                        contact.ImageCedula = s.ImageCedula;
                        contact.ImagePapeleta = s.ImagePapeleta;
                        contact.ImageCovid = s.ImageCovid;
                        break;
                }
            }
        }

        public static IEnumerable<StepViewModel> ToSteps(FormularioViewModel contact)
        {
            return new List<StepViewModel>
            {
                new DatosPersonalesStep {
                    Colaboradores= contact.Colaboradores,
            EstadoCivil = contact.EstadoCivil,
            FechaNacimiento = contact.FechaNacimiento,
            FormacionAcademica = contact.FormacionAcademica,
            Identificacion = contact.Identificacion,
            Nacionalidad = contact.Nacionalidad,
            
                },
            new DatosContactoStep { CalleResidencia = contact.CalleResidencia,
CalleSecundariaResidencia = contact.CalleSecundariaResidencia,
Celular = contact.Celular,
CiudadResidencia = contact.CiudadResidencia,
CodigoArea = contact.CodigoArea,
CuentaBancaria = contact.CuentaBancaria,
Email = contact.Colaboradores.Email,
InfoResidencia = contact.InfoResidencia,
NumCasaResidencia = contact.NumCasaResidencia,
PaisResidencia = contact.PaisResidencia,
ProvinciaResidencia = contact.ProvinciaResidencia,
ReferenciaResidencia = contact.ReferenciaResidencia,
SectorResidencia = contact.SectorResidencia,
Telefono = contact.Telefono
        },
            new OtrosPaisStep {
                CedulaExtranjero = contact.CedulaExtranjero,
CiudadaniaExtranjero = contact.CiudadaniaExtranjero,
DobleCiudadaniaSN = contact.DobleCiudadaniaSN,
PaisCiudadania = contact.PaisCiudadania,
VigenciaDesde = contact.VigenciaDesde,
VigenciaHasta = contact.VigenciaHasta
            },
             new DependientesInformacionStep {
                 Id = contact.Id,
IdColaborador = contact.IdColaborador,
FormularioTerceros = contact.FormularioTerceros
             },
              new SaludStep {
                  Alergias = contact.Alergias,
Preexistencia = contact.Preexistencia,
TipoSangre = contact.TipoSangre
              },
              new ContactosStep {
                   Id = contact.Id,
IdColaborador = contact.IdColaborador,
FormularioTerceros = contact.FormularioTerceros
              },
              new InformacionAdicionalStep {
                  Id=contact.Id,
                  CreenciaReligiosa = contact.CreenciaReligiosa,
DiscapacidadSN = contact.DiscapacidadSN,
Etnia = contact.Etnia,
FamiliaDiscapacidad = contact.FamiliaDiscapacidad,
FamiliaDiscapacidadRelacion = contact.FamiliaDiscapacidadRelacion,
FamiliaDiscapacidadSN = contact.FamiliaDiscapacidadSN,
FamiliaPorcentajeDiscapacidad = contact.FamiliaPorcentajeDiscapacidad,
FamiliaTipoDiscapacidad = contact.FamiliaTipoDiscapacidad,
Idioma = contact.Idioma,
Idiomas=contact.Idiomas,
Iglesia = contact.Iglesia,
PorcentajeDiscapacidad = contact.PorcentajeDiscapacidad,
PorcentajeEscrito = contact.PorcentajeEscrito,
PorcentajeHablado = contact.PorcentajeHablado,
TipoDiscapacidad = contact.TipoDiscapacidad,
Image=contact.Image,
Colaborador=contact.Colaboradores.Apellidos+" "+contact.Colaboradores.ApellidoMaterno+" "+contact.Colaboradores.PrimerNombre+" "+contact.Colaboradores.SegundoNombre,
Identificacion=contact.Colaboradores.Identificacion,
ImageDiscapacidad=contact.ImageDiscapacidad,
ImageDiscapacidadFamiliar=contact.ImageDiscapacidadFamiliar,ImageCedula=contact.ImageCedula,
            ImagePapeleta=contact.ImagePapeleta,
            ImageCovid=contact.ImageCovid
              }


            };
        }
    }
}