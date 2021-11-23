namespace Sis_Vendas_Mega.Infrastructure
{
    public static class StatusLog
    {
        public enum ELog : int
        {
            InicioTrabalho = 1,
            SaidaAlmoco = 2,
            RetornoAlmoco = 3,
            FinalizouTrabalho = 4
        }
    }
}
