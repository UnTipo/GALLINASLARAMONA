using MvcApplication1.Statics;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MvcApplication1.DataAccess.Business_Objects;


namespace MvcApplication1.DataAccess.Repositories
{
    public class User_Repository
    {
        private string _connection;
        public User_Repository()
        {
            _connection = Constants.ConnectionString;
        }

        public List<User> GetUserAll()
        {
            return GetUserAllStore();
        }
        public User GetUserById(int id)
        {
            return GetUserStore(id);
        }

        public User GetUserLogin(string email, string password)
        {

            return GetUserLoginStore(email, password);
        }

        private List<User> GetUserAllStore()
        {
            SqlConnection conn = new SqlConnection(_connection);
            List<User> Users = new List<User>();
            SqlDataReader rdr = null;
            try
            {
                // Open the connection
                conn.Open();
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("GetUsersAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();
                // print the CategoryName of each record
                while (rdr.Read())
                {
                    User user = new User();

                    user.iduser = int.Parse(rdr["idUser"].ToString());
                    user.name = rdr["name"].ToString();
                    user.surname = rdr["surname"].ToString();
                    user.email = rdr["email"].ToString();
                    user.password = rdr["password"].ToString();
                    user.photoPath = rdr["photoPath"].ToString();
                    user.genre = rdr["genre"].ToString();
                    user.dateOfBirth = DateTime.Parse(rdr["dateOfBirth"].ToString());
                    user.idCity = int.Parse(rdr["idCity"].ToString());
                    user.mobileTelephone = rdr["mobileTelephone"].ToString();
                    user.homeTelephone = rdr["homeTelephone"].ToString();
                    user.occupation = rdr["occupation"].ToString();
                    user.dateOfRegistration = DateTime.Parse(rdr["dateOfRegistration"].ToString());
                    user.dateLastSession = DateTime.Parse(rdr["dateLastSession"].ToString());
                    user.isEmailConfirmed = bool.Parse(rdr["isEmailConfirmed"].ToString());
                    user.personalDescription = rdr["personalDescription"].ToString();
                    Users.Add(user);
                }
                return Users;
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

        private User GetUserStore(int id)
        {
            SqlConnection conn = new SqlConnection(_connection);
            List<User> Users = new List<User>();
            SqlDataReader rdr = null;
            try
            {
                // Open the connection
                conn.Open();
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("GetUsersId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idUser", System.Data.SqlDbType.Int)).Value = id;
                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();
                 // print the CategoryName of each record
                while (rdr.Read())
                {
                    User user = new User();

                    user.iduser = int.Parse(rdr["idUser"].ToString());
                    user.name = rdr["name"].ToString();
                    user.surname = rdr["surname"].ToString();
                    user.email = rdr["email"].ToString();
                    user.password = rdr["password"].ToString();
                    user.photoPath = rdr["photoPath"].ToString();
                    user.genre = rdr["genre"].ToString();
                    user.dateOfBirth = DateTime.Parse(rdr["dateOfBirth"].ToString());
                    user.idCity = int.Parse(rdr["idCity"].ToString());
                    user.mobileTelephone = rdr["mobileTelephone"].ToString();
                    user.homeTelephone = rdr["homeTelephone"].ToString();
                    user.occupation = rdr["occupation"].ToString();
                    user.dateOfRegistration = DateTime.Parse(rdr["dateOfRegistration"].ToString());
                    user.dateLastSession = DateTime.Parse(rdr["dateLastSession"].ToString());
                    user.isEmailConfirmed = bool.Parse(rdr["isEmailConfirmed"].ToString());
                    user.personalDescription = rdr["personalDescription"].ToString();
                    Users.Add(user);
                }
                return Users.FirstOrDefault();
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

        private User GetUserLoginStore(string email, string password)
        {
            SqlConnection conn = new SqlConnection(_connection);
            List<User> Users = new List<User>();
            SqlDataReader rdr = null;
            try
            {
                // Open the connection
                conn.Open();
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("GetUsersLogin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = email;
                cmd.Parameters.Add(new SqlParameter("@password", System.Data.SqlDbType.VarChar)).Value = password;
                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();
                // print the CategoryName of each record
                while (rdr.Read())
                {
                    User user = new User();

                    user.iduser = int.Parse(rdr["idUser"].ToString());
                    user.name = rdr["name"].ToString();
                    user.surname = rdr["surname"].ToString();
                    user.email = rdr["email"].ToString();
                    user.password = rdr["password"].ToString();
                    user.photoPath = rdr["photoPath"].ToString();
                    user.genre = rdr["genre"].ToString();
                    user.dateOfBirth = DateTime.Parse(rdr["dateOfBirth"].ToString());
                    user.idCity = int.Parse(rdr["idCity"].ToString());
                    user.mobileTelephone = rdr["mobileTelephone"].ToString();
                    user.homeTelephone = rdr["homeTelephone"].ToString();
                    user.occupation = rdr["occupation"].ToString();
                    user.dateOfRegistration = DateTime.Parse(rdr["dateOfRegistration"].ToString());
                    user.dateLastSession = DateTime.Parse(rdr["dateLastSession"].ToString());
                    user.isEmailConfirmed = bool.Parse(rdr["isEmailConfirmed"].ToString());
                    user.personalDescription = rdr["personalDescription"].ToString();
                    Users.Add(user);
                }
                return Users.FirstOrDefault();
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
    }
}