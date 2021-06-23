using BLZooDB.Model;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;

namespace BLZooDB.DAO
{
    class LijekDAO
    {
        public static DataTable GetLijekoviDataTable()
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT * FROM blzoodb.lijek"))
                {
                    cmd.Connection = conn;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static void PropisiLijek(int animal_id, int med_id, int dose_amount_mg, string dose_frequency, int duration_days, string disease)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("PropisiLijekZivotinji"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new MySqlParameter("@zivotinja_id", animal_id));
                    cmd.Parameters.Add(new MySqlParameter("@lijek_id", med_id));
                    cmd.Parameters.Add(new MySqlParameter("@doza_u_mg", dose_amount_mg));
                    //cmd.Parameters.Add(new MySqlParameter("@dose_frequency", dose_frequency));
                    cmd.Parameters.AddWithValue("@doziranje", dose_frequency);
                    cmd.Parameters["@doziranje"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(new MySqlParameter("@trajanje_lijecenja_u_danima", duration_days));
                    cmd.Parameters.Add(new MySqlParameter("@bolest", disease));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertLijek(string med_name, int med_stock, int med_target_stock)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DodajLijek"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new MySqlParameter("@lijek_naziv", med_name));
                    cmd.Parameters.Add(new MySqlParameter("@stanje", med_stock));
                    cmd.Parameters.Add(new MySqlParameter("@potrebno_stanje", med_target_stock));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateLijek(int med_id, int med_stock)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("AzurirajLijekove"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new MySqlParameter("@l_id", med_id));
                    cmd.Parameters.Add(new MySqlParameter("@kolicina", med_stock));


                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable GetLijekoviZivotinjeDataTable(int id)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DobaviLijekoveOdZivotinje"))
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

        public static ObservableCollection<Lijek> GetLijekovi()
        {
            var lista = new ObservableCollection<Lijek>();
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT lijek_id,lijek_naziv FROM blzoodb.lijek"))
                {
                    cmd.Connection = conn;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(new Lijek(reader[0] as int? ?? default(int), reader[1] as string ?? default(string)));
                        return lista;
                    }
                }
            }
        }

            public static ObservableCollection<Lijek> GetLijekoviSvi()
            {
                var lista = new ObservableCollection<Lijek>();
                using (var conn = new MySqlConnection(LoadConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT * FROM blzoodb.lijek"))
                    {
                        cmd.Connection = conn;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                lista.Add(new Lijek(reader[0] as int? ?? default(int), reader[1] as string ?? default(string), reader[2] as int? ?? default(int), reader[3] as int? ?? default(int)));
                            return lista;
                        }
                    }
                }
            }
            public static DataTable GetVetAlertsLijekovi()
            {
                using (var conn = new MySqlConnection(LoadConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("DobaviObavjestiLijekovi"))
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
