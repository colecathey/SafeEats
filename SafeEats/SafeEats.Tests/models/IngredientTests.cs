using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafeEats.Models;

namespace SafeEats.Tests.models
{
    /// <summary>
    /// Summary description for IngredientTests
    /// </summary>
    [TestClass]
    public class IngredientTests
    {
        [TestMethod]
        public void CardEnsureICanCreateInstance()
        {
            Ingredient ingredient = new Ingredient();
            Assert.IsNotNull(ingredient);
        }

        [TestMethod]
        public void CardEnsurePropertiesWork()
        {
            
            // Object Initializer syntax
            Ingredient ingredient = new Ingredient { IngredientName = "Carrot", IngredientId = 4};
            
            Assert.AreEqual("Carrot", ingredient.IngredientName);
            Assert.AreEqual(4, ingredient.IngredientId);
            
        }
        
    }
}
