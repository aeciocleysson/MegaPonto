namespace Sis_Vendas_Mega.Model
{
    public class Usuario : BaseModel
    {
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public int NivelAcesso { get; private set; }

        public Usuario(string nome,  string login, string senha, int nivelAcesso)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            NivelAcesso = nivelAcesso;
        }
    }
}
