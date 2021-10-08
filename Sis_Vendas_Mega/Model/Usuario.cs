namespace Sis_Vendas_Mega.Model
{
    public class Usuario : BaseModel
    {
        public string Nome { get; private set; }
        public string Tipo { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }

        public Usuario(string nome, string tipo, string login, string senha)
        {
            Nome = nome;
            Tipo = tipo;
            Login = login;
            Senha = senha;
        }
    }
}
