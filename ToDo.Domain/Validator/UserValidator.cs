using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using ToDo.Domain.Entites;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("A entidade não pode ser vazia.")
                .NotNull().WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser nulo")
                .NotNull()
                .WithMessage("O nome não pode ser vazio.")
                .MinimumLength(3)
                .WithMessage("O nome deve conter no mínimo 3 caracteres.")
                .MaximumLength(80)
                .WithMessage("O número máximo de caracteres deve ser de 80.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não pode ser nulo")
                .NotNull()
                .WithMessage("O email não pode ser vazio.")
                .MinimumLength(15)
                .WithMessage("O email deve ter no mínimo 15 caracteres.")
                .MaximumLength(90)
                .WithMessage("O email deve conter no máximo 90 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode ser nula")
                .NotNull()
                .WithMessage("A senha não pode ser vazia.")
                .MinimumLength(8)
                .WithMessage("A senha deve conter no mínimo 8 caracteres.")
                .MaximumLength(60)
                .WithMessage("A senha deve ter no máximo 60 caracteres.");
        }
    }
}

