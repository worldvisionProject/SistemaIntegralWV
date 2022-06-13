using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class LogFrameViewModelValidator : AbstractValidator<LogFrameViewModel>
    {
        public LogFrameViewModelValidator()
        {
            RuleFor(p => p.SumaryObjetives)
            .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
            .NotNull();
        }

        //public int Id { get; set; }
        //public string OutCome { get; set; }

        //public string OutPut { get; set; }

        //public string Activity { get; set; }

        //public string SumaryObjetives { get; set; }

        //public int IdNivel { get; set; }
        //public DetalleCatalogoViewModel Nivel { get; set; }

        //public int IdEstado { get; set; }
        //public DetalleCatalogoViewModel Estado { get; set; }

        //public SelectList NivelList { get; set; }
        //public SelectList EstadoList { get; set; }

    }
}
