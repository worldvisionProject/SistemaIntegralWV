using FluentValidation;
using WordVision.ec.Web.Areas.Donacion.Models;

namespace WordVision.ec.Web.Areas.Donacion.Validators
{
    public class DonanteViewModelValidator : AbstractValidator<DonanteViewModel>
    {
        public DonanteViewModelValidator()
        {

            RuleFor(p => p.FormaPago)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.Campana)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull();
            RuleFor(p => p.Nombre1)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull().MaximumLength(150).WithMessage("{PropertyName} No debe exceder 150 caracteres.");
            RuleFor(p => p.Apellido1)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull().MaximumLength(150).WithMessage("{PropertyName} No debe exceder 150 caracteres.");
            RuleFor(p => p.Apellido2)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull().MaximumLength(150).WithMessage("{PropertyName} No debe exceder 150 caracteres.");
            RuleFor(p => p.Nombre2)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull().MaximumLength(150).WithMessage("{PropertyName} No debe exceder 150 caracteres.");
            RuleFor(p => p.Canal)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.Categoria)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.Cedula)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.Ciudad)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.Direccion)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull().MaximumLength(250).WithMessage("{PropertyName} No debe exceder 250 caracteres.");
            RuleFor(p => p.Edad)
              .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
              .NotNull();
            RuleFor(p => p.Email)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.EstadoDonante)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.FechaConversion)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.FechaNacimiento)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.Genero)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.Provincia)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.Region)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();
            RuleFor(p => p.Responsable)
                        .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                        .NotNull();
            RuleFor(p => p.RUC)
                        .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                        .NotNull().MaximumLength(13).WithMessage("{PropertyName} No debe exceder 15 caracteres.");
            RuleFor(p => p.TelefonoCelular)
                        .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                        .NotNull().MaximumLength(15).WithMessage("{PropertyName} No debe exceder 15 caracteres.");
            //RuleFor(p => p.TelefonoConvencional)
            //            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            //            .NotNull().MaximumLength(15).WithMessage("{PropertyName} No debe exceder 15 caracteres.");
            RuleFor(p => p.Tipo)
                        .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                        .NotNull();
            RuleFor(p => p.Cantidad)
                        .GreaterThanOrEqualTo("0").WithMessage("{PropertyName} El Valor no debe ser 0")
                        .NotNull().WithMessage("{PropertyName} es obligatorio.");
            RuleFor(p => p.Banco)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.TipoCuenta)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.NumeroCuenta)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.NumReferencia)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.TiposTarjetasCredito)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.NumeroTarjeta)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.FechaCaducidad   )
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();
            RuleFor(p => p.NumReferenciaBp)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();

        }
    }
}
