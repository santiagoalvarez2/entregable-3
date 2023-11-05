namespace entregable3.Handler;
using entregable3.DTO;
public class LibHandler
{
    private List <LibroDto> _libros;

    public LibHandler (List <LibroDto> libro)
    {
       this._libros = libro;  
    }

    public List <LibroDto> All()
    {
        return this._libros;
    }

     public void create(LibroDto libro)
    {
        libro.Id = Guid.NewGuid();
        _libros.Add(libro);
    }
    public void update (Guid id, LibroDto updatelibro)
    {   
        var libro = _libros.FirstOrDefault(l=> l.Id == id);
        if (libro != null)
        {
            libro.Titulo = updatelibro.Titulo;
            libro.Resumen = updatelibro.Resumen;
            libro.AutorId = updatelibro.AutorId;
        }

    }

    public void delete (Guid id)
    {
        var libro = _libros.FirstOrDefault (l => l.Id == id);
        if (libro != null){
            _libros.Remove(libro);
        }
    }


}
