using FiveMinuteMindfulness.Core.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FiveMinuteMindfulness.Core.Helpers;

public class LanguageStringBinderProvider : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        var value = valueProviderResult.FirstValue;
        if (value == null)
        {
            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(new LanguageString(value));

        return Task.CompletedTask;
    }
}