using System.Collections.Generic;

namespace Sis_Vendas_Mega.Model
{
    public class Register : BaseModel
    {
        public int ProviderId { get; private set; }
        public Provider Provider { get; set; }
        public List<RegisterItens> RegisterItens { get; set; } = new List<RegisterItens>();
        public Register(int providerId)
        {
            ProviderId = providerId;
        }
    }
}
