using System.Data.SQLite;
using Owners_Pets.Models;
using System.Collections.Generic;
using System.Data;
using System;

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

        #region OwnersController

        /// <summary>
        /// Shows owners name and their pets count
        /// </summary>
        public static List<Information> ViewFullDetails()
        {
            var listOfFullDetails = new List<Information>();
            using (var dbConnection = new SQLiteConnection(@"Data Source=C:\git_root\Owners-Pets\Owners-Pets\Ownerships.db;Version=3;"))
            {
                dbConnection.Open();
                using (SQLiteCommand fmd = dbConnection.CreateCommand())
                {
                    fmd.CommandText = @"Select owners.name as Name, Count(pets.name) as Pets_Count from owners inner join pets on pets.ownerid = owners.id group by owners.name";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader reader = fmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listOfFullDetails.Add(new Information()
                        {
                            Name = Convert.ToString(reader["Name"]),
                            PetsCount = Convert.ToString(reader["Pets_Count"])
                        });
                    }
                }
                return listOfFullDetails;
            }
        }

        /// <summary>
        /// returns total count of owners in db
        /// </summary>
        /// <returns></returns>
        public static string GetOwnersCount()
        {
            string stringResult = null;
            using (var dbConnection = new SQLiteConnection(@"Data Source=C:\git_root\Owners-Pets\Owners-Pets\Ownerships.db;Version=3;"))
            {
                dbConnection.Open();
                using (SQLiteCommand fmd = dbConnection.CreateCommand())
                {
                    fmd.CommandText = @"Select count(name) as OwnersCount from Owners";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader reader = fmd.ExecuteReader();
                    while (reader.Read())
                    {
                        stringResult = Convert.ToString(reader["OwnersCount"]);
                    }
                }
            }
            return stringResult;
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
        /// Delete owner by ID
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteOwner(int id)
        {
            string sql = $"delete from Owners where ID = {id}";
            _command = new SQLiteCommand(sql, _dbConnection);
            _command.ExecuteNonQuery();
        }


        #endregion

        #region PetsController

        /// <summary>
        /// Shows all pets name of a certain owner 
        /// </summary>
        public static void ViewOwnerDetails(int ownerId)
        {
            string sql = $"select name from pets where ownerid = {ownerId}";
            _command = new SQLiteCommand(sql, _dbConnection);
            _command.ExecuteNonQuery();
        }

        /// <summary>
        /// Allows to add pet to the pets table
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ownerId"></param>
        public static void AddPet(string name, int ownerId)
        {
            string sql = $"insert into Pets ('Name','OwnerId') values ('{name}','{ownerId}')";
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
        #endregion
        

        

       


    }

}