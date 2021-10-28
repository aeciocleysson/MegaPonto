﻿using System;
using System.Collections.Generic;

namespace Sis_Vendas_Mega.Model
{
    public class Employee : BaseModel
    {
        public string Name { get; private set; }
        public int Code { get; private set; }
        public int FunctionId { get; private set; }
        public Function Function { get; private set; }
        public virtual List<Score> Scores { get; set; } = new List<Score>();
        public Employee(string name, int code, int functionId)
        {
            Name = name;
            Code = code;
            FunctionId = functionId;
        }

        public Employee() { }

        public void Update(string name, int functionId, int code)
        {
            Name = name;
            FunctionId = functionId;
            Code = code;
            UpdateAt = DateTime.Now;
        }

        public void Delete(int isDelete)
        {
            IsDelete = isDelete;
            UpdateAt = DateTime.Now;
        }
    }
}
