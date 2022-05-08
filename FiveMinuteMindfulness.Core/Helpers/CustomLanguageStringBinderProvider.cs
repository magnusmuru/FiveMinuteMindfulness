using FiveMinuteMindfulness.Core.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FiveMinuteMindfulness.Core.Helpers;

public class CustomLanguageStringBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(LanguageString))
        {
            return new LanguageStringBinderProvider();
        }

        return null;
    }
}