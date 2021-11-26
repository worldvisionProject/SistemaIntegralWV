using FluentValidation;
using WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard;

namespace WordVision.ec.Web.Areas.Registro.Validators
{
    public class DatosPersonalesStepValidator : AbstractValidator<DatosPersonalesStep>
    {
        public DatosPersonalesStepValidator()
        {

            RuleFor(p => p.FechaNacimiento)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.EstadoCivil)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.FormacionAcademica)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.Nacionalidad)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

        }
    }
}

