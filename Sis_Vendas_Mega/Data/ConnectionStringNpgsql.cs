using Npgsql;

namespace Sis_Vendas_Mega.Data
{
    public static class ConnectionStringNpgsql
    {
        public static string connectionString = "Host=localhost;Database=DbMegaPonto;Username=postgres;Password=3103";
        public static NpgsqlConnection connection;
        public static bool Connect()
        {
            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();

                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
