// Asegúrate de que el namespace coincida con tu estructura de carpetas
namespace Lab07_MunozHerrera.Middleware;

public class RoleBasedAccessMiddleware
{
    private readonly RequestDelegate _next;

    public RoleBasedAccessMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Busca en los 'claims' del usuario el que corresponde al rol.
        // En una app real, esto lo llenaría el middleware de autenticación (ej. JWT).
        var userRole = context.User?.Claims?.FirstOrDefault(c => c.Type == "role")?.Value;

        // Validamos si el rol es "Admin".
        if (string.IsNullOrEmpty(userRole) || userRole != "Admin")
        {
            context.Response.StatusCode = 403; // Forbidden
            await context.Response.WriteAsync("Acceso denegado. Se requiere rol de Administrador.");
            return; // Detenemos la ejecución aquí.
        }

        // Si el rol es correcto, la petición continúa.
        await _next(context);
    }
}