﻿using System.Data.SQLite;
using Owners_Pets.Models;
using System.Collections.Generic;
using System.Data;
using System;

namespace Owners_Pets.Helpers
{
    public static class DBHelper
    {
        private static string _connectionString = @"Data Source = C:\git_root\Owners-Pets\Owners-Pets\OwnersPets.db;Version=3;";
        /// <summary>
        /// Starts the connection whith DataBase
        /// </summary>
        

        #region OwnersController

        /// <summary>
        /// Shows owners name and their pets count
        /// </summary>
        public static List<Information> ViewFullDetails()
        {
            var listOfFullDetails = new List<Information>();
            using (var dbConnection = new SQLiteConnection(_connectionString))
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
            using (var dbConnection = new SQLiteConnection(_connectionString))
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
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();
                using (SQLiteCommand fmd = dbConnection.CreateCommand())
                {
                    fmd.CommandText = $"insert into Owners ('Name') values ('{name}')";
                    fmd.CommandType = CommandType.Text;
                }
                    
            }    
        }

        /// <summary>
        /// Delete owner by ID
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteOwner(int id)
        { 
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();
                using (SQLiteCommand fmd = dbConnection.CreateCommand())
                {
                    fmd.CommandText = $"delete from Owners where ID = {id}";
                    fmd.CommandType = CommandType.Text;
                }

            }
        }


        #endregion

        #region PetsController

        /// <summary>
        /// Shows all pets name of a certain owner 
        /// </summary>
        public static List<string> ViewOwnerDetails(int ownerId)
        {
            var resultList = new List<string>();
            using (var dbConnection = new SQLiteConnection(@"Data Source=C:\git_root\Owners-Pets\Owners-Pets\Ownerships.db;Version=3;"))
            {
                dbConnection.Open();
                using (SQLiteCommand fmd = dbConnection.CreateCommand())
                {
                    fmd.CommandText = $"select name from pets where ownerid = {ownerId}";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader reader = fmd.ExecuteReader();
                    while (reader.Read())
                    {
                        resultList.Add(Convert.ToString(reader["name"]));
                    }
                }
                return resultList;
            }
        }

        /// <summary>
        /// Allows to add pet to the pets table
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ownerId"></param>
        public static void AddPet(string name, int ownerId)
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();
                using (SQLiteCommand fmd = dbConnection.CreateCommand())
                {
                    fmd.CommandText = $"insert into Pets ('Name','OwnerId') values ('{name}','{ownerId}')";
                    fmd.CommandType = CommandType.Text;
                }

            }
        }

        /// <summary>
        /// Delete pet by ID
        /// </summary>
        /// <param name="id"></param>
        public static void DeletePet(int id)
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();
                using (SQLiteCommand fmd = dbConnection.CreateCommand())
                {
                    fmd.CommandText = $"delete from Pets where ID = {id}";
                    fmd.CommandType = CommandType.Text;
                }

            }
        }
        #endregion
        

        

       


    }

}