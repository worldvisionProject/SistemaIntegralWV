using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Validators
{
    public class TerceroViewModelValidator : AbstractValidator<TerceroViewModel>
    {
        public TerceroViewModelValidator()
        {
            RuleFor(p => p.PrimerApellido)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               .MaximumLength(150).WithMessage("{PropertyName} no debe exceder 150 caracteres.");

            RuleFor(p => p.SegundoApellido)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull()
              .MaximumLength(150).WithMessage("{PropertyName} no debe exceder 150 caracteres.");

            RuleFor(p => p.PrimerNombre)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull()
              .MaximumLength(150).WithMessage("{PropertyName} no debe exceder 150 caracteres.");


            RuleFor(p => p.SegundoApellido)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull()
              .MaximumLength(150).WithMessage("{PropertyName} no debe exceder 150 caracteres.");

            RuleFor(p => p.Tipo)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.Genero)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();
            RuleFor(p => p.FecNacimiento)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();
         //   RuleFor(p => p.VigDesde)
         // .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
         // .NotNull();
         //   RuleFor(p => p.VigHasta)
         //.NotEmpty().WithMessage("{PropertyName} es obligatorio.")
         //.NotNull();


        }
    }
}
