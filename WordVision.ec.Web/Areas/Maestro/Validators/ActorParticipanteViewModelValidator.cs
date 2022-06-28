﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class ActorParticipanteViewModelValidator : AbstractValidator<ActorParticipanteViewModel>
    {
        public ActorParticipanteViewModelValidator()
        {
            RuleFor(p => p.Codigo)
            .NotEmpty().WithMessage("{PropertyName} vvvves obligatoriovvvvv.")
            .NotNull();

            RuleFor(p => p.ActoresParticipantes)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();
        }

        //public int Id { get; set; }

        //public string Codigo { get; set; }
       

        //public string ActoresParticipantes { get; set; }

        //public string Descripcion { get; set; }

        //public int IdEstado { get; set; }
        //public DetalleCatalogoViewModel Estado { get; set; }

        //public SelectList EstadoList { get; set; }

    }
}
