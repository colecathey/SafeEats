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

        // DbContext is now ApplicationDbContext which gives use access to the
        // table containing the users.
        public IDbSet<ApplicationUser> Users { get { return context.Users; } }

        public RecipeRepository()
        {
            context = new RecipeContext();
        }
        public RecipeRepository(RecipeContext _context)
        {
            context = _context;
        }

        // void or bool or Recipe

        // get recipes associated with user
        public List<Recipe> GetRecipes(ApplicationUser users)
        {

            var query = from r in context.Recipes where r.RecipeCreator.Id == users.Id select r;

            return query.ToList<Recipe>();


        }

        // get count of recipes
        public int GetRecipeCount()
        {
            var query = from r in context.Recipes select r;
            return query.Count();
        }

        // create a recipe
        public Recipe CreateRecipe(string recipeName, ApplicationUser owner)
        {
            Recipe my_recipe = new Recipe { RecipeName = recipeName, RecipeCreator = owner, RecipeIngredients = new List<Ingredient>() };
            context.Recipes.Add(my_recipe);
            context.SaveChanges(); // This saves something to the Database

            return my_recipe;
        }

        // get all the recipes and return them as a list
        public object GetAllRecipes()
        {
            var query = from r in context.Recipes select r;
            return query.SelectMany(recipe => recipe.RecipeName).ToList();
        }

        public void RemoveRecipe(string recipeName)
        {
            Recipe my_recipe = new Recipe { RecipeName = recipeName };
            context.Recipes.Remove(my_recipe);
            context.SaveChanges();

        }
    }
}

        
