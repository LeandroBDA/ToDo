using ToDo.Core.Exceptions;
using ToDo.Domain.Validators;

namespace ToDo.Domain.Entities;

public abstract class Tarefas : Base
{
    public Tarefas ()
    { }
    
  
    public int Id { get; private set; }
    public string Email { get; set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
  

    public Tarefas (int id, string description, string name )
    {
        Id = id;
        Name = name;
        Description = description;
        _errors = new List<string>();
        Validate();
    }
    
    public void ChangeName(string name)
    {
        Name = name;
        Validate();
    }

    public void ChangeDescription(string description)
    {
        Description = description;
        Validate();
    }

    public override bool Validate()
    {
        var validate = new TarefasValidators();
        var validation = validate.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var erro in validation.Errors)
                _errors.Add(erro.ErrorMessage);

            throw new DomainException("Alguns campos estão inválidos, por favor corrija-los", _errors);
        }

        return true;
    }
}