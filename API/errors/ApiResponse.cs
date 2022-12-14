using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "This is a bad request",
                401 => "You are not authorized",
                404 => "Resource found",
                500 => "Internal Server error",
                _ => null
            };
        }
    }
}