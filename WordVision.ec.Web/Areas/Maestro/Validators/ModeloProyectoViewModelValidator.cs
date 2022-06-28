using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class ModeloProyectoViewModelValidator : AbstractValidator<ModeloProyectoViewModel>
    {
        public ModeloProyectoViewModelValidator()
        {
            RuleFor(p => p.Codigo)
            .NotEmpty().WithMessage("{PropertyName} no espacio.")
            .NotNull().WithMessage("{PropertyName} no null.");

            RuleFor(p => p.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();
        }

        //public int Id { get; set; }

        //public string Codigo { get; set; }

        //public string Descripcion { get; set; }

        ////public string Responsable { get; set; }

        //public int IdEtapaModeloProyecto { get; set; }
        //public EtapaModeloProyectoViewModelValidator EtapaModeloProyecto { get; set; }

        //public int IdEstado { get; set; }

        //public DetalleCatalogoViewModel Estado { get; set; }

        //public SelectList EtapaModeloProyectoList { get; set; }
        //public SelectList EstadoList { get; set; }

    }
}
