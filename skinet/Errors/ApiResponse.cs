using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skinet.Errors
{
    public class ApiResponse(int statusCode, string? message = null)
    {
        public int StatusCode { get; set; } = statusCode;
        public string? Message { get; set; } = message ?? GetDefaultMessageForStatusCode(statusCode);

        private static string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Aurhorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
                _ => null
            };
        }
    }
}