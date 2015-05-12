using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainFit.Models;
using Windows.Storage;

namespace TrainFit.Services
{
    public class DatabaseService
    {
        #region fields
        private readonly string database = "TrainFit.db";
        #endregion

        #region methods
        // TODO: test this database stuff and make it generic if possible!
        public void ConnectToDatabase()
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(database);
            connection.CreateTableAsync<Exercise>();
        }

        public async void DropDatabase()
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(database);
            await connection.DropTableAsync<Exercise>();
        }

        public async Task<int> InsertExerciseIntoDatabase(Exercise exercise)
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(database);
            return await connection.InsertAsync(exercise);
        }

        public async Task<bool> DoesDatabaseExist(string DatabaseName)
        {
            bool dbexist = true;
            try
            {
                StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(DatabaseName);
            }
            catch
            {
                dbexist = false;
            }

            return dbexist;
        }

        public Task<Exercise> ReadExerciseFromDatabaseByName(string name)
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(database);
            var queryVar = connection.Table<Exercise>().Where(x => x.Name.StartsWith(name));
            return queryVar.FirstOrDefaultAsync();
        }
        #endregion
    }
}
