using ToDo.Domain.Entites;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ToDo.Core.Exceptions;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Validators
{
    public class Tasks : Base
    {
        public Tasks()
        { }

        public Tasks(int id,
            DateTime updatedAt,
            string name,
            string description,
            Guid userId,
            DateTime createdAt,
            bool concluded,
            DateTime concludedAt,
            DateTime deadline)
        {
            Id = id;
            Name = name;
            Description = description;
            UserId = userId;
            Concluded = concluded;
            ConcludedAt = concludedAt;
            Deadline = deadline;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            _errors = new List<string>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public bool Concluded { get; set; }
        public DateTime ConcludedAt { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        //ef
        public User User { get; set; }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }
        public void ChangeStatus(bool status)
        {
            Concluded = status;
            Validate();
        }
        public void ChangeDescription(string description)
        {
            Description = description;
            Validate();
        }

        public override bool Validate()
        {
            var validate = new TasksValidator();
            var validation = validate.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add((error.ErrorMessage));
                }

                throw new DomainException($"Alguns campos estão inválidos {_errors[0]}");
            }

            return true;
        }
    }
}

