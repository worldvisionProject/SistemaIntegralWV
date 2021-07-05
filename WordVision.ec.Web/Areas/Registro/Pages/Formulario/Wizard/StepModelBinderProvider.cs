using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    public class StepModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType != typeof(StepViewModel))
            {
                return null;
            }

            // TODO do this with reflection.
            var subclasses = new[]
            {
                typeof(DatosPersonalesStep),
                typeof(DatosContactoStep),
                typeof(OtrosPaisStep),
                typeof(DependientesInformacionStep),
                typeof(SaludStep),
                typeof(ContactosStep),
                typeof(InformacionAdicionalStep)
            };

            var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();

            foreach (var type in subclasses)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new StepModelBinder(binders);
        }
    }
}