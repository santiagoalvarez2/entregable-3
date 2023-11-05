namespace entregable3.Handler;
using entregable3.DTO;

public class AutorHandler
{
    private List <AutorDto> _autores;

    public AutorHandler(List<AutorDto> autores)
    {
        this._autores = autores;
    }

    public List<AutorDto> All()
    {
        return this._autores;
    }

    public void create(AutorDto autor)
    {
        _autores.Add(autor); 
    }
    public void update(Guid id, AutorDto updateAutor)
    {
        foreach(AutorDto m in this._autores) {
           if (m.Id == id) {
               m.Nombre = updateAutor.Nombre;
               break;
           }
       }
    }

    public void delete (Guid id)
    {
        var autor = _autores.FirstOrDefault(a => a.Id == id);
        if(autor != null)
        {
            _autores.Remove(autor);
        }
    }
}