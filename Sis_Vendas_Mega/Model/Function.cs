using System.Collections.Generic;

namespace Sis_Vendas_Mega.Model
{
    public class Function : BaseModel
    {
        public string Description { get; private set; }
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();

        public Function(string description)
        {
            Description = description;
        }
    }
}
