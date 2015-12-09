using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SafeEats.Models
{
    public class RecipeRepository
    {
        private RecipeContext context;

        public RecipeRepository()
        {
            context = new RecipeContext();
        }
        public RecipeRepository(RecipeContext _context)
        {
            context = _context;
        }

        // void or bool or Recipe
        

        

        

        

        public List<Recipe> GetRecipes(ApplicationUser user1)
        {
            var query = from r in context.Recipes where r.RecipeCreator == user1 select r;
            return query.ToList<Recipe>(); // Same as query.ToList();
        }

        

        public int GetRecipeCount()
        {
            var query = from r in context.Recipes select r;
            return query.Count();
        }

        public Recipe CreateRecipe(string recipeName, ApplicationUser owner)
        {
            Recipe my_recipe = new Recipe { RecipeName = recipeName, RecipeCreator = owner };
            context.Recipes.Add(my_recipe);
            context.SaveChanges(); // This saves something to the Database

            return my_recipe;
        }

        public object GetAllRecipes()
        {
            var query = from r in context.Recipes select r;
            return query.SelectMany(recipe => recipe.RecipeName).ToList();
        }
    }
}