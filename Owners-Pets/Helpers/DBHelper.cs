using System.Data.SQLite;
using Owners_Pets.Models;
using System.Collections.Generic;
using System.Data;
using System;
using System.Web;

namespace Owners_Pets.Helpers
{
    public class DBHelper
    {
        static string db = HttpContext.Current.Server.MapPath(@"~\OwnersPets.db");
        private static string _connectionString = $"Data Source = {db};Version=3;";
        
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
                    fmd.CommandText = @"select o.id as ID, o.name as Name, IFNULL(p.CNT,0) PetCount from owners o left join (SELECT ownerid, COUNT(*) CNT FROM pets GROUP BY ownerid ) p on o.id = p.ownerid";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader reader = fmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listOfFullDetails.Add(new Information()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = Convert.ToString(reader["Name"]),
                            PetsCount = Convert.ToInt32(reader["PetCount"])
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
        public static long AddOwner(string name)
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();
                using (SQLiteCommand fmd = dbConnection.CreateCommand())
                {
                    fmd.CommandText = $"insert into Owners ('Name') values ('{name}'); SELECT last_insert_rowid();";
                    long id = (long)fmd.ExecuteScalar();
                    return id;
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
                    fmd.ExecuteNonQuery();
                    fmd.CommandText = $"delete from Pets where ownerid = {id}";
                    fmd.ExecuteNonQuery();
                }
            }
        }


        #endregion

        #region PetsController

        /// <summary>
        /// Shows all pets name of a certain owner 
        /// </summary>
        public static List<Pet> ViewPetsDetails(int ownerId)
        {
            var resultList = new List<Pet>();
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();
                using (SQLiteCommand fmd = dbConnection.CreateCommand())
                {
                    fmd.CommandText = $"select id as Id, name as PetName, ownerID as OwnerId from pets where ownerid = {ownerId}";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader reader = fmd.ExecuteReader();
                    while (reader.Read())
                    {
                        resultList.Add(new Pet
                        {
                            PetId = Convert.ToInt32(reader["Id"]),
                            PetName = Convert.ToString(reader["PetName"]),
                            OwnerId = Convert.ToInt32(reader["OwnerId"]),
                        });
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
        public static long AddPet(string name, int ownerId)
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();
                using (SQLiteCommand fmd = dbConnection.CreateCommand())
                {
                    fmd.CommandText = $"insert into Pets ('Name','OwnerId') values ('{name}','{ownerId}');SELECT last_insert_rowid();";
                    long petId = (long)fmd.ExecuteScalar();
                    return petId;
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
                    fmd.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}