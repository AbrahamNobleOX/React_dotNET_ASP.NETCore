// Create a new instance of WebApplicationBuilder using the arguments passed to the application
using API.Data;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add controllers to the Dependency Injection (DI) container
builder.Services.AddControllers();

// Add API explorer services to generate documentation for endpoints
builder.Services.AddEndpointsApiExplorer();

// Add Swagger services to generate Swagger/OpenAPI documentation
builder.Services.AddSwaggerGen();

// Add StoreContext to the Dependency Injection (DI) container
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); // Use SQLite database
});

builder.Services.AddCors(); // Add CORS services to the DI container

// Build the web application based on the configured services
var app = builder.Build();

// Configure the HTTP request pipeline.

// Add middleware to handle exceptions and return a response with a 500 Internal Server Error status code
app.UseMiddleware<ExceptionMiddleware>();

// Check if the app is in development mode
if (app.Environment.IsDevelopment())
{
    // If in development, use Swagger middleware to expose generated Swagger JSON endpoint
    app.UseSwagger();

    // Use Swagger UI middleware to visualize and interact with the API's endpoints
    app.UseSwaggerUI();
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
});

// Add middleware to redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

app.MapControllers(); // Map controllers to the app

// Define a GET endpoint at "/"
app.MapGet("/", () =>
{
    return "Hello World!"; // Return "Hello World!"
})
// Assign a name to the endpoint for Swagger documentation
.WithName("Root")
// Enable OpenAPI documentation for this endpoint
.WithOpenApi();

var scope = app.Services.CreateScope(); // Create a new scope for Dependency Injection (DI)
var context = scope.ServiceProvider.GetRequiredService<StoreContext>(); // Get the StoreContext from the DI container
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>(); // Get the logger from the DI container
try
{
    context.Database.Migrate(); // Apply any pending migrations to the database
    DbInitializer.Initialize(context); // Seed the database with mock data
}
catch (Exception ex)
{
    logger.LogError(ex, "A problem occurred during migration"); // Log any errors
}

// Start listening for incoming HTTP requests
app.Run();

// Overall, this code sets up an ASP.NET Core web application with Swagger/OpenAPI integration, HTTPS redirection, and a simple endpoint (/weatherforecast) that returns Hello World!.