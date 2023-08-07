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

            if (context.Metadata.ModelType == typeof(float) ||
                context.Metadata.ModelType == typeof(float?))
            {
                return new FloatModelBinder();
            }

            return null!;
        }
    }
}
