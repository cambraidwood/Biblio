using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblio;
using Biblio.Business.Controllers;
using Biblio.Business.Models;

namespace Biblio.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index();

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Show()
        {
            // Arrange
            HomeController controller = new HomeController();
            ShowRequestModel request = new ShowRequestModel() { RawInput = "test test text here", Duplicate = "test", Palindrome = "", ConsonantCount = "11", SpecialCharacterCount = "0", VowelCount = "5", WordCount = "4" };

            // Act
            ViewResult result = controller.Show(request);

            // Assert
            Assert.IsNotNull(result);

            if (result != null)
            {
                
                Assert.IsInstanceOfType(result.Model, typeof(ResponseModel));
                ResponseModel model = result.Model as ResponseModel;
                if (model != null)
                {
                    Assert.AreEqual(request.RawInput, model.RawInput);
                    Assert.AreEqual(model.Duplicate, "test");
                    Assert.IsTrue(model.CanSave);
                    // test before / after model properties
                }
            }
        }

        [TestMethod]
        public void Show_Cant_Save()
        {
            // Arrange
            HomeController controller = new HomeController();
            ShowRequestModel request = new ShowRequestModel() { RawInput = "one two three four", Duplicate = "", Palindrome = "", ConsonantCount = "8", SpecialCharacterCount = "0", VowelCount = "7", WordCount = "4" };

            // Act
            ViewResult result = controller.Show(request);

            // Assert
            Assert.IsNotNull(result);

            if (result != null)
            {

                Assert.IsInstanceOfType(result.Model, typeof(ResponseModel));
                ResponseModel model = result.Model as ResponseModel;
                if (model != null)
                {
                    Assert.IsFalse(model.CanSave);
                }
            }
        }

        [TestMethod]
        public void Save()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            SaveRequestModel request = new SaveRequestModel();
            ViewResult result = controller.Save(request);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
