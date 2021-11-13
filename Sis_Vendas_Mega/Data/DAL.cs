using Npgsql;
using System;
using System.Data;

namespace Sis_Vendas_Mega.Data
{
    public class DAL
    {
        static string serverName = "127.0.0.1";  //localhost
        static string port = "5432";             //porta default
        static string userName = "postgres";     //nome do administrador
        static string password = "3103";     //senha do administrador
        static string databaseName = "DbMegaPonto"; //nome do banco de dados
        NpgsqlConnection pgsqlConnection = null;
        NpgsqlCommand cmd = null;
        string connString = null;

        public DAL()
        {
            connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                          serverName, port, userName, password, databaseName);
        }

        public DataTable GetTodosRegistros()
        {
            DataTable dt = new DataTable();
            cmd = new NpgsqlCommand();

            try
            {
                pgsqlConnection = new NpgsqlConnection(connString);

                // abre a conexão com o PgSQL e define a instrução SQL
                pgsqlConnection.Open();
                cmd.Connection = pgsqlConnection;

                cmd.CommandText = "Select * from initcap('score')";
                cmd.CommandType = CommandType.Text;


                NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmd);

                Adpt.Fill(dt);
                cmd.Dispose();

            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }

            return dt;
        }


    }
}
