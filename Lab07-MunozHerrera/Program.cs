
using Lab07_MunozHerrera.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Habilitamos el uso de Controladores en la aplicación
builder.Services.AddControllers();

// Servicios para la documentación de la API (Swagger/OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// El manejador de errores va PRIMERO, para que pueda atrapar
// excepciones de los middlewares que vienen después.
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();

// Aquí registramos nuestro middleware en el pipeline
// ¡El orden importa! Lo ponemos antes de que las peticiones lleguen a los controladores.
app.UseMiddleware<ParameterValidationMiddleware>();

// 3. Mapeamos las rutas a los controladores
app.MapControllers();

app.Run(); 