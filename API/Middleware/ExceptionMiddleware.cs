using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        // This class is a custom middleware class. It is used to catch exceptions thrown by the application and return a 500 Internal Server Error response
        private readonly RequestDelegate _next; // This field is a reference to the next middleware in the pipeline
        private readonly ILogger<ExceptionMiddleware> _logger; // This field is a reference to the ILogger service, which is used to log exceptions
        private readonly IHostEnvironment _env; // This field is a reference to the IHostEnvironment service, which is used to check if the app is in development mode
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
            IHostEnvironment env)
        {
            _env = env; // The constructor assigns the IHostEnvironment service to the _env field
            _logger = logger; // The constructor assigns the ILogger service to the _logger field
            _next = next; // The constructor assigns the next middleware to the _next field
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // This line invokes the next middleware in the pipeline
            }
            catch (Exception ex)
            {
                // This block is executed if an exception is thrown by the application
                _logger.LogError(ex, ex.Message); // This line logs the exception
                context.Response.ContentType = "application/json"; // This line sets the response content type to JSON
                context.Response.StatusCode = 500; // This line sets the response status code to 500

                var response = new ProblemDetails
                {
                    // This line creates a ProblemDetails object with the exception's message as the title and the exception's stack trace as the detail
                    Status = 500,
                    Detail = _env.IsDevelopment() ? ex.StackTrace?.ToString() : null,
                    Title = ex.Message
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }; // This line creates a JsonSerializerOptions object with the CamelCase property naming policy

                var json = JsonSerializer.Serialize(response, options); // This line serializes the ProblemDetails object to JSON

                await context.Response.WriteAsync(json); // This line writes the JSON to the response body
            }
        }
    }
}