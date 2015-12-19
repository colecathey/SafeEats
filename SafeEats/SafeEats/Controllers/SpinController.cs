using SafeEats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace SafeEats.Controllers
{
    public class SpinController : Controller
    {

        private RecipeRepository repository;

        public SpinController()
        {
            repository = new RecipeRepository();
        }

        public SpinController(RecipeRepository _repo)
        {
            repository = _repo;
        }

        // GET: Board
        [Authorize]
        public ActionResult Index()
        {
            
            string user_id = User.Identity.GetUserId();
            ApplicationUser me = repository.Users.FirstOrDefault(u => u.Id == user_id);

            List<Recipe> recipes = repository.GetRecipes(me);
            Recipe my_recipe = null;
            if (recipes.Count() == 0)
            {
                my_recipe = repository.CreateRecipe("Test Recipe", me);
            }
            else
            {
                my_recipe = recipes.First();
            }
            ViewBag.Title = my_recipe.RecipeName;
            ViewBag.CurrentBoardId = my_recipe.RecipeId;


            List<Recipe> recipe_lists = repository.GetRecipes(my_recipe.RecipeCreator);

            return View(recipe_lists);
        }
    }
}
