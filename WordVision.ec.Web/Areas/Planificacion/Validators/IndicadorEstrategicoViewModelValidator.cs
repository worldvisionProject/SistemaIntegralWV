using FluentValidation;
using System;
using System.Linq;
using System.Text.RegularExpressions;
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
                .Cascade(CascadeMode.Stop)
               //.Must(IsValidCost).WithMessage("{PropertyName} contains invalid caracteres")
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               ;
            //RuleFor(p => p.Meta)
            //   .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            //   .NotNull()
            //   ;
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

        private bool IsValidCost(decimal? arg)
        {
            return String.Concat(arg.ToString().Where(c => !Char.IsWhiteSpace(c))) != "" && Regex.IsMatch(arg.ToString(), @"^-?[0-9]*\,?[0-9]+$");
        }

        //protected bool IsValidCost(decimal cost) => 
        //    String.Concat(cost.ToString().Where(c => !Char.IsWhiteSpace(c))) != "" && Regex.IsMatch(cost.ToString(), @"^-?[0-9]*\.?[0-9]+$");

    }


}
