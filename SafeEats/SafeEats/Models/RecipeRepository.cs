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
            Recipe my_recipe = new Recipe { RecipeName = recipeName, RecipeCreator = owner };
            context.Recipes.Add(my_recipe);
            context.SaveChanges(); // This saves something to the Database

            return my_recipe;
        }

        public List<Recipe> GetAllRecipes()
        {
            var query = from l in context.Recipes select l;
            return query.SelectMany(Recipe => recipe.Lists).ToList();
        }
    }
}