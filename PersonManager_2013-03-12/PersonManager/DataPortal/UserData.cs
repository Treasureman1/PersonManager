﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataPortal
{
    public class UserData
    {
        #region "Declarations"
        //
        //
        //C:\Users\Tom\Desktop\Person Manager\PersonManager\PersonManager_2013-03-12\PersonManager\DataManager\InventoryDatabase.mdf
        //C:\Users\Tom\Desktop\Person Manager\PersonManager\PersonManager_2013-03-12\PersonManager\DataManager\InventoryDatabase.mdf
      //  string _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Tom\\Desktop\\Person Manager\\PersonManager\\PersonManager_2013-03-12\\PersonManager\\DataManager\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";
      string _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Tom\\Desktop\\Person Manager\\PersonManager\\PersonManager_2013-03-12\\PersonManager\\DataManager\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";
      //  String _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Tom\\Desktop\\Person Manager\\PersonManager\\PersonManager_2013-03-12\\PersonManager\\DataManager\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";
    
        // C:\\BegASPNET\\PersonManager\\PersonManager\\PersonManager\\DataManager\\App_Data\\InventoryDatabase.mdf
      //   String _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\BegASPNET\\PersonManager\\PersonManager\\PersonManager\\DataManager\\App_Data\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";


        #endregion

        #region "Constructors"

        public UserData() { }

        #endregion

        #region "Public Methods"

        public DataSet Fetch(int UserID)
        {
            DataSet ds = new DataSet();
            string sqlStatementString = "SELECT UserID, Username, Password FROM [User] WHERE UserID = @UserID";
            SqlConnection cn;

            cn = new SqlConnection(_connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sqlStatementString;
            cmd.Parameters.AddWithValue("@UserID", UserID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);
            cn.Close();

            da = null;
            cmd = null;
            cn = null;

            return ds;

        }

        public void
          InsertUser2(int UserID, String Username, String Password) 
        {
           // String sqlStatementString = "INSERT INTO User (UserID, PersonID, Username, Password)";
         //   String sqlStatementString = "INSERT INTO User (UserID, PersonID, Username, Password) VALUES (@UserID, @PersonID, @Username, @Password) SELECT @@IDENTITY AS UserID";
            String sqlStatementString = "INSERT INTO [User] (UserID, Username, Password) VALUES (@UserID, @Username, @Password)";
           
            SqlConnection dbConnection;
            //"INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName)"

            // We need a variable to hold the ID value of the record we are inserting
            //object userID;

            dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@UserID", UserID);
            dbCommand.Parameters.AddWithValue("@Username", Username);
            dbCommand.Parameters.AddWithValue("@Password", Password);


            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;

            // Finally, we need to return the value of personID
          // return userID;
        }


         public void
          InsertUser3(int UserID, String Username, String Password) 
        {
           // String sqlStatementString = "INSERT INTO User (UserID, PersonID, Username, Password)";
            String sqlStatementString = "INSERT INTO [User] (UserID, Username, Password) VALUES (@UserID, @Username, @Password)";
            SqlConnection dbConnection;

            // We need a variable to hold the ID value of the record we are inserting
         //  object userID;

            dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@UserID", UserID);         
            dbCommand.Parameters.AddWithValue("@Username", Username);
            dbCommand.Parameters.AddWithValue("@Password", Password);
            dbCommand.ExecuteNonQuery();

           // userID = dbCommand.ExecuteScalar();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;

            // Finally, we need to return the value of personID
         //  return UserID;
        }

        public DataSet FetchAll()
        {
            DataSet ds = new DataSet();

            String sql = "SELECT UserID, Username, Password FROM [User]";
            SqlConnection cn;

            cn = new SqlConnection(_connectionString);

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            cn.Close();

            da = null;
            cmd = null;
            cn = null;

            return ds;
        }

        //public int Create()
        //{
        //    int addressID = 0;

        //    return addressID;
        //}

        public void Update()
        {
        }

        public void UpdateUser(int UserID, String Username, String Password)
        {
            // DataSet ds = new DataSet();

            String sqlStatementString = "UPDATE [User] SET UserID = @UserID, Username = @Username, Password = @Password WHERE UserID = @UserID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@UserID", UserID);
            dbCommand.Parameters.AddWithValue("@Username", Username);
            dbCommand.Parameters.AddWithValue("@Password", Password);

            dbCommand.ExecuteNonQuery();


            dbConnection.Close();

            //        dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            //   return ds;

        }

        public void Delete()
        {
        }

        #endregion

    }
}