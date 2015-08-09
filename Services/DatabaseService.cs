using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrainFit.Models;
using Windows.Storage;

namespace TrainFit.Services
{
    public class DatabaseService : IDatabaseService
    {
        #region fields
        public static string DB_NAME = "TrainFit.sqlite";
        public static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, DB_NAME));        
        #endregion

        #region methods
        public bool CreateTable<T>()
        {
            try
            {
                if (!FileExists(DB_NAME).Result)
                {
                    using (SQLiteConnection connection = new SQLiteConnection(DB_PATH))
                    {
                        connection.CreateTable<T>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            } 
        }

        public void DropTable<T>()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DB_PATH))
            {
                connection.DropTable<T>();
            }
        }

        public void InsertIntoDatabase<T>(T element) where T : ModelBase
        {
            if (element == null || element.IsStored) return;

            using (SQLiteConnection connection = new SQLiteConnection(DB_PATH))
            {
                connection.RunInTransaction(() => connection.Insert(element));
            }

            element.IsStored = true;
        }

        public void DeleteFromDatabase<T>(T element) where T : ModelBase
        {
            if (element == null || !element.IsStored) return;

            using (SQLiteConnection connection = new SQLiteConnection(DB_PATH))
            {
                connection.RunInTransaction(() => connection.Delete(element));
            }
        }

        public void UpdateInDatabase<T>(T element) where T : ModelBase
        {
            if (element == null || !element.IsStored || element.IsUpdated) return;

            using (SQLiteConnection connection = new SQLiteConnection(DB_PATH))
            {
                connection.RunInTransaction(() => connection.Update(element));
            }

            element.IsUpdated = true;
        }

        public void InsertAllIntoDatabase<T>(IEnumerable<T> elements) where T : ModelBase
        {
            if (elements == null || !elements.Any(element => !element.IsStored)) return;

            using (SQLiteConnection connection = new SQLiteConnection(DB_PATH))
            {
                connection.RunInTransaction(() => connection.InsertAll(elements.Where(element => !element.IsStored)));
            }
        }

        public T ReadFromDatabaseById<T>(int id) where T : ModelBase, new()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DB_PATH))
            {
                var queryVar = connection.Table<T>().Where(x => x.Id == id);
                var element = queryVar.FirstOrDefault();
                if (element != null) { element.IsStored = true; }
                return element;
            }
        }

        public ObservableCollection<T> ReadListFromDatabase<T>() where T : ModelBase, new()
        {
            using (var connection = new SQLiteConnection(DB_PATH))
            {
                List<T> elements = connection.Table<T>().ToList<T>();
                foreach (var element in elements)
	            {
		            element.IsStored = true;
	            }
                return new ObservableCollection<T>(elements);
            }
        } 
        #endregion

        #region helper methods
        private async Task<bool> FileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        } 
        #endregion
    }
}