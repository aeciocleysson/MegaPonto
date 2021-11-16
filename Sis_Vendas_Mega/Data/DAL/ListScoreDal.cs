using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Sis_Vendas_Mega.Data.DAL
{
    public class ListScoreDal
    {
        public MySqlConnection connection;
        public MySqlCommand Cmd;

        public DataTable ListarUsuarios(int id, DateTime inicio, DateTime fim)
        {
            try
            {
                connection = new MySqlConnection("Host=localhost;Database=DbErpMega;Username=root;Password=3103");
                connection.Open();

                string sql = $"SELECT TIME_FORMAT(SUM(WORKED), '%T') AS WORKED FROM Score WHERE EMPLOYEEID = {id} AND INSERTED BETWEEN '{inicio.ToString("yyyy-MM-dd")}' AND '{fim.ToString("yyyy-MM-dd")}'";

                Cmd = new MySqlCommand(sql, connection);

                MySqlDataAdapter Da = new MySqlDataAdapter();

                Da.SelectCommand = Cmd;

                DataTable Dt = new DataTable();

                Da.Fill(Dt);

                return Dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
