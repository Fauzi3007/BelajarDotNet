using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BelajarDotNet.Models.ModelBinding
{
    public class DateRangeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(DateRange))
            {
                return new DateRangeModelBinder();
            }
            return null;
        }
    }
}