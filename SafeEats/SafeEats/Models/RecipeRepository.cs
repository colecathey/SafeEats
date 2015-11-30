using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public bool AddRecipe(int _recipe_id, Recipe _list)
        {
            var query = from r in context.Recipes where r.RecipeId == _recipe_id select r;
            Recipe found_recipe = null;
            bool result = true;
            try
            {
                found_recipe = query.Single<Recipe>();
                found_recipe.Recipe.Add(_list);
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                result = false;
            }
            catch (ArgumentNullException)
            {
                result = false;
            }
            return result;
        }
    }
}