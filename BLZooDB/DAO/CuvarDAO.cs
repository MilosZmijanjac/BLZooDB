using BLZooDB.Model;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;

namespace BLZooDB.DAO
{
    public class CuvarDAO
    {
        public static DataTable GetHranaDataTable()
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DobaviInformacijeOCuvarima"))
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

        public static ObservableCollection<Zaposleni> GetFreeCuvari(int id)
        {
            var lista = new ObservableCollection<Zaposleni>();
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DobaviSlobodneCuvare";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("@id", id));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(new Zaposleni(reader[0] as int? ?? default(int),
                                reader[1] as string ?? default(string),
                                reader[2] as string ?? default(string),
                                reader[3] as string ?? default(string), 
                                reader[4] as int? ?? default(int), 
                                reader[5] as int? ?? default(int)));
                        
                    }

                }
            }
            return lista;
        }
        public static ObservableCollection<Zaposleni> GetCuvariOdZivotinje(int id)
        {
            var lista = new ObservableCollection<Zaposleni>();
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DobaviCuvaraZivotinje";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("@id", id));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(new Zaposleni(reader[0] as int? ?? default(int),
                                 reader[1] as string ?? default(string),
                                 reader[2] as string ?? default(string),
                                 reader[3] as string ?? default(string),
                                 reader[4] as int? ?? default(int),
                                 reader[5] as int? ?? default(int)));
                    }

                }
            }
            return lista;
        }
        public static void DodijeliZivotinjuCuvaru(int c_id, int a_id)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DodijeliZivotinjeCuvaru";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@c_id", c_id);
                    cmd.Parameters["@c_id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@z_id", a_id);
                    cmd.Parameters["@z_id"].Direction = ParameterDirection.Input;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void OduzmiZivotinjuCuvaru(int c_id, int a_id)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "ObrisiCuvaraZivotinje";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@c_id", c_id);
                    cmd.Parameters["@c_id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@z_id", a_id);
                    cmd.Parameters["@z_id"].Direction = ParameterDirection.Input;
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static DataTable GetCuvarObavjestiDataTable(int id)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DobaviCuvariObavjesti"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new MySqlParameter("c_id", id));
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
