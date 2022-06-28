using FluentValidation;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Validators
{
    public class IndicadorCicloEstrategicoViewModelValidator : AbstractValidator<IndicadorCicloEstrategicoViewModel>
    {
        public IndicadorCicloEstrategicoViewModelValidator()
        {
            RuleFor(p => p.IndicadorCiclo)
                  .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                  .NotNull()
                  ;
            RuleFor(p => p.TipoMeta)
                  .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                  .NotNull()
                  ;
            RuleFor(p => p.TipoIndicador)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                ;
            RuleFor(p => p.CodigoIndicador)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               ;
            RuleFor(p => p.UnidadMedida)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               ;
            RuleFor(p => p.ActorParticipante)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               ;
        }
    }
}
