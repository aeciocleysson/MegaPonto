using System;

namespace Sis_Vendas_Mega.Model
{
    public class Product : BaseModel
    {
        public string Brand { get; private set; }
        public string Description { get; private set; }
        public Product(string brand, string description)
        {
            Brand = brand;
            Description = description;
        }

        public void Update(string brand, string description)
        {
            Brand = brand;
            Description = description;
            UpdateAt = DateTime.Now;
        }

        public void Delete(int isDelete)
        {
            IsDelete = isDelete;
        }
    }
}
