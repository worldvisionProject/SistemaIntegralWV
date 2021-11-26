using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Registro
{
    public class Formulario : AuditableEntity
    {


        //[Required]
        public DateTime FechaNacimiento { get; set; }
        [StringLength(50)]
        //[Required]
        public string Nacionalidad { get; set; }
        [StringLength(50)]
        //[Required]
        public string EstadoCivil { get; set; }
        [StringLength(50)]
        //[Required]
        public string FormacionAcademica { get; set; }
        [StringLength(50)]
        //[Required]
        public string PaisResidencia { get; set; }
        [StringLength(50)]
        //[Required]
        public string ProvinciaResidencia { get; set; }
        [StringLength(50)]
        //[Required]
        public string CiudadResidencia { get; set; }
        [StringLength(50)]
        //[Required]
        public string CalleResidencia { get; set; }
        [StringLength(50)]
        //[Required]
        public string NumCasaResidencia { get; set; }

        [StringLength(50)]
        //[Required]
        public string CalleSecundariaResidencia { get; set; }

        [StringLength(50)]
        //[Required]
        public string InfoResidencia { get; set; }

        [StringLength(50)]
        //[Required]
        public string SectorResidencia { get; set; }

        [StringLength(50)]
        //[Required]
        public string ReferenciaResidencia { get; set; }
        [StringLength(5)]

        public string CodigoArea { get; set; }
        [StringLength(20)]

        public string Telefono { get; set; }
        [StringLength(50)]
        //[Required]
        public string Celular { get; set; }
        [StringLength(150)]
        //[Required]
        //public string Email { get; set; }
        //[StringLength(50)]

        public string CuentaBancaria { get; set; }

        [StringLength(20)]
        public string CedulaExtranjero { get; set; }

        [StringLength(50)]
        public string CiudadaniaExtranjero { get; set; }
        public DateTime? VigenciaDesde { get; set; }
        public DateTime? VigenciaHasta { get; set; }

        [StringLength(1)]
        public string DobleCiudadaniaSN { get; set; }
        [StringLength(50)]
        public string PaisCiudadania { get; set; }

        [StringLength(5)]
        //[Required]
        public string TipoSangre { get; set; }
        [StringLength(1500)]
        public string Preexistencia { get; set; }
        [StringLength(1500)]
        public string Alergias { get; set; }


        [StringLength(30)]
        public string Idioma { get; set; }
        public int PorcentajeHablado { get; set; }
        public int PorcentajeEscrito { get; set; }
        [StringLength(150)]
        public string CreenciaReligiosa { get; set; }
        [StringLength(150)]
        public string Iglesia { get; set; }
        [StringLength(60)]
        //[Required]
        public string Etnia { get; set; }
        [StringLength(1)]
        public string DiscapacidadSN { get; set; }
        [StringLength(50)]
        public string TipoDiscapacidad { get; set; }
        public int PorcentajeDiscapacidad { get; set; }
        [StringLength(1)]
        public string FamiliaDiscapacidadSN { get; set; }
        [StringLength(50)]
        public string FamiliaTipoDiscapacidad { get; set; }
        public int FamiliaPorcentajeDiscapacidad { get; set; }
        [StringLength(50)]
        public string FamiliaDiscapacidad { get; set; }
        [StringLength(50)]
        public string FamiliaDiscapacidadRelacion { get; set; }
        //[Required]
        public byte[] Image { get; set; }
        public byte[] Pdf { get; set; }
        public int IdColaborador { get; set; }

        public byte[] ImageCedula { get; set; }
        public byte[] ImagePapeleta { get; set; }
        public byte[] ImageCovid { get; set; }
        public byte[] ImageDiscapacidad { get; set; }
        public byte[] ImageDiscapacidadFamiliar { get; set; }
        public virtual Colaborador Colaboradores { get; set; }

        [ForeignKey("IdFormulario")]
        public virtual ICollection<FormularioTercero> FormularioTerceros { get; set; }

        [ForeignKey("IdFormulario")]
        public ICollection<Idioma> Idiomas { get; set; }
    }
}
