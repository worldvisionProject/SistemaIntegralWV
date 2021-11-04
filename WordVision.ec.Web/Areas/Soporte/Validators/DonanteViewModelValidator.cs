using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Soporte.Models;

namespace WordVision.ec.Web.Areas.Soporte.Validators
{
    public class DonanteViewModelValidator : AbstractValidator<DonanteViewModel>
    {
        public DonanteViewModelValidator()
        {
         
            RuleFor(p => p.FormaPago)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.Campana)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull();
            RuleFor(p => p.Nombre1)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull().MaximumLength(150).WithMessage("{PropertyName} No debe exceder 150 caracteres.");
            RuleFor(p => p.Apellido1)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull().MaximumLength(150).WithMessage("{PropertyName} No debe exceder 150 caracteres.");
            RuleFor(p => p.Apellido2)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull().MaximumLength(150).WithMessage("{PropertyName} No debe exceder 150 caracteres.");
            RuleFor(p => p.Nombre2)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull().MaximumLength(150).WithMessage("{PropertyName} No debe exceder 150 caracteres.");
            RuleFor(p => p.Canal)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.Categoria)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.Cedula)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.Ciudad)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.Direccion)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull().MaximumLength(250).WithMessage("{PropertyName} No debe exceder 250 caracteres.");
            RuleFor(p => p.Edad)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.Email)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.EstadoDonante)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.FechaConversion)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.FechaNacimiento)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.Genero)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.Provincia)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.Region)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();
            RuleFor(p => p.Responsable)
                        .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                        .NotNull();
            RuleFor(p => p.RUC)
                        .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                        .NotNull().MaximumLength(13).WithMessage("{PropertyName} No debe exceder 15 caracteres.");
            RuleFor(p => p.TelefonoCelular)
                        .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                        .NotNull().MaximumLength(15).WithMessage("{PropertyName} No debe exceder 15 caracteres.");
            RuleFor(p => p.TelefonoConvencional)
                        .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                        .NotNull().MaximumLength(15).WithMessage("{PropertyName} No debe exceder 15 caracteres.");
            RuleFor(p => p.Tipo)
                        .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                        .NotNull();
          

        }
    }
}
