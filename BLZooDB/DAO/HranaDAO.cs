using BLZooDB.Model;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;

namespace BLZooDB.DAO
{
    class HranaDAO
    {
        public static DataTable GetHranaDataTable()
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT * FROM blzoodb.hrana"))
                {
                    cmd.Connection = conn;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetHranaZivotinjeDataTable(int id)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DobaviHranuOdZivotinje"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new MySqlParameter("@id", id));
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public static bool UpdateHrana(int id, int kolicina)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "AzurirajHranu";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@h_id", id);
                    cmd.Parameters["@h_id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@kol", kolicina);
                    cmd.Parameters["@kol"].Direction = ParameterDirection.Input;
                    return cmd.ExecuteNonQuery() != 0;
                }
            }
        }
        public static void InsertHrana(string hrana_naziv, int stanje, int potrebno_stanje)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DodajHranu"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new MySqlParameter("@hrana_naziv", hrana_naziv));
                    cmd.Parameters.Add(new MySqlParameter("@stanje", stanje));
                    cmd.Parameters.Add(new MySqlParameter("@potrebno_stanje", potrebno_stanje));

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static ObservableCollection<Hrana> GetHrana()
        {
            var lista = new ObservableCollection<Hrana>();
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DobaviHranu";
                    cmd.CommandType = CommandType.StoredProcedure;


                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(new Hrana(reader[0] as int? ?? default(int), reader[1] as string, reader[2] as int? ?? default(int), reader[3] as int? ?? default(int)));
                    }

                }
            }
            return lista;


        }

        public static DataTable GetVetAlertsHrana()
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DobaviObavjestiVeterinara"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
