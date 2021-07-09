using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Validators
{
    public class IndicadorEstrategicoViewModelValidator : AbstractValidator<IndicadorEstrategicoViewModel>
    {
        public IndicadorEstrategicoViewModelValidator()
        {
            RuleFor(p => p.IndicadorResultado)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                ;

            RuleFor(p => p.LineaBase)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               ;
            RuleFor(p => p.Meta)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               ;
            RuleFor(p => p.Responsable)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull()
              ;

            RuleFor(p => p.UnidadMedida)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull()
             ;

            RuleFor(p => p.MedioVerificacion)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull()
            ;

        }
    }
}
