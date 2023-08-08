using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HouseRentingSystem.Web.Infrastructure.ModelBinders
{
    public class FloatModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(double) ||
                context.Metadata.ModelType == typeof(double?))
            {
                return new FloatModelBinder();
            }

            return null!;
        }
    }
}
