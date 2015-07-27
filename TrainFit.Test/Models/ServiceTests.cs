using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainFit.Comparers;
using TrainFit.Models;
using TrainFit.Services;

namespace TrainFit.Test.Models
{
    [TestClass]
    public class ServiceTests
    {
        private static string defaultUriString = "C://";

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
        public async Task XmlServiceWriteAndReadExercise()
        {
            var expectedExercise = new Exercise()
            {
                Id = 1,
                Name = "exercise1",
                Description = "description",
                Difficulty = Difficulty.Hard,
            };

            await XmlService.SaveObjectToXml(expectedExercise, "exerciseTest.xml");
            var actualExercise = await XmlService.ReadObjectFromXmlFileAsync<Exercise>("exerciseTest.xml");

            ExerciseComparer comparer = new ExerciseComparer();
            Assert.IsTrue(comparer.Equals(expectedExercise, actualExercise));
        }

        [TestMethod]
        public void DatabaseServiceStoreLoadUri()
        {
            string uriString = defaultUriString;
            string nameString = "testName123123";
            var expectedExercise = new Exercise()
            {
                Name = nameString,
                Url = new Uri(uriString)
            };
           
            var dbService = new DatabaseService();
            dbService.CreateTable<Exercise>();
            dbService.InsertIntoDatabase(expectedExercise);

            var exercisesLoadedFirstTime = dbService.ReadListFromDatabase<Exercise>();
            var exercisesLoadedFirstTimeByName = exercisesLoadedFirstTime.Where(ex => ex.Name.Equals(nameString));
            var actualExercise = exercisesLoadedFirstTimeByName.First();

            // checks
            ExerciseComparer comparer = new ExerciseComparer();
            Assert.AreEqual(1, exercisesLoadedFirstTimeByName.Count());
            Assert.IsNotNull(actualExercise);
            Assert.IsNotNull(actualExercise.Url);
            Assert.AreEqual(uriString, actualExercise.Url.AbsolutePath);
            Assert.IsTrue(comparer.Equals(expectedExercise, actualExercise));

            dbService.DeleteFromDatabase(actualExercise);
            var exercisesLoadedSecondTime = dbService.ReadListFromDatabase<Exercise>();
            var exercisesLoadedSecondTimeWithSpecialName = exercisesLoadedSecondTime.Where(ex => ex.Name.Equals(nameString));
            Assert.AreEqual(0,exercisesLoadedSecondTimeWithSpecialName.Count());
        }

    }
}
