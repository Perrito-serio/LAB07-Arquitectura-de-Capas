using Newtonsoft.Json; // Necesitamos este 'using' para JsonConvert

// Asegúrate de que el namespace coincida con tu estructura de carpetas
namespace Lab07_MunozHerrera.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // Intenta ejecutar el resto del pipeline
        }
        catch (Exception ex)
        {
            // Si algo falla, atrapa la excepción aquí
            context.Response.StatusCode = 500; // Internal Server Error
            context.Response.ContentType = "application/json";
            
            var errorResponse = new { message = "Ocurrió un error interno en el servidor.", details = ex.Message };
            
            // Convierte la respuesta a JSON y la envía al cliente
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}