using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogDotNet6.Extensions;

public static class ModelEstateExtension
{
    public static List<string> GetErrors(this ModelStateDictionary modelState)
    {
        var errors = new List<string>();
        foreach (var state in modelState)
          errors.AddRange(state.Value.Errors.Select(error => error.ErrorMessage));
        

        return errors;
    }
}