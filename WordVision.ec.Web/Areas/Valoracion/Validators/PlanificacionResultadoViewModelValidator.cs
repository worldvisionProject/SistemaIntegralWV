using FluentValidation;
using WordVision.ec.Web.Areas.Valoracion.Models;

namespace WordVision.ec.Web.Areas.Valoracion.Validators
{
    public class PlanificacionResultadoViewModelValidator : AbstractValidator<PlanificacionResultadoViewModel>
    {
        public PlanificacionResultadoViewModelValidator()
        { 
               RuleFor(p => p.Meta)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull();
            RuleFor(p => p.FechaFin)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.FechaInicio)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.Ponderacion)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();

        }
    }
}
