using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DataAccess.Business_Objects;


namespace DataAccess.Repositories
{
    public class User_Repository
    {
        #region //Properties
        private string _connection;
        #endregion

        #region //Constructor
        public User_Repository(string Connection)
        {
            _connection = Connection;
        }
        #endregion

        #region //Public method
        public List<Users> GetUserAll()
        {
            return GetUserAllStore();
        }
        public Users GetUserById(int? id)
        {
            return GetUserStore(id);
        }

        public int GetUserLogin(string email, string password)
        {

            return GetUserLoginStore(email, password);
        }

        public Users GetUserByEmail(string email)
        {
            return GetUserEmailStore(email);
        }

        public bool UpdateResetPassword(int iduser, string resetpassword)
        {
            return UpdateResetPasswordStore(iduser, resetpassword);
        }

        public Users GetUserEbyIdResetPassword(int id, string resetPassword)
        {
            return GetUserEbyIdResetPasswordStore(id, resetPassword);
        }

        public bool UsersUpdatePassword(int id, string Password)
        {
            return UsersUpdatePasswordStore(id, Password);
        }

        #endregion

        #region //Private method
        private List<Users> GetUserAllStore()
        {
            SqlConnection conn = new SqlConnection(_connection);
            List<Users> Users = new List<Users>();
            SqlDataReader rdr = null;
            try
            {
                // Open the connection
                conn.Open();
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("UsersGetAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();
                // print the CategoryName of each record
                while (rdr.Read())
                {
                    Users user = new Users();

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

        private Users GetUserStore(int? id)
        {
            SqlConnection conn = new SqlConnection(_connection);
            List<Users> Users = new List<Users>();
            SqlDataReader rdr = null;
            try
            {
                // Open the connection
                conn.Open();
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("UsersGetById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idUser", System.Data.SqlDbType.Int)).Value = id;
                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Users user = new Users();

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
                return new Users();
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

        private int GetUserLoginStore(string email, string password)
        {
            SqlConnection conn = new SqlConnection(_connection);
            List<Users> Users = new List<Users>();
            int _id = 0;
            SqlDataReader rdr = null;
            try
            {
                // Open the connection
                conn.Open();
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("UsersLogin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = email;
                cmd.Parameters.Add(new SqlParameter("@password", System.Data.SqlDbType.VarChar)).Value = password;
                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();
                // print the CategoryName of each record
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Users user = new Users();

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
                    _id = Users.FirstOrDefault().iduser;
                }
                return _id;
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

        private Users GetUserEmailStore(string email)
        {
            SqlConnection conn = new SqlConnection(_connection);
            List<Users> Users = new List<Users>();
            SqlDataReader rdr = null;
            try
            {
                // Open the connection
                conn.Open();
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("UsersGetEmail", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = email;
                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Users user = new Users();

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
                return new Users();
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

        private bool UpdateResetPasswordStore(int iduser, string resetpassword)
        {
           
            SqlConnection conn = new SqlConnection(_connection);
            try
            {
                // Open the connection
                conn.Open();
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("UsersUpdateResetPassword", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = iduser;
                cmd.Parameters.Add(new SqlParameter("@resetPassword", System.Data.SqlDbType.VarChar)).Value = resetpassword;
                
                // 2. Call Execute reader to get query results
               int results = cmd.ExecuteNonQuery();
                //only update one file (files updates have to be only 1) 
                if (results == 1)
                    return true;
                else
                    return false;
                                         
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
         
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        
        private Users GetUserEbyIdResetPasswordStore(int id, string resetPassword)
        {
            SqlConnection conn = new SqlConnection(_connection);
            List<Users> Users = new List<Users>();
            SqlDataReader rdr = null;
            try
            {
                // Open the connection
                conn.Open();
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("UsersGetByIdResetPassword", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idUser", System.Data.SqlDbType.Int)).Value = id;
                cmd.Parameters.Add(new SqlParameter("@resetPassword", System.Data.SqlDbType.VarChar)).Value = resetPassword;
                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Users user = new Users();

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
                return new Users();
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

        private bool UsersUpdatePasswordStore(int iduser, string password)
        {

            SqlConnection conn = new SqlConnection(_connection);
            try
            {
                // Open the connection
                conn.Open();
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("UsersUpdatePassword", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = iduser;
                cmd.Parameters.Add(new SqlParameter("@Password", System.Data.SqlDbType.VarChar)).Value = password;

                // 2. Call Execute reader to get query results
                int results = cmd.ExecuteNonQuery();
                //only update one file (files updates have to be only 1) 
                if (results == 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        #endregion
    }
}