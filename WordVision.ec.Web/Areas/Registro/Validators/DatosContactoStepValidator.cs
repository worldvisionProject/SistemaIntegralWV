using FluentValidation;
using WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard;

namespace WordVision.ec.Web.Areas.Registro.Validators
{
    public class DatosContactoStepValidator : AbstractValidator<DatosContactoStep>
    {
        public DatosContactoStepValidator()
        {

            RuleFor(p => p.CalleResidencia)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .MaximumLength(50)
            .NotNull();

            RuleFor(p => p.CalleSecundariaResidencia)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .MaximumLength(50)
            .NotNull();

            RuleFor(p => p.Celular)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .MaximumLength(50)
            .NotNull();

            RuleFor(p => p.CiudadResidencia)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .MaximumLength(50)
            .NotNull();

            RuleFor(p => p.CodigoArea)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(5)
           .NotNull();

            RuleFor(p => p.CuentaBancaria)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(150)
           .NotNull();


            RuleFor(p => p.Email)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(150)
           .NotNull();

            RuleFor(p => p.InfoResidencia)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(50)
           .NotNull();

            RuleFor(p => p.NumCasaResidencia)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(50)
           .NotNull();

            RuleFor(p => p.PaisResidencia)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(50)
           .NotNull();

            RuleFor(p => p.ProvinciaResidencia)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(50)
           .NotNull();

            RuleFor(p => p.ReferenciaResidencia)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(50)
           .NotNull();

            RuleFor(p => p.SectorResidencia)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(50)
           .NotNull();

            RuleFor(p => p.Telefono)
          .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
          .MaximumLength(20)
          .NotNull();
        }
    }
}
