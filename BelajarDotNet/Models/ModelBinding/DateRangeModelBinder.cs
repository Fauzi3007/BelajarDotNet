using BelajarDotNet.Models.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace BelajarDotNet.Models
{
    public class DateRangeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            //Get the Query String Parameter
            var query = bindingContext.HttpContext.Request.Query;
            //fetch the values based on the key
            var DateRangeQueryString = query["range"].ToString();
            //Check if the value is null or empty
            if (string.IsNullOrEmpty(DateRangeQueryString))
            {
                return Task.CompletedTask;
            }

            //Split the Values by -
            var dateValues = DateRangeQueryString.Split('-');

            if (dateValues.Length != 2)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid Date Range Format.");
                return Task.CompletedTask;
            }

            if (dateValues.Length == 2 && DateTime.TryParseExact(dateValues[0], "MM/dd/yyyy", provider, DateTimeStyles.None, out DateTime startDate) && DateTime.TryParseExact(dateValues[1], "MM/dd/yyyy", provider, DateTimeStyles.None, out DateTime endDate))
            {
                var dateRange = new DateRange { StartDate = startDate, EndDate = endDate };
                bindingContext.Result = ModelBindingResult.Success(dateRange);

                return Task.CompletedTask;
            }
            else
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid Date Range Format.");
                return Task.CompletedTask;
            }
        }
    }
}