using entregable3.DTO;
using entregable3.Handler;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Lista en memoria para libros y autores
var _libros = new List<LibroDto>();
var _autores = new List<AutorDto>();

var libHandler = new LibHandler(_libros);
var autorHandler = new AutorHandler(_autores);

app.MapPost("/api/v1/libros/CrearLibro", (LibroDto libroDto) =>
{
    libHandler.create(libroDto);
    return Results.Created($"/api/v1/libros/{libroDto.Id}", libroDto);
});

app.MapGet("/api/v1/libros/{id}", (Guid id) =>
{
    var libro = _libros.FirstOrDefault(l => l.Id == id);
    if (libro != null)
    {
        return Results.Ok(libro);
    }
    else
    {
        return Results.NotFound($"No se encontró un libro con ID {id}");
    }
});

app.MapPut("/api/v1/libros/{id}", (Guid id, LibroDto libroDto) =>
{
    libHandler.update(id, libroDto);
    return Results.Ok(libroDto);
});

app.MapDelete("/api/v1/libros/{id}", (Guid id) =>
{
    libHandler.delete(id);
    return Results.NoContent();
});

app.MapPost("/api/v1/autores/CrearAutor", (AutorDto autorDto) =>
{
    autorHandler.create(autorDto);
    return Results.Created($"/api/v1/autores/{autorDto.Id}", autorDto);
});

app.MapGet("/api/v1/autores/{id}", (Guid id) =>
{
    var autor = _autores.FirstOrDefault(a => a.Id == id);
    if (autor != null)
    {
        return Results.Ok(autor);
    }
    else
    {
        return Results.NotFound($"No se encontró un autor con ID {id}");
    }
});

app.MapPut("/api/v1/autores/{id}", (Guid id, AutorDto autorDto) =>
{
    autorHandler.update(id, autorDto);
    return Results.Ok(autorDto);
});

app.MapDelete("/api/v1/autores/{id}", (Guid id) =>
{
    autorHandler.delete(id);
    return Results.NoContent();
});

app.Run();
