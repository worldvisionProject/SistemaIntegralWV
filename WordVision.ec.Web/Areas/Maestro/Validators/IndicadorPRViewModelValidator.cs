using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class IndicadorPRViewModelValidator : AbstractValidator<IndicadorPRViewModel>
    {
        public IndicadorPRViewModelValidator()
        {
            RuleFor(p => p.Codigo)
            .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
            .NotNull();

            RuleFor(p => p.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.Asunciones)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();
        }
    }
}
