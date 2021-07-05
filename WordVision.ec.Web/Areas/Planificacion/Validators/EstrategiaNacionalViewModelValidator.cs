using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Validators
{
    public class EstrategiaNacionalViewModelValidator : AbstractValidator<EstrategiaNacionalViewModel>
    {
        public EstrategiaNacionalViewModelValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                ;

           

            RuleFor(p => p.MetaNacional)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull();


            RuleFor(p => p.MetaRegional)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();

         
        }
    }
}
