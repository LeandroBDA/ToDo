using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Manager.Domain.Entites;
namespace Manager.Domain.Entites
{
    public abstract class User : Base
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

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }
        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }
        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        } 
        public override bool Validate()
        {
            var validator = new Uservalidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add((error.ErrorMessage));
                }
                throw new DomainExeption($"Alguns campos stão inválidos {_errors[0]}");
            }
            return true;
        }
    }
    
}


