using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Validators
{
    public class ObjetivoEstrategicoViewModelValidator : AbstractValidator<ObjetivoEstrategicoViewModel>
    {
        public ObjetivoEstrategicoViewModelValidator()
        {
            RuleFor(p => p.Descripcion)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                ;
            //RuleFor(p => p.Programa)
            //   .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            //   .NotNull();

            //RuleFor(p => p.Cwbo)
            //   .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            //   .NotNull();
            //RuleFor(p => p.AreaPrioridad)
            //    .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            //    .NotNull();

            RuleFor(p => p.Categoria)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull();

            RuleFor(p => p.CargoResponsable)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull();


            RuleFor(p => p.Dimension)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();


        }
    }
}
