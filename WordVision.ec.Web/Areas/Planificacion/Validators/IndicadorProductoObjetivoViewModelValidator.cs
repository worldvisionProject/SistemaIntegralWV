using FluentValidation;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Validators
{
    public class IndicadorProductoObjetivoViewModelValidator : AbstractValidator<IndicadorProductoObjetivoViewModel>
    {
        public IndicadorProductoObjetivoViewModelValidator()
        {
            RuleFor(p => p.Indicador)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                ;
         }
     }
}
