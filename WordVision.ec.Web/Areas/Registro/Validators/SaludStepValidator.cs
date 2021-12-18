using FluentValidation;
using WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard;

namespace WordVision.ec.Web.Areas.Registro.Validators
{
    public class SaludStepValidator : AbstractValidator<SaludStep>
    {
        public SaludStepValidator()
        {

            RuleFor(p => p.Preexistencia)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .MaximumLength(1500).WithMessage("{PropertyName} no debe exceder  caracteres.")
            .NotNull();

            RuleFor(p => p.Alergias)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .MaximumLength(1500).WithMessage("{PropertyName} no debe exceder  caracteres.")
            .NotNull();

            RuleFor(p => p.TipoSangre)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .MaximumLength(5).WithMessage("{PropertyName} no debe exceder  caracteres.")
            .NotNull();



        }
    }
}
