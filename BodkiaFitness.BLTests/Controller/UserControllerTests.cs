using Microsoft.VisualStudio.TestTools.UnitTesting;
using BodkiaFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodkiaFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange обьявления
            var userName = Guid.NewGuid().ToString();
            var gender = "гендер";
            var weight = 90;
            var height = 180;
            var birth = DateTime.Now.AddYears(-18);
            var controller = new UserController(userName);

            //Act действия
            controller.SetNewUserData(gender, birth, weight, height);
            var controller2 = new UserController(userName); //читаем уже созданого

            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(birth, controller2.CurrentUser.Birth);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange обьявления
            var userName = Guid.NewGuid().ToString();

            //Act действия
            var controller = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}