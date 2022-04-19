using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.DBEntities;

namespace Web.Controllers.UnitTests
{
    [TestClass()]
    public class CategoryControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //Arrange
            var expected = GetIndexTestData();

            // Act
            var controller = new CategoryController();
            var actual = (List<Category>)(controller.Index() as ViewResult)?.Model;

            // Assert
            Assert.AreEqual(expected, JsonConvert.SerializeObject(actual));
        }

        private string GetIndexTestData()
        {
            List<Category> result = new List<Category>()
            {
                new Category(){ CategoryId = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales",},
                new Category(){ CategoryId = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings",},
                new Category(){ CategoryId = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads",},
                new Category(){ CategoryId = 4, CategoryName = "Dairy Products", Description = "Cheeses",},
                new Category(){ CategoryId = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal",},
                new Category(){ CategoryId = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats",},
                new Category(){ CategoryId = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd",},
                new Category(){ CategoryId = 8, CategoryName = "Seafood", Description = "Seaweed and fish",},
            };

            return JsonConvert.SerializeObject(result);
        }
    }
}