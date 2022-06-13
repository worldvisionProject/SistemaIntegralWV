using FluentValidation;

namespace WordVision.ec.Web.Areas.Indicadores.Models
{
    public class VinculacionIndicadorViewModelValidator : AbstractValidator<VinculacionIndicadorViewModel>
    {
        public VinculacionIndicadorViewModelValidator()
        {
            RuleFor(p => p.Riesgos)
           .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
           .NotNull();

            RuleFor(p => p.PlanNacionalDesarrollo)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.CWB)
           .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
           .NotNull();
        }
    }
}
