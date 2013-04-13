using DataAccess.Business_Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class City_Repository
    {
        private string _connection;
        public City_Repository(string Connection)
        {
            _connection = Connection;
        }

        public List<City> GetPoblacionAll()
        {
            return GetPoblacionAllStore();
        }

        private List<City> GetPoblacionAllStore()
        {
            SqlConnection conn = new SqlConnection(_connection);
            List<City> Cities = new List<City>();
            SqlDataReader rdr = null;
            try
            {
                // Open the connection
                conn.Open();
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("MunicipiosGetAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();
                // print the CategoryName of each record
                while (rdr.Read())
                {
                    City city = new City();
                    city.idmunicipio = int.Parse(rdr["idmunicipio"].ToString());
                    city.name = rdr["name"].ToString();
                    city.comunidad = rdr["comunidad"].ToString();
                    city.provincia = rdr["provincia"].ToString();
                    city.latitude = decimal.Parse(rdr["latitud"].ToString());
                    city.longitude = decimal.Parse(rdr["longitud"].ToString());
                    Cities.Add(city);
                }
                return Cities;
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public List<City> GetCitiesByPoblacion(string poblacion)
        {
          
            List<City> cities =GetPoblacionAll();
            List<City> list = (from u in cities
                               where u.name.Trim().ToUpper().StartsWith(poblacion.Trim().ToUpper())
                               select u).ToList<City>();
            return list;


        }


    }
}