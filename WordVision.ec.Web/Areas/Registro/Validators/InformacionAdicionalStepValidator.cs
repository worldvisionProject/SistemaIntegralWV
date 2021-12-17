using FluentValidation;
using WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard;

namespace WordVision.ec.Web.Areas.Registro.Validators
{
    public class InformacionAdicionalStepValidator : AbstractValidator<InformacionAdicionalStep>
    {
        public InformacionAdicionalStepValidator()
        {

            RuleFor(p => p.CreenciaReligiosa)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .MaximumLength(150)
            .NotNull();

            RuleFor(p => p.DiscapacidadSN)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .MaximumLength(1)
            .NotNull();

            RuleFor(p => p.Etnia)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .MaximumLength(60)
            .NotNull();

            RuleFor(p => p.FamiliaDiscapacidad)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .MaximumLength(50)
            .NotNull();

            RuleFor(p => p.FamiliaDiscapacidadRelacion)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(50)
           .NotNull();

            RuleFor(p => p.FamiliaDiscapacidadSN)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(1)
           .NotNull();

            //RuleFor(p => p.FamiliaPorcentajeDiscapacidad)
            //    .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            //.NotNull();

            RuleFor(p => p.FamiliaTipoDiscapacidad)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(50)
           .NotNull();

            RuleFor(p => p.Iglesia)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .MaximumLength(150)
           .NotNull();

            // RuleFor(customer => customer.Address.Postcode).NotNull().When(customer => customer.Address != null)

            // RuleFor(p => p.PorcentajeDiscapacidad)
            //.NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            //.NotNull();

            RuleFor(p => p.TipoDiscapacidad)
                .MaximumLength(50)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull();



            //RuleFor(p => p.Image).NotNull()
            //    .WithMessage("{PropertyName} es obligatorio.");
        }
    }
}
