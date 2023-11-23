using FluentValidation;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Validators;

public class TarefasValidators : AbstractValidator<Tarefas>
{
    public TarefasValidators()
    {
        RuleFor(x => x)
            .NotEmpty()
            
            .NotNull()
            .WithMessage("A entidade nâo pode ser nula.");

        RuleFor(x => x.Name)
            .NotEmpty()
           
            .NotNull()
            .WithMessage("O nome não pode ser vazio.")
            
            .MinimumLength(3)
            .WithMessage("O nome deve ter no mínimo 3 caracteres.")

            .MaximumLength(80)
            .WithMessage("O nome deve ter no máximo 80 caracteres.");
        
        RuleFor(x => x.Description)
            .NotEmpty()

            .NotNull()
            .WithMessage("A descrição não pode ser vazia.")

            .MinimumLength(30)
            .WithMessage("A descrição deve ter no mínimo 30 caracteres.")

            .MaximumLength(200)
            .WithMessage("A descrição deve ter no máximo 200 caracteres.");
    }
}