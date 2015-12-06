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
            return GetAllLists().Count;
        }

        public List<RecipeList> GetAllLists()
        {
            var query = from r in context.Recipes select r;
            return query.SelectMany(recipe => recipe.Lists).ToList();
        }

        public List<RecipeList> GetAllLists(int _recipe_id)
        {
            var query = from r in context.Recipes where r.RecipeId == _recipe_id select r.Lists;
            return query.Single<List<RecipeList>>();
        }

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

        //public List<Recipe> GetAllRecipes()
        //{
        //    var query = from r in context.Recipes select r;
        //    return query.SelectMany(Recipe => recipe.Lists).ToList();
        //}
    }
}