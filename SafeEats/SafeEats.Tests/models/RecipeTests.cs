using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafeEats.Models;

namespace SafeEats.Tests.models
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void CardEnsureICanCreateRecipeInstance()
        {
            Recipe recipe = new Recipe();
            Assert.IsNotNull(recipe);
        }

        [TestMethod]
        public void RecipeEnsureRecipePropertiesWork()
        {
            var tom = new ApplicationUser();
            

            // Object Initializer syntax
            Recipe recipe = new Recipe { RecipeName = "Soup", RecipeId = 4, RecipeCreator = tom,
                RecipeDescription = "recipe", RecipeDirections = "stir"};

            Assert.AreEqual("Soup", recipe.RecipeName);
            Assert.AreEqual(4, recipe.RecipeId);
            Assert.AreEqual(tom, recipe.RecipeCreator);
            Assert.AreEqual("stir", recipe.RecipeDirections);
            
        }
    }
}
