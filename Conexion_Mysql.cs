using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace _CYD_ASIENTOS_CONTABLES_2019
{
    class Conexion_Mysql
    {
        string Ip_Servidor = "";
        string Usr_Servidor = "";
        string Pwd_Servidor = "";
        string BD_Servidor = "";

        public Conexion_Mysql()
        {
            Cnn = new MySqlConnection("Server=" + Ip_Servidor + ";Database=" + BD_Servidor + ";Uid=" + Usr_Servidor + ";Pwd=" + Pwd_Servidor + ";");
        }

        MySqlConnection Cnn;

        public Object ExecuteFunction(string query)
        {

            DataTable d = new DataTable();
            d = ExecuteQuery("SELECT " + query);

            Object valor;

            if (d.Rows.Count == 1)
            {
                valor = d.Rows[0][0];
            }
            else
            {
                valor = null;
            }

            return valor;
        }


        public DataTable ExecuteQuery(string query)
        {
            try
            {
                MySqlCommand cm;
                MySqlDataAdapter da;
                DataTable ds;

                if (Cnn.State == ConnectionState.Open) { Cnn.Close(); } else { Cnn.Open(); }

                cm = new MySqlCommand();
                cm.CommandText = query;
                cm.CommandType = CommandType.Text;
                cm.Connection = Cnn;
                cm.CommandTimeout = 0;
                da = new MySqlDataAdapter(cm);

                ds = new DataTable();
                da.Fill(ds);

                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ExecuteNonQuery(string query)
        {
            try
            {
                if (Cnn.State == ConnectionState.Open) { Cnn.Close(); }

                MySqlCommand command = new MySqlCommand(query, Cnn);
                command.Connection.Open();
                command.CommandTimeout = 0;
                command.ExecuteNonQuery();
                command.Connection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int QueryCount(DataTable dt)
        {
            try
            {
                return dt.Rows.Count;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
