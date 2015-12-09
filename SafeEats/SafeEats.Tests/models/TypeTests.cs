using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafeEats.Models;

namespace SafeEats.Tests.models
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void CardEnsureICanCreateInstance()
        {
            Models.RecipeType recipeType = new Models.RecipeType();
            Assert.IsNotNull(recipeType);
        }

        [TestMethod]
        public void CardEnsurePropertiesWork()
        {

            // Object Initializer syntax
            Models.RecipeType recipeType = new Models.RecipeType { TypeName = "Veg", TypeId = 4, TypeType = 1 };

            Assert.AreEqual("Veg", recipeType.TypeName);
            Assert.AreEqual(4, recipeType.TypeId);
            Assert.AreEqual(1, recipeType.TypeType);
        }
    }
}
