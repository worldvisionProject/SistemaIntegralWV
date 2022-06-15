using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class RcNinoPatrocinadoViewModelValidator : AbstractValidator<RcNinoPatrocinadoViewModel>
    {
        public RcNinoPatrocinadoViewModelValidator()
        {
            RuleFor(p => p.Codigo)
            .NotEmpty().WithMessage("{PropertyName} no espacio.")
            .NotNull().WithMessage("{PropertyName} no null.");

            RuleFor(p => p.Cedula)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("{PropertyName} no espacio.")
            .NotNull().WithMessage("{PropertyName} no null.");

            RuleFor(p => p.Comunidad)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.Edad).InclusiveBetween(1, 18)
                .WithMessage("{PropertyName} debe estar entre 1 a 18 años");
        }

        //public int Id { get; set; }

        //[Display(Name = "Código")]
        //[MaxLength(5, ErrorMessage = "Campo {0} no puede tener más de {1} caracteres.")]
        //[Required(ErrorMessage = "Campo Obligatorio.")]
        //public string Codigo { get; set; }

        //[Display(Name = "Cédula")]
        //[MaxLength(10, ErrorMessage = "Campo {0} no puede tener más de {1} caracteres.")]
        //[Required(ErrorMessage = "Campo Obligatorio.")]
        //public string Cedula { get; set; }

        //[Display(Name = "Nombre")]
        //[MaxLength(250, ErrorMessage = "Campo {0} no puede tener más de {1} caracteres.")]
        //[Required(ErrorMessage = "Campo Obligatorio.")]
        //public string Nombre { get; set; }

        //[Display(Name = "Comunidad")]
        //[MaxLength(250, ErrorMessage = "Campo {0} no puede tener más de {1} caracteres.")]
        //[Required(ErrorMessage = "Campo Obligatorio.")]
        //public string Comunidad { get; set; }

        //[Display(Name = "Edad")]
        //[MaxLength(3, ErrorMessage = "Campo {0} no puede tener más de {1} caracteres.")]
        //[Required(ErrorMessage = "Campo Obligatorio.")]
        //public int Edad { get; set; }

        //public bool Patrocinado { get; set; }

        //public int IdGrupoEtario { get; set; }
        //public DetalleCatalogoViewModel GrupoEtario { get; set; }

        //public int IdGenero { get; set; }
        //public DetalleCatalogoViewModel Genero { get; set; }

        //public int IdEstado { get; set; }
        //public DetalleCatalogoViewModel Estado { get; set; }

        //public int IdProgramaArea { get; set; }
        //public ProgramaAreaViewModelValidator ProgramaArea { get; set; }

        //public SelectList EstadoList { get; set; }
        //public SelectList GeneroList { get; set; }
        //public SelectList GrupoEtarioList { get; set; }
        //public SelectList ProgramaAreaList { get; set; }
    }
}
