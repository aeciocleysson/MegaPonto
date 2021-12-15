using System.Collections.Generic;

namespace Sis_Vendas_Mega.Model
{
    public class Register : BaseModel
    {
        public int ProviderId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantidade { get; private set; }

        public Provider Provider { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public Register(int providerId, int productId, int quantidade)
        {
            ProviderId = providerId;
            ProductId = productId;
            Quantidade = quantidade;
        }
    }
}
