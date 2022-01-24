using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard
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
                typeof(Objetivo_1Step),
                typeof(Objetivo_2Step),
               typeof(Objetivo_3Step),
               typeof(Objetivo_4Step),
               typeof(Objetivo_5Step),
               typeof(Objetivo_6Step),
               typeof(Objetivo_7Step)
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