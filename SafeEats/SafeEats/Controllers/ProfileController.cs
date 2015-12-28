using SafeEats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Http;

namespace SafeEats.Controllers
{
    public class ProfileController : Controller
    {

        private RecipeRepository repository;

        public ProfileController()
        {
            repository = new RecipeRepository();
        }

        public ProfileController(RecipeRepository _repo)
        {
            repository = _repo;
        }

        // GET: Recipe List
        [System.Web.Mvc.Authorize]
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
            ViewBag.CurrentRecipeId = my_recipe.RecipeId;



            List<Recipe> recipe_lists = repository.GetRecipes(my_recipe.RecipeCreator);

            return View(recipe_lists);
        }
        // GET: api/Profile
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Profile/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Profile
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Profile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Profile/5
        public void Delete(int id)
        {
        }
    }
}
