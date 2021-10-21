using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Validators
{
    public class ColaboradorViewModelValidator : AbstractValidator<ColaboradorViewModel>
    {
        public ColaboradorViewModelValidator()
        {
            RuleFor(p => p.Apellidos)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 caracteres.");

            RuleFor(p => p.PrimerNombre)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                .MaximumLength(150).WithMessage("{PropertyName} no debe exceder 150 caracteres.");

            RuleFor(p => p.SegundoNombre)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               .MaximumLength(150).WithMessage("{PropertyName} no debe exceder 150 caracteres.");

            RuleFor(p => p.Identificacion)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               .MaximumLength(13).WithMessage("{PropertyName} no debe exceder 13 caracteres.");


            RuleFor(p => p.Cargo)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            
            RuleFor(p => p.Area)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();

            RuleFor(p => p.LugarTrabajo)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
        }
    }
}
