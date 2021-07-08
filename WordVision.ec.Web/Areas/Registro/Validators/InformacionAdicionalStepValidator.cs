using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard;

namespace WordVision.ec.Web.Areas.Registro.Validators
{
    public class InformacionAdicionalStepValidator : AbstractValidator<InformacionAdicionalStep>
    {
        public InformacionAdicionalStepValidator()
        {

            RuleFor(p => p.CreenciaReligiosa)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.DiscapacidadSN)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.Etnia)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.FamiliaDiscapacidad)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.FamiliaDiscapacidadRelacion)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull();

            RuleFor(p => p.FamiliaDiscapacidadSN)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull();

            RuleFor(p => p.FamiliaPorcentajeDiscapacidad)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull();

            RuleFor(p => p.FamiliaTipoDiscapacidad)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull();

            RuleFor(p => p.Iglesia)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull();

            RuleFor(p => p.PorcentajeDiscapacidad)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull();

            RuleFor(p => p.TipoDiscapacidad)
           .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
           .NotNull();


            RuleFor(p => p.Image)
          .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
          .NotNull();
        }
    }
}
