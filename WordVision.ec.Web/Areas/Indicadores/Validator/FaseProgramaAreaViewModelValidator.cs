using FluentValidation;

namespace WordVision.ec.Web.Areas.Indicadores.Models
{
    public class FaseProgramaAreaViewModelValidator : AbstractValidator<FaseProgramaAreaViewModel>
    {
        public FaseProgramaAreaViewModelValidator()
        {
            RuleFor(p => p.FechaInicio)
            .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
            .NotNull();

            RuleFor(p => p.FechaFin)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.FechaDisenio)
            .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
            .NotNull();

            RuleFor(p => p.FechaRedisenio)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.FechaTransicion)
            .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
            .NotNull();

            RuleFor(p => p.FechaFin)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.Dip1)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.Dip2)
            .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
            .NotNull();

            RuleFor(p => p.Dip3)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.Dip4)
            .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
            .NotNull();

            RuleFor(p => p.Dip5)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();
        }
    }
}
