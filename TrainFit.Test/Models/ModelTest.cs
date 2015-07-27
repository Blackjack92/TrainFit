using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainFit.Models;
using TrainFit.Services;

namespace TrainFit.Test.Models
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void UserSetName()
        {
            User user = new User();
            Assert.AreEqual(null, user.Name);

            string name = "Hans";
            user.Name = name;
            Assert.AreEqual(name, user.Name);
        }



        [TestMethod]
        public void SqliteNetUri()
        {
            

            String uriString = "c://";
            String nameString = "testName123123";
            Exercise exercise = new Exercise();
            exercise.Name = nameString;
            exercise.Url = new Uri(uriString);

            List<Exercise> exercisesToBeSaved = new List<Exercise>();
            exercisesToBeSaved.Add(exercise);

            DatabaseService dbService = new DatabaseService();
            dbService.CreateTable<Exercise>();
            dbService.InsertAllIntoDatabase(exercisesToBeSaved);

            ObservableCollection<Exercise> exercisesLoadedFirstTime = dbService.ReadListFromDatabase<Exercise>();

            IEnumerable<Exercise> exercisesLoadedFirstTimeWithSpecialName = exercisesLoadedFirstTime.Where(ex => ex.Name.Equals(nameString));

            Assert.AreEqual(1, exercisesLoadedFirstTimeWithSpecialName.Count());
            var returnedToTestExercise = exercisesLoadedFirstTimeWithSpecialName.First();
            Assert.IsNotNull(returnedToTestExercise);
                Assert.IsNotNull(returnedToTestExercise.Url);
                Assert.AreEqual(uriString, returnedToTestExercise.Url.AbsolutePath);
           
           



            dbService.DeleteFromDatabase(returnedToTestExercise);

            ObservableCollection<Exercise> exercisesLoadedSecondTime = dbService.ReadListFromDatabase<Exercise>();

            IEnumerable<Exercise> exercisesLoadedSecondTimeWithSpecialName = exercisesLoadedSecondTime.Where(ex => ex.Name.Equals(nameString));
            Assert.AreEqual(0,exercisesLoadedSecondTimeWithSpecialName.Count());

           
            
        }

    }
}
