using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace BLZooDB.DAO
{
    public class NarudzbaDAO
    {
        public static long GetUkupanPrihodOdDo(DateTime? odDatum, DateTime? doDatum)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DobaviUkupanPrihodOdDo";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@od", odDatum);
                    cmd.Parameters["@od"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@do", doDatum);
                    cmd.Parameters["@do"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@prihod", MySqlDbType.Int64);
                    cmd.Parameters["@prihod"].Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();
                    return cmd.Parameters["@prihod"].Value as long? ??default(long);
                }
            }
        }

        public static DataTable GetProdaneUlazniceOdDoDataTable(DateTime? odDatum, DateTime? doDatum)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DobaviProdaneUlazniceOdDo"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("od", odDatum));
                    cmd.Parameters.Add(new MySqlParameter("do", doDatum));
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetProdaniProizvodiOdDo(DateTime? odDatum, DateTime? doDatum)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DobaviProdaneProizvode"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("od", odDatum));
                    cmd.Parameters.Add(new MySqlParameter("do", doDatum));
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public static DataTable GetNarudzbeOdDo(DateTime? odDatum, DateTime? doDatum)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DobaviNarudzbeOdDo"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("od", odDatum));
                    cmd.Parameters.Add(new MySqlParameter("do", doDatum));
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static void InsertNarudzbu( int ProizvodID, DateTime DatumNarudzbe,decimal Cijena,int kolicina,string Email,
            string Velicina,string Status,string Adresa, string Grad,string Drzava, string PostanskiBroj)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"INSERT INTO narudzba(proizvod_id,datum_narudzbe,ukupna_cijena,kolicina,email,proizvod_velicina,status_narudzbe,adresa,grad,drzava,postanski_broj) VALUES({ProizvodID.ToString()},'{DatumNarudzbe.ToString("yyyy'-'MM'-'dd' 'hh':'mm':'ss")}'," +
                        $"{Cijena.ToString()},{kolicina.ToString()},'{Email}','{Velicina}','{Status}','{Adresa}','{Grad}','{Drzava}','{PostanskiBroj}');";

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
