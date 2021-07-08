using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Validators
{
    public class DocumentoViewModelValidator : AbstractValidator<DocumentoViewModel>
    {
        public DocumentoViewModelValidator()
        {

            RuleFor(p => p.Image)
          .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
          .NotNull();
        }
    }
}
