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
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull().GreaterThanOrEqualTo(0);

            RuleFor(p => p.CostoSoporte)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull().GreaterThanOrEqualTo(0); 

            RuleFor(p => p.Nomina)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull().GreaterThanOrEqualTo(0);

            RuleFor(p => p.TI)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull().GreaterThanOrEqualTo(0);

            RuleFor(p => p.Administracion)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull().GreaterThanOrEqualTo(0);

            RuleFor(p => p.LineamientosOnAdmistrativos)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull().GreaterThanOrEqualTo(0);

            RuleFor(p => p.LineamientosOnOperativos)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull().GreaterThanOrEqualTo(0);

            RuleFor(p => p.TechoPresupuestario)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull().GreaterThanOrEqualTo(0);
        }        
    }
}
