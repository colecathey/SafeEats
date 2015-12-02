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
        public bool AddRecipe(int _recipe_id, RecipeList _list)
        {
            var query = from r in context.Recipes where r.RecipeId == _recipe_id select r;
            Recipe found_recipe = null;
            bool result = true;
            try
            {
                found_recipe = query.Single<Recipe>();
                found_recipe.Lists.Add(_list);
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

        public bool AddList(int _recipe_id, RecipeList _list)
        {
            var query = from r in context.Recipes where r.RecipeId == _recipe_id select r;
            Recipe found_recipe = null;
            bool result = true;
            try
            {
                found_recipe = query.Single<Recipe>();
                found_recipe.Lists.Add(_list);
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

        public int GetListCount()
        {
            throw new NotImplementedException();
        }

        public object GetAllLists()
        {
            throw new NotImplementedException();
        }

        public object GetAllLists(int v)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> GetRecipes(ApplicationUser user1)
        {
            throw new NotImplementedException();
        }

        public int GetRecipeCount()
        {
            throw new NotImplementedException();
        }

        public Recipe CreateRecipe(string recipeName, ApplicationUser owner)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> GetAllRecipes()
        {
            throw new NotImplementedException();
        }
    }
}