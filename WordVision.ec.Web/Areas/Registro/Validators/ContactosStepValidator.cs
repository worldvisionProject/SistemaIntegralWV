using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard;

namespace WordVision.ec.Web.Areas.Registro.Validators
{
    public class ContactosStepValidator : AbstractValidator<ContactosStep>
    {
        public ContactosStepValidator()
        {

            RuleFor(p => int.Parse(p.NumContacto))
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull()
             .InclusiveBetween(2, 10).WithMessage("Contato debe ser mayor 2"); 
        }
        }
    }
