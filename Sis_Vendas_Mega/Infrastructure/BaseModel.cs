using System;
using System.ComponentModel.DataAnnotations;

namespace Sis_Vendas_Mega.Model
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get;  set; }

        public DateTime Inserted { get; set; }

        public DateTime? UpdateAt { get; set; }

        public BaseModel()
        {
            Inserted = DateTime.Today;
        }
    }
}
