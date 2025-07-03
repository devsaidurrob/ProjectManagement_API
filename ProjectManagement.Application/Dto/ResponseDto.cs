using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace ProjectManagement.Application.Dto
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; } // Indicates if the request was successful
        public string Message { get; set; } = string.Empty; // Informational or error message
        public T Data { get; set; } // Data being returned (generic type)
        public int StatusCode { get; set; } // Optional error code (for validation or specific issues)
        public Dictionary<string, List<string>>? ValidationErrors { get; set; }

        // Static methods for easy response creation
        public static ResponseDto<T> SuccessResponse(T data, int statusCode = 200, string message = "Operation successful")
        {
            return new ResponseDto<T>
            {
                Success = true,
                Message = message,
                StatusCode = statusCode,
                Data = data
            };
        }
        public static ResponseDto<IEnumerable<T>> SuccessResponse(IEnumerable<T> data, int statusCode = 200, string message = "Operation successful")
        {
            return new ResponseDto<IEnumerable<T>>
            {
                Success = true,
                Message = message,
                StatusCode = statusCode,
                Data = data
            };
        }

        public static ResponseDto<T> ErrorResponse(string message = "An Error Occured", int errorCode = 500)
        {
            return new ResponseDto<T>
            {
                Success = false,
                Message = message,
                StatusCode = errorCode,
                Data = default
            };
        }
        //public static ResponseDto<T> ErrorResponse(ValidationResult validationResult, int statusCode = 400)
        //{
        //    return new ResponseDto<T>
        //    {
        //        Success = false,
        //        Message = $"Validation Error: {validationResult.Errors.Count} issues found",
        //        StatusCode = statusCode,
        //        Data = default,
        //        ValidationErrors = validationResult.Errors
        //                            .GroupBy(error => error.PropertyName)
        //                            .ToDictionary(
        //                            group => group.Key,
        //                            group => group.Select(error => error.ErrorMessage).ToList())
        //    };

        //}
        //public static ResponseDto<T> ErrorResponse(ValidationFailure validationFailure, int statusCode = 409)
        //{
        //    return new ResponseDto<T>
        //    {
        //        Success = false,
        //        Message = $"Validation Error: 1 issues found",
        //        StatusCode = statusCode,
        //        Data = default,
        //        ValidationErrors = new Dictionary<string, List<string>>()
        //    {
        //        { validationFailure.PropertyName, new List<string>(){ validationFailure.ErrorMessage } },
        //    }
        //    };

        //}
    }
}
