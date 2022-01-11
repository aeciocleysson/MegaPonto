using System;

namespace Sis_Vendas_Mega.Model
{
    public class DadosTrocas
    {
        public int RegisterId { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public int RegisterItensId { get; set; }
        public int Quantidade { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
