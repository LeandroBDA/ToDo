namespace ToDo.Domain.Entities;

public class BuscarTarefas
{
    public BuscarTarefas()
    { }

    public BuscarTarefas(int id, string name, string descripstion )
    {
        Id = id;
        Name = name;
        Description = descripstion;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}