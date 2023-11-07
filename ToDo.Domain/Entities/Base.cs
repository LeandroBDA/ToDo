
namespace Manager.Domain.Entites
{
    public abstract class Base
    {
        public Guid Id { get; set; }
        internal List<string> _errors;

        public IReadOnlyCollection<string> Errors => _errors;
    
        public abstract bool Validate();
    }
}

