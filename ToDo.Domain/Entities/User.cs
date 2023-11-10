using ToDo.Core.Exceptions;
using ToDo.Domain.Entites;
using ToDo.Domain.Validators;

namespace ToDo.Domain.Entities
{
    public class User : Base
    {
        protected User() { }
        public User(Guid id, string role, string name, string email, string password)
        {
            Id = id;
            Role = role;
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        } 
        public string Role { get; private set; } 
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string  Password { get; private set; }
        
        //ef
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();
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


