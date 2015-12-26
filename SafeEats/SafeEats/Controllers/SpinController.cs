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

        // GET: Recipe List
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
            // took this out to mess around with the view
            //ViewBag.Title = my_recipe.RecipeName; 
            ViewBag.CurrentBoardId = my_recipe.RecipeId;
            


            List<Recipe> recipe_lists = repository.GetRecipes(my_recipe.RecipeCreator);

            return View(recipe_lists);
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRecipe(FormCollection form)
        {
            string recipe_name = form.Get("recipe-name");
            string recipe_id = form.Get("recipe-id");

            //dont think i need this

            //Recipe current_recipe = repository.GetRecipeById(int.Parse(board_id));
            //if (current_board != null)
            //{
            //    repository.AddList(current_board.BoardId, new BrelloList { Title = list_name });
            //}

            return RedirectToAction("Index");

        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recipe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
