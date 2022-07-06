using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class OtroIndicadorViewModelValidator : AbstractValidator<OtroIndicadorViewModel>
    {
        public OtroIndicadorViewModelValidator()
        {
            RuleFor(p => p.Codigo)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();
        }      
    }
}
