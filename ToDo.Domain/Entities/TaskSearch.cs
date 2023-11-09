namespace ToDo.Domain.Entities
{
    public class TaskSearch
    {
        public TaskSearch()
        {
            PAtual = 1;
            PTake = 20;
        }
        public TaskSearch ( string name, 
            string description, 
            bool concluded, 
            int pAtual, int pTake, 
            bool? orderByA,
            bool? orderByZ, 
            bool? maiorQue, 
            bool? menorQue, 
            DateTime? createdTime )
        {
            Name = name;
            PTake = pTake;
            PAtual = pAtual;
            OrderByA = orderByA;
            OrderByZ = orderByZ;
            MaiorQue = maiorQue;
            MenorQue = menorQue;
            Concluded = concluded;
            Description = description;
            CreatedTime = createdTime;
        }
        public string? Name { get; set; }
        public int? PTake { get; set; }
        public int? PAtual { get; set; }
        public bool? OrderByA { get; set; }
        public bool? OrderByZ { get; set; }
        public bool? MaiorQue { get; set; }
        public bool? MenorQue { get; set; }
        public bool? Concluded { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}

