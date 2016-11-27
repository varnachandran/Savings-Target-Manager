using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavingsTarget.Controllers;
using SavingsTarget.Models;

namespace SavingsTarget.Tests.Controllers
{
    [TestClass]
    public class WishListTest
    {


        [TestMethod]
        public void Create()
        {
            WishlistItemsController controller = new WishlistItemsController();
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        

        
    }
}
