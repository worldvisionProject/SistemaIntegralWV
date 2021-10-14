using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Soporte.Models;

namespace WordVision.ec.Web.Areas.Soporte.Validators
{
    public class SolicitudViewModelValidator : AbstractValidator<SolicitudViewModel>
    {
        public SolicitudViewModelValidator()
        {
            RuleFor(p => p.PersonaaContactar)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                .MaximumLength(15).WithMessage("{PropertyName} must not exceed 15 characters.");

            RuleFor(p => p.Telefono)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                .MaximumLength(15).WithMessage("{PropertyName} must not exceed 15 characters.");

            RuleFor(p => p.Celular)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               .MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.");

            //RuleFor(p => p.Archivo)
            //   .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            //   .NotNull();


            RuleFor(p => p.DescripcionTramite)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull().MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Direccion)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull().MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters."); 

            RuleFor(p => p.InformacionAdicional)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull().MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
    }
}
