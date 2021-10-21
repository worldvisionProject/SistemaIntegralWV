using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Validators
{
    public class FormularioViewModelValidator : AbstractValidator<FormularioViewModel>
    {
        public FormularioViewModelValidator()
        {
            RuleFor(p => p.Nacionalidad)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 caracteres.");


            RuleFor(p => p.Colaboradores.Apellidos)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull().WithMessage("{PropertyName} es obligatorio.")
               .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 caracteres.");

            RuleFor(p => p.Colaboradores.ApellidoMaterno)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 caracteres.");

            RuleFor(p => p.Colaboradores.PrimerNombre)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                .MaximumLength(150).WithMessage("{PropertyName} no debe exceder 150 caracteres.");

            RuleFor(p => p.Colaboradores.SegundoNombre)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               .MaximumLength(150).WithMessage("{PropertyName} no debe exceder 150 caracteres.");

            RuleFor(p => p.Colaboradores.Identificacion)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               .MaximumLength(13).WithMessage("{PropertyName} no debe exceder 13 caracteres.");

            RuleFor(p => p.Colaboradores.Email)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();


            RuleFor(p => p.CalleResidencia)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            // .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 caracteres.");

            RuleFor(p => p.CalleSecundariaResidencia)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            // .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 caracteres.");

            RuleFor(p => p.NumCasaResidencia)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();

            RuleFor(p => p.Celular)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull();

            RuleFor(p => p.CuentaBancaria)
          .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
          .NotNull();
            // .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 caracteres.");
        }
    }
}
