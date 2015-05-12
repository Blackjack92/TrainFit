using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainFit.Models;

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
            user.SetName(name);
            Assert.AreEqual(name, user.Name);
        }
    }
}
