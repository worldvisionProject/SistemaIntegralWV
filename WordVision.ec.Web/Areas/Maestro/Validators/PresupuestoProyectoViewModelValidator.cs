using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class PresupuestoProyectoViewModelValidator : AbstractValidator<PresupuestoProyectoViewModel>
    {
        public PresupuestoProyectoViewModelValidator()
        {
            RuleFor(p => p.Total)
           .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
           .NotNull();

            RuleFor(p => p.CostoSoporte)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.Nomina)
           .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
           .NotNull();

            RuleFor(p => p.TI)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.Administracion)
           .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
           .NotNull();

            RuleFor(p => p.LineamientosOnAdmistrativos)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();

            RuleFor(p => p.LineamientosOnOperativos)
           .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
           .NotNull();

            RuleFor(p => p.TechoPresupuestario)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();
        }        
    }
}
