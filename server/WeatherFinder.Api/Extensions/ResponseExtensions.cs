using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WeatherFinder.Api.Models.Responses;

namespace WeatherFinder.Api.Extensions
{
    public static class ResponseExtensions
    {
        public static Response<T> AppendErrors<T>(this Response<T> response, string error)
        {
            return response.AppendErrors(new List<string> { error });
        }

        public static Response<T> AppendErrors<T>(this Response<T> response, IEnumerable<ValidationResult> errors)
        {
            return response.AppendErrors(errors.Select(x => x.ErrorMessage).ToList());
        }

        public static Response<T> AppendErrors<T>(this Response<T> response, List<string> errors)
        {
            response.Errors = errors;
            return response;
        }
    }

}
