using Lab07_MunozHerrera.DTOs; // Para poder usar CreateProductDto
using Microsoft.AspNetCore.Mvc;

// Asegúrate de que el namespace coincida con tu estructura de carpetas
namespace Lab07_MunozHerrera.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateProductDto product)
    {
        // Si el código llega aquí, significa que el ParameterValidationMiddleware
        // validó la petición y la dejó pasar.
        return Ok(new { message = "Producto creado exitosamente." });
    }
}