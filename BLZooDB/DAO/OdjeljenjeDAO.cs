using BLZooDB.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLZooDB.DAO
{
    public class OdjeljenjeDAO
    {
        public static ObservableCollection<Odjeljenje> GetOdjeljenja()
        {
            var lista = new ObservableCollection<Odjeljenje>();

            using(var conn=new MySqlConnection(LoadConnectionString()))
            {
                conn.Open();
                using(var cmd=new MySqlCommand("DobaviOdjeljenja"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(new Odjeljenje(reader[0] as int? ?? default(int), reader[1] as string ?? default(string), reader[2] as int? ?? default(int)));
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
