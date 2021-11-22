using System;
using System.Collections.Generic;

namespace Sis_Vendas_Mega.Model
{
    public class Employee : BaseModel
    {
        public string Name { get; private set; }
        public long Code { get; private set; }
        public int FunctionId { get; private set; }
        public string DataNascimento { get; private set; }
        public Function Function { get; private set; }
        public virtual List<Score> Scores { get; set; } = new List<Score>();
        public virtual List<LogScore> LogScores { get; set; } = new List<LogScore>();
        public Employee(string name, long code, int functionId, string dataNascimento)
        {
            Name = name;
            Code = code;
            FunctionId = functionId;
            DataNascimento = dataNascimento;
        }

        public Employee() { }

        public void Update(string name, int functionId, string dataNascimento)
        {
            Name = name;
            FunctionId = functionId;
            DataNascimento = dataNascimento;
            UpdateAt = DateTime.Now;
        }

        public void Delete(int isDelete)
        {
            IsDelete = isDelete;
            UpdateAt = DateTime.Now;
        }
    }
}
