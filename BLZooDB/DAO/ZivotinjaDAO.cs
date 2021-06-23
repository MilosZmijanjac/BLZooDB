using BLZooDB.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;

namespace BLZooDB.DAO
{
    public class ZivotinjaDAO
    {
        public static ObservableCollection<Zivotinja> GetZivotinje()
        {
            var lista = new ObservableCollection<Zivotinja>();
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DobaviZivotinje";
                    cmd.CommandType = CommandType.StoredProcedure;


                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(new Zivotinja(reader[0] as int? ?? default(int), reader[1] as string ?? default(string), reader[2] as string ?? default(string),
                           reader[3] as DateTime? ?? default(DateTime), reader[4] as DateTime? ?? default(DateTime), reader[5] as string ?? default(string),
                           reader[6] as int? ?? default(int), reader[7] as string ?? default(string), reader[8] as string ?? default(string),
                           reader[9] as int? ?? default(int), reader[10] as string ?? default(string)));
               
                    }

                }
            }
            return lista;
        }
        public static bool UpdateZivotinja(int id, string stanje, int brojHranjenja)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "AzurirajZivotinje";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters["@id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@stanje", stanje);
                    cmd.Parameters["@stanje"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@broj", brojHranjenja);
                    cmd.Parameters["@broj"].Direction = ParameterDirection.Input;
                    return cmd.ExecuteNonQuery() != 0;
                }
            }
        }
        public static void DeleteZivotinja(int id)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "ObrisiZivotinju";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters["@id"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void InsertZivotinju(string ime, string vrsta, DateTime rodjenje, string spol, int obor, 
            string stanje, string ishrana, int broj_hranjenja, string slika)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DodajZivotinju";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ime", ime);
                    cmd.Parameters["@ime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@vrsta", vrsta);
                    cmd.Parameters["@vrsta"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@dat_rodj", rodjenje);
                    cmd.Parameters["@dat_rodj"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@spol", spol);
                    cmd.Parameters["@spol"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@smjestaj_id", obor);
                    cmd.Parameters["@smjestaj_id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@zdrav_stanje", stanje);
                    cmd.Parameters["@zdrav_stanje"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@tip_ish", ishrana);
                    cmd.Parameters["@tip_ish"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@broj_hranjenja", broj_hranjenja);
                    cmd.Parameters["@broj_hranjenja"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@slika", slika);
                    cmd.Parameters["@slika"].Direction = ParameterDirection.Input;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
