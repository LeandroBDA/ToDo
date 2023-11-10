using FluentValidation;

namespace ToDo.Domain.Validators
{
    public class TasksValidator : AbstractValidator<Tasks>
    {
        public TasksValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("A Tarefa não pode ser vazia")
                .NotNull().WithMessage("A Tarefa não pode ser nula.");

            RuleFor(x => x.Name)
                .MaximumLength(30)
                .WithMessage("O nome da tarefa não pode ser maior que 30 caracteres.")
                .MaximumLength(3)
                .WithMessage("O nome da tarefa deve ter no mínimo 3 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(300)
                .WithMessage("A tarefa deve conter no máximo 300 caracteres.");

            RuleFor(x => x.UserId)
                .NotNull()
                .WithMessage("O Id do usuário não pode ser nulo")

                .NotEmpty()
                .WithMessage("O Id do usuário não pode ser vazio");
        }
    }
}

