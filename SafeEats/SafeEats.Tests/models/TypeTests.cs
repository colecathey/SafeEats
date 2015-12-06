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
            Type recipeType = new Type();
            Assert.IsNotNull(recipeType);
        }

        [TestMethod]
        public void CardEnsurePropertiesWork()
        {

            // Object Initializer syntax
            Type recipeType = new Models.Type { TypeName = "Veg", TypeId = 4, TypeType = 1 };

            Assert.AreEqual("Veg", recipeType.TypeName);
            Assert.AreEqual(4, recipeType.TypeId);
            Assert.AreEqual(1, recipeType.TypeType);
        }
    }
}
