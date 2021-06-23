using BLZooDB.Model;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;

namespace BLZooDB.DAO
{
    public class SmjestajDAO
    {
        public static ObservableCollection<Smjestaj> GetSmjestaji()
        {
            var lista = new ObservableCollection<Smjestaj>();
            using (var conn = new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DobaviSmjestaje";
                    cmd.CommandType = CommandType.StoredProcedure;


                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(new Smjestaj(reader[0] as int? ?? default(int), reader[1] as string));
                    }

                }
            }
            return lista;
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
