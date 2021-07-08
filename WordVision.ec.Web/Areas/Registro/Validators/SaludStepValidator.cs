using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard;

namespace WordVision.ec.Web.Areas.Registro.Validators
{
    public class SaludStepValidator : AbstractValidator<SaludStep>
    {
        public SaludStepValidator()
        {

            RuleFor(p => p.Preexistencia)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.Alergias)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.TipoSangre)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

          

        }
    }
}
