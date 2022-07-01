using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class LogFrameViewModelValidator : AbstractValidator<LogFrameViewModel>
    {
        public LogFrameViewModelValidator()
        {
            RuleFor(p => p.SumaryObjetives)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.OutCome)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();
        }


    }
}
