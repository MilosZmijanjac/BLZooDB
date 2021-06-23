using BLZooDB.Model;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Configuration;
using System.Data;

namespace BLZooDB.DAO
{
    public class ProizvodDAO
    {
        public static ArrayList GetProizvodi()
        {
            var lista = new ArrayList();
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DobaviProizvode";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())

                            lista.Add(new Proizvod(reader[0] as int? ?? default(int),
                                reader[1] as string ?? default(string),
                                reader[2] as string ?? default(string),
                                reader[3] as int? ?? default(int),
                                reader[4] as decimal? ?? default(decimal),
                                reader[5] as int? ?? default(int), 
                                reader[6] as string ?? default(string),
                                reader[7] as int? ?? default(int), 
                                reader[8] as string ?? default(string)));
                          
                    }

                }
            }
            return lista;
        }

        public static ArrayList GetUlaznice()
        {
            var lista = new ArrayList();
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DobaviUlaznice";
                    cmd.CommandType = CommandType.StoredProcedure;


                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(new Proizvod(reader[0] as int? ?? default(int),
                                reader[1] as string ?? default(string),
                                reader[2] as string ?? default(string),
                                reader[3] as int? ?? default(int),
                                reader[4] as decimal? ?? default(decimal),
                                reader[5] as int? ?? default(int),
                                reader[6] as string ?? default(string),
                                reader[7] as int? ?? default(int),
                                reader[8] as string ?? default(string)));

                    }

                }
            }
            return lista;
        }
        public static bool UpdateProizvodi(int id, string velicina, int kolicina)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "AzurirajProizvode";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters["@id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@velicina", velicina);
                    cmd.Parameters["@velicina"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@kolicina", kolicina);
                    cmd.Parameters["@kolicina"].Direction = ParameterDirection.Input;
                    return cmd.ExecuteNonQuery() != 0;
                }
            }
        }

        public static bool DodajProizvod( string ime, string velicina, int kolicina, int pot_kolicina, string slika, string shop_kat, int shop_id, decimal cijena)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DodajNoviProizvod";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", cmd.LastInsertedId+1);
                    cmd.Parameters["@id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@ime", ime);
                    cmd.Parameters["@ime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@velicina", velicina);
                    cmd.Parameters["@velicina"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@cijena", cijena);
                    cmd.Parameters["@cijena"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@kolicina", kolicina);
                    cmd.Parameters["@kolicina"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@potrebna_kolicina", pot_kolicina);
                    cmd.Parameters["@potrebna_kolicina"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@slika", slika);
                    cmd.Parameters["@slika"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@shop_id", shop_id);
                    cmd.Parameters["@shop_id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@shop_kat", shop_kat);
                    cmd.Parameters["@shop_kat"].Direction = ParameterDirection.Input;
                    return cmd.ExecuteNonQuery() != 0;
                }
            }
        }

        public static DataTable GetShopObavjestiDataTable(int id)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DobaviObavjestiTrgovine"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new MySqlParameter("id", id));
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
