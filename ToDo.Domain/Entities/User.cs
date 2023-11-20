using ToDo.Core.Exceptions;
using ToDo.Domain.Entites;
using ToDo.Domain.Validator;

namespace ToDo.Domain.Entities
{ 
    public class User : Base
    {
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string  Password { get; private set; } = null!;
        public void ChangeName(string name)
        {
            Name = name; Validate();
        } 
        public void ChangeEmail(string email)
        {
            Email = email; Validate();
        } 
        public void ChangePassword(string password)
        {
            Password = password; Validate();
        } 
        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add((error.ErrorMessage));
                }
                throw new DomainException($"Alguns campos stão inválidos {_errors[0]}");
            }
            return true;
        }
    }
    
}


