// Necesitamos este 'using' para poder usar el atributo [Required]
using System.ComponentModel.DataAnnotations;

// Asegúrate de que el namespace coincida con tu estructura de carpetas
namespace Lab07_MunozHerrera.DTOs;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    // Usamos 'decimal?' para permitir que el modelo lo detecte como nulo si no se envía.
    // Si fuera solo 'decimal', su valor por defecto sería 0, no null.
    public decimal? Price { get; set; }

    public string? Description { get; set; } // Lo hacemos opcional (nullable)
}