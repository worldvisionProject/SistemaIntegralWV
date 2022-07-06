using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class RcNinoPatrocinadoViewModelValidator : AbstractValidator<RcNinoPatrocinadoViewModel>
    {
        public RcNinoPatrocinadoViewModelValidator()
        {
            RuleFor(p => p.Codigo)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull().WithMessage("{PropertyName} no null.");

            RuleFor(p => p.Cedula)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull().WithMessage("{PropertyName} no null.");

            RuleFor(p => p.Comunidad)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.Edad).NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .InclusiveBetween(1, 18).WithMessage("{PropertyName} debe estar entre 1 a 18 años");
        }
    }
}
