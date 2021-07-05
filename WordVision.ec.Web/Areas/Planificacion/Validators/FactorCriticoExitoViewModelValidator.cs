using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Validators
{
    public class FactorCriticoExitoViewModelValidator : AbstractValidator<FactorCriticoExitoViewModel>
    {
        public FactorCriticoExitoViewModelValidator()
        {
            RuleFor(p => p.FactorCritico)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                ;

           

        }
    }
}
