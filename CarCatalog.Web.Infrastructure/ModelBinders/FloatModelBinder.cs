using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace CarCatalog.Web.Infrastructure.ModelBinders
{
    public class FloatModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext? bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            ValueProviderResult valueResult =
                bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !string.IsNullOrWhiteSpace(valueResult.FirstValue))
            {
                double parsedValue = 0f;
                bool binderSucceeded = false;

                try
                {
                    string formFltValue = valueResult.FirstValue;
                    formFltValue = formFltValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    formFltValue = formFltValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    parsedValue = Convert.ToDouble(formFltValue);
                    binderSucceeded = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (binderSucceeded)
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedValue);
                }
            }

            return Task.CompletedTask;
        }
    }
}
