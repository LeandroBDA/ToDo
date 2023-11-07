using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Manager.Domain.Entites;

namespace Manager.Domain.Validators
{
    public class Uservalidator : AbstractValidator<User>
    {
        public Uservalidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("A entidade não ser vazia.")
                .NotNull().WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser nulo")
                .NotNull().WithMessage("O nome não pode ser vazio.")
                .MaximumLength(3)
                .WithMessage("O nome deve conter no mínimo 3 caracteres.")
                .MaximumLength(80)
                .WithMessage("O número máximo de caracteres deve ser de 80.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não pode ser nulo.")
                .NotNull()
                .WithMessage("O email não pode ser vazio.")
                .Length(10, 180)
                .WithMessage("O deve ter no mínimo 10 e no máximo 180 caracteres.")
                .EmailAddress()
                .WithMessage("O email informado não é válido.");
            
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode ser nula")
                .NotNull().WithMessage("A senha não pode ser vazia.")
                .MaximumLength(8)
                .WithMessage("A senha deve conter no mínimo 8 caracteres.")
                .MaximumLength(60)
                .WithMessage("A senha deve ter no máximo 60 caracteres.");
        }
    }
}

