using Android.Util;
using BornesElec;
using SQLite;
using System.Collections.Generic;
using System.Linq;
namespace SQLiteDB.Resources.Helper
{
    public class Database
    {



        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Bornes.db")))
                {
                    connection.CreateTable<Bornes>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        //Add or Insert Operation  

        public bool insertIntoTable(Bornes borne)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Bornes.db")))
                {
                    connection.Insert(borne);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public List<Bornes> selectTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Bornes.db")))
                {
                    return connection.Table<Bornes>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        //Edit Operation  

        public bool updateTable(Bornes borne)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Bornes.db")))
                {
                    connection.Query<Bornes>("UPDATE Borne set name=?, adresse=?, ville=?, codepostal=?,latitude=?,longitude=?,tarif=? Where Id=?", borne.name, borne.adresse, borne.ville, borne.codepostal, borne.latitude, borne.longitude, borne.tarif, borne.id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        //Delete Data Operation  

        public bool removeTable(Bornes borne)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Bornes.db")))
                {
                    connection.Delete(borne);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        //Select Operation  
        public List<Bornes> GetBornes()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Bornes.db")))
                {
                    return connection.Table<Bornes>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool selectTable(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Bornes.db")))
                {
                    connection.Query<Bornes>("SELECT * FROM Borne Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}




//using Android.App;
//using Android.OS;
//using Android.Runtime;
//using Android.Widget;
//using AndroidX.AppCompat.App;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Net.Http;
//using BornesElec;
//using Android.Content;
//using SQLite;
//using System.Threading.Tasks;

//namespace Borneselec
//{
//    class Database
//    {
//        private readonly SQLiteAsyncConnection db;

//        public Database(string dbPath)
//        {
//            db = new SQLiteAsyncConnection(dbPath);
//            db.CreateTableAsync<Bornes>();
//        }
//        public Task<int> CreateBorne(Bornes bornes)
//        {
//            return db.InsertAsync(bornes);
//        }
//        public Task<List<Bornes>> ReadBornes()
//        {
//            return db.Table<Bornes>().ToListAsync();
//        }
//        public Task<int> UpdateBorne(Bornes bornes)
//        {
//            return db.UpdateAsync(bornes);
//        }
//        public Task<int> saveProduct(Bornes bornes)
//        {
//            if (bornes.id == 0)
//                return db.InsertAsync(bornes);
//            else
//                return db.UpdateAsync(bornes);
//        }
//        public Task<int> DeleteBorne(Bornes bornes)
//        {
//            return db.DeleteAsync(bornes);
//        }

//        public Task<List<Bornes>> GetAllBornes()
//        {

//            return db.Table<Bornes>().ToListAsync();
//        }
//    }
//}
