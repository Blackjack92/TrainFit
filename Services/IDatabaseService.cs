using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainFit.Models;

namespace TrainFit.Services
{
    public interface IDatabaseService
    {
        bool CreateTable<T>();
        void DropTable<T>();

        // General database methods
        void InsertIntoDatabase<T>(T element) where T : ModelBase;
        void DeleteFromDatabase<T>(T element) where T : ModelBase;
        void UpdateInDatabase<T>(T element) where T : ModelBase;
        void InsertAllIntoDatabase<T>(IEnumerable<T> elements) where T : ModelBase;

        // Read elements
        T ReadFromDatabaseById<T>(int id) where T : ModelBase, new();
        ObservableCollection<T> ReadListFromDatabase<T>() where T : ModelBase, new();
    }
}