using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafeEats.Models;
using Moq;
using System.Web;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace SafeEats.Tests.models
{
    [TestClass]
    public class RecipeRepositoryTests
    {

        private Mock<RecipeContext> mock_context;
        private Mock<DbSet<Recipe>> mock_recipes;
        private List<Recipe> my_list;
        private ApplicationUser owner, user1, user2;

        private void ConnectMocksToDataSource()
        {
            // This setups the Mocks and connects to the Data Source (my_list in this case)
            var data = my_list.AsQueryable();

            mock_recipes.As<IQueryable<Recipe>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_recipes.As<IQueryable<Recipe>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_recipes.As<IQueryable<Recipe>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_recipes.As<IQueryable<Recipe>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_context.Setup(m => m.Recipes).Returns(mock_recipes.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<RecipeContext>();
            mock_recipes = new Mock<DbSet<Recipe>>();
            my_list = new List<Recipe>();
            owner = new ApplicationUser();
            user1 = new ApplicationUser();
            user2 = new ApplicationUser();

        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_recipes = null;
            my_list = null;
        }

        [TestMethod]
        public void RecipeRepositoryEnsureICanCreateInstance()
        {
            RecipeRepository recipe = new RecipeRepository(mock_context.Object);
            Assert.IsNotNull(recipe);
        }

        

        

        [TestMethod]
        public void RecipeRepositoryEnsureICanGetAllRecipes()
        {
            /* Begin Arrange */

            var recipe_lists = new List<RecipeList>
            {
                new RecipeList { Title = "My List", RecipeListId = 1}
            };

            my_list.Add(new Recipe { RecipeName = "Soup", RecipeCreator = user1, RecipeId = 1});
            my_list.Add(new Recipe { RecipeName = "Meatloaf", RecipeCreator = user2, RecipeId = 2});
            ConnectMocksToDataSource();
            RecipeRepository recipe_repo = new RecipeRepository(mock_context.Object);
            /* End Arrange */

            /* Begin Act */
            int expected = 2;
            int actual = recipe_repo.GetAllRecipes().Count;
            /* End Act */

            /* Begin Assert */
            Assert.AreEqual(expected, actual);
            /* End Assert */
        }

        [TestMethod]
        public void RecipeRepositoryEnsureThereAreZeroRecipes()
        {
            /* Begin Arrange */
            my_list.Add(new Recipe { RecipeName = "Soup", RecipeCreator = user1 });
            my_list.Add(new Recipe { RecipeName = "Meatloaf", RecipeCreator = user2 });

            ConnectMocksToDataSource();
            RecipeRepository recipe_repo = new RecipeRepository(mock_context.Object);
            /* End Arrange */


            int expected = 0;
            int actual = recipe_repo.GetRecipeCount();
            Assert.AreEqual(expected, actual);

        }

        
        
        [TestMethod]
        public void RecipeRepositoryEnsureRecipeRepoHasZeroRecipes()
        {
            /* Begin Arrange */
            my_list.Add(new Recipe { RecipeName = "Soup", RecipeCreator = user1, RecipeId = 1 });

            ConnectMocksToDataSource();
            /* Begin Act */
            RecipeRepository recipe_repo = new RecipeRepository(mock_context.Object);
            /* Begin Assert */
            int expected = 0;
            Assert.AreEqual(expected, recipe_repo.GetAllRecipes().Count());
        }

        [TestMethod]
        public void RecipeRepositoryCanGetRecipe()
        {
            /* Begin Arrange */
            my_list.Add(new Recipe { RecipeName = "Soup", RecipeCreator = user1 });
            my_list.Add(new Recipe { RecipeName = "Meatloaf", RecipeCreator = user2 });
            ConnectMocksToDataSource();

            /* Leveraging the CreateBoard Method:
                 mock_boards.Setup(m => m.Add(It.IsAny<Board>())).Callback((Board b) => my_list.Add(b));
                 Board added_board = board_repo.CreateBoard(title, owner);
            */

            RecipeRepository recipe_repository = new RecipeRepository(mock_context.Object);
            /* Begin Act */
            List<Recipe> user_recipes = recipe_repository.GetRecipes(user1);
            /* Begin Assert */
            Assert.AreEqual(1, user_recipes.Count());
            Assert.AreEqual("Soup", user_recipes.First().RecipeName);
        }

        [TestMethod]
        public void RecipeRepositoryCanGetRecipeCount()
        {
            /* Begin Arrange */

            var data = my_list.AsQueryable();

            //mock_boards.Object.Add(new Board { Title = "My Awesome Board", Owner = new ApplicationUser() });

            //var data = mock_boards.Object.AsQueryable();
            mock_recipes.As<IQueryable<Recipe>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_recipes.As<IQueryable<Recipe>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_recipes.As<IQueryable<Recipe>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_recipes.As<IQueryable<Recipe>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_context.Setup(m => m.Recipes).Returns(mock_recipes.Object);
            //mock_context.Object.SaveChanges(); // This saves something to the Database
            RecipeRepository recipe_repository = new RecipeRepository(mock_context.Object);
            /* End Arrange */

            /* Begin Act */
            int actual = recipe_repository.GetRecipeCount();
            /* End Act */

            /* Begin Assert */
            Assert.AreEqual(0, actual);
            /* End Assert */

            /* Begin Act */
            my_list.Add(new Recipe { RecipeName = "Soup" });
            mock_recipes.As<IQueryable<Recipe>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            /* End Act */

            /* Begin Assert */
            Assert.AreEqual(1, recipe_repository.GetRecipeCount());
            /* End Assert */
        }

        

        
    }
}
