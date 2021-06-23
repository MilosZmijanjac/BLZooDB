using BLZooDB.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;

namespace BLZooDB.DAO
{

    public class ZaposleniDAO
    {
        public static bool IsValidZaposleni(int id, string pass)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "Login";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters["@id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters["@pass"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@result", MySqlDbType.Int16);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    return (Int16)cmd.Parameters["@result"].Value == 1;
                }
            }
        }

        public static bool IsMenadzer(int id)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "isMenadzer";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters["@id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@isMenadzer", MySqlDbType.Int16);
                    cmd.Parameters["@isMenadzer"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    return (Int16)cmd.Parameters["@isMenadzer"].Value !=0;
                }
            }
        }

        public static int DodajZapolsnoeg(string z_lozinka,string z_ime,string z_prezime,int z_nadredjeni_id,int z_odjeljenje_id)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DodajZaposlenog";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@z_lozinka", z_lozinka);
                    cmd.Parameters["@z_lozinka"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@z_ime", z_ime);
                    cmd.Parameters["@z_ime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@z_prezime", z_prezime);
                    cmd.Parameters["@z_prezime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@z_nadredjeni_id", z_nadredjeni_id);
                    cmd.Parameters["@z_nadredjeni_id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@z_odjeljenje_id", z_odjeljenje_id);
                    cmd.Parameters["@z_odjeljenje_id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@z_id", MySqlDbType.Int16);
                    cmd.Parameters["@z_id"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    return (Int16)cmd.Parameters["@z_id"].Value;
                }
            }
        }

        public static DataTable GetZaposleniDataTable()
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("select * from ZaposleniListView"))
                {
                    cmd.Connection = conn;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public static ObservableCollection<Zaposleni> GetZaposleniList(int id)
        {
            var lista = new ObservableCollection<Zaposleni>();
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("select * from ZaposleniListView where zaposleni_id!="+id.ToString()))
                {
                    cmd.Connection = conn;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                       while( reader.Read())
                        lista.Add( new Zaposleni(id,
                            reader[1] as string ?? default(string),
                            reader[2] as string ?? default(string),
                            reader[3] as string ?? default(string),
                            reader[4] as int? ?? default(int),
                            reader[5] as int? ?? default(int),
                            reader[6] as string ?? default(string),
                            reader[7] as string ?? default(string)));
                    }
                }
            }
            return lista;
        }

        public static ObservableCollection<Zaposleni> GetZaposleniList()
        {
            var lista = new ObservableCollection<Zaposleni>();
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("select * from ZaposleniListView"))
                {
                    cmd.Connection = conn;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(new Zaposleni(reader[0] as int? ?? default(int),
                                reader[1] as string ?? default(string),
                                reader[2] as string ?? default(string),
                                reader[3] as string ?? default(string),
                                reader[4] as int? ?? default(int),
                                reader[5] as int? ?? default(int),
                                reader[6] as string ?? default(string),
                                reader[7] as string ?? default(string)));
                    }
                }
            }
            return lista;
        }

        public static void UpdateLozinka(int id, string oldpass, string newpass)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "PromjeniLozinku";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters["@id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@oldpass", oldpass);
                    cmd.Parameters["@oldpass"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@newpass", newpass);
                    cmd.Parameters["@newpass"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public static void ObrisiZaposlenog(int id)
        {
            using(var conn =new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using(var cmd=new MySqlCommand("ObrisiZaposlenog"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    cmd.Parameters.Add(new MySqlParameter("id", id));
                    cmd.ExecuteNonQuery();

                }
            }
        }


        public static Zaposleni GetZaposleni(int id)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DobaviZaposlenogPoID";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters["@id"].Direction = ParameterDirection.Input;

                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return new Zaposleni(id,
                            reader[1]as string ??default(string),
                            reader[2] as string ?? default(string),
                            reader[3] as string ?? default(string),
                            reader[4] as int? ?? default(int),
                            reader[5] as int? ?? default(int));
                    }

                }
            }
        }


        public static void GetZaposleniInfo(int id, out int odjel_id, out int isM, out int isC)
        {
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DobaviInformacijeOZaposlenom";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters["@id"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@odjel_id", MySqlDbType.Int16);
                    cmd.Parameters["@odjel_id"].Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@isMenadzer", MySqlDbType.Int16);
                    cmd.Parameters["@isMenadzer"].Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@isCuvar", MySqlDbType.Int16);
                    cmd.Parameters["@isCuvar"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    odjel_id = (Int16)cmd.Parameters["@odjel_id"].Value;
                    isM = (Int16)cmd.Parameters["@isMenadzer"].Value;
                    isC = (Int16)cmd.Parameters["@isCuvar"].Value;
                }
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
