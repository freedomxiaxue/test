using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tcpjw3.oa;
using tcpjw3.oa.Controllers;

namespace tcpjw3.oaTest.Controllers {
    [TestClass]
    public class HomeControllerTest {
        [TestMethod]
        public void Index() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Welcome to DevExpress Extensions for ASP.NET MVC!", result.ViewBag.Message);
        }
    }
}
