using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace Owners_Pets.Helpers
{
    public static class DBHelper
    {
        private static SQLiteConnection _dbConnection;
        private static SQLiteCommand _command;

        /// <summary>
        /// Starts the connection whith DataBase
        /// </summary>
        public static void StartConnection()
        {
            _dbConnection = new SQLiteConnection(@"Data Source=C:\git_root\Owners-Pets\Owners-Pets\Ownerships.db;Version=3;");
            _dbConnection.Open();
            
        }
        /// <summary>
        /// Allows to add owner to the Owners table
        /// </summary>
        /// <param name="name"></param>
        public static void AddOwner(string name)
        {
            string sql = $"insert into Owners ('Name') values ('{name}')";
            _command = new SQLiteCommand(sql, _dbConnection);
             _command.ExecuteNonQuery();
        }
        /// <summary>
        /// Allows to add pet to the pets table
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ownerId"></param>
        public static void AddPet(string name,int ownerId)
        {
            string sql = $"insert into Pets ('Name','OwnerId') values ('{name}','{ownerId}')";
            _command = new SQLiteCommand(sql, _dbConnection);
            _command.ExecuteNonQuery();
        }
        /// <summary>
        /// Delete owner by ID
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteOwner(int id)
        {
            string sql = $"delete from Owners where ID = {id}";
            _command = new SQLiteCommand(sql, _dbConnection);
            _command.ExecuteNonQuery();
        }
        /// <summary>
        /// Delete pet by ID
        /// </summary>
        /// <param name="id"></param>
        public static void DeletePet(int id)
        {
            string sql = $"delete from Pets where ID = {id}";
            _command = new SQLiteCommand(sql, _dbConnection);
            _command.ExecuteNonQuery();
        }

        //TODO add constraint to the foreign key.
    }

    //
}