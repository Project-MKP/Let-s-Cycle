using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Xamarin.Essentials;
//using MySql.Data.MySqlClient;

namespace letscycle
{
    public class SqlConnector
    {
        public  List<Track> Connect(string cs, string query)
        {
            List<Track> expList = new List<Track>();
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                using var con = new MySqlConnection(cs);
                try
                {
                    con.Open();
                
                    string sql = query;
                    using var cmd = new MySqlCommand(sql, con);

                    using MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                     expList.Add(new Track() { imgPath = rdr.GetString(1).Replace(" ", "_") + ".png", street = rdr.GetString(1), bikersToday = rdr.GetString(2) });
                    }
                }
                catch 
                {
                    return null;
                }
            }
            return expList;
        }

        public List<string> GetWeather(string cs, string query)
        {
            List<string> weatherData = new List<string>(); //temperatura, pogoda, powietrze, obrazek

            using var con = new MySqlConnection(cs);
            try
            {
                con.Open();
            
                using var cmd = new MySqlCommand(query, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    weatherData.Add(rdr.GetString(1));
                    weatherData.Add(rdr.GetString(2));
                    weatherData.Add(rdr.GetString(3));
                    weatherData.Add(rdr.GetString(4));
                }
                con.Close();
                return weatherData;
            }
            catch 
            {
                return null;
            }
        }

        public List<string> GetVeturilo(string cs, string query)
        {
            List<string> veturiloData = new List<string>(); //stacje, rowery, wolner rowery

            using var con = new MySqlConnection(cs);
            try
            {
                con.Open();
                using var cmd = new MySqlCommand(query, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    veturiloData.Add(rdr.GetString(1));
                    veturiloData.Add(rdr.GetString(2));
                    veturiloData.Add(rdr.GetString(3));
                }
                con.Close();
                return veturiloData;
            }
            catch
            {
                return null;
            }
        }
    }
}
