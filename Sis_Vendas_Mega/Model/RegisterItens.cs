using System.Collections.Generic;

namespace Sis_Vendas_Mega.Model
{
    public class RegisterItens : BaseModel
    {
        public int RegisterId { get; private set; }
        public int Quantidade { get; private set; }
        public int ProductId { get; private set; }
        public Register Register { get; private set; }
        public Product Product { get; private set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public RegisterItens(int registerId, int quantidade, int productId)
        {
            RegisterId = registerId;
            Quantidade = quantidade;
            ProductId = productId;
        }
    }
}
