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
using TrainFit.Test.Comparers;
using TrainFit.Test.Helpers;

namespace TrainFit.Test.ServiceTests
{
    [TestClass]
    public class ServiceTests
    {
        private static string defaultUriString = "C://";
        private static string defaultUriString2 = "https://www.google.at/";

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
                Url = defaultUriString,
                ImageSource = defaultUriString,
                IsStored = false,
                IsUpdated = true
            };

            // Store object in xml
            await XmlService.SaveObjectToXml(expectedExercise, "exerciseTest.xml");
            var actualExercise = await XmlService.ReadObjectFromXmlFileAsync<Exercise>("exerciseTest.xml");

            // Load object from xml
            ExerciseComparer comparer = new ExerciseComparer();
            Assert.IsTrue(comparer.Equals(expectedExercise, actualExercise));
        }

        [TestMethod]
        public void DatabaseServiceStoreLoadUri()
        {
            var expectedPseudoObject = new PseudoClass()
            {
                Source1 = new Uri(defaultUriString),
                Source2 = new Uri(defaultUriString2),
                Source3 = new Uri(defaultUriString)
            };

            var dbService = new DatabaseService();
            dbService.CreateTable<PseudoClass>();

            // Insert into database
            dbService.InsertIntoDatabase(expectedPseudoObject);

            // Read from database
            var actualPseudoObjectList = dbService.ReadListFromDatabase<PseudoClass>();
            var actualPseudoObject = actualPseudoObjectList.FirstOrDefault();

            // Check result
            PseudoComparer comparer = new PseudoComparer();
            Assert.AreEqual(1, actualPseudoObjectList.Count);
            Assert.IsNotNull(actualPseudoObject);
            Assert.IsNotNull(actualPseudoObject.Source1);
            Assert.IsNotNull(actualPseudoObject.Source2);
            Assert.IsNotNull(actualPseudoObject.Source3);
            Assert.IsTrue(comparer.Equals(expectedPseudoObject, actualPseudoObject));

            // Delete pseudo object from database
            dbService.DeleteFromDatabase(actualPseudoObject);

            // Read pseudo object from database. No objects should be found
            actualPseudoObjectList = dbService.ReadListFromDatabase<PseudoClass>();
            Assert.AreEqual(0, actualPseudoObjectList.Count);
        }

    }
}
