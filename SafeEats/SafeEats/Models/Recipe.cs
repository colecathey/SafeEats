using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeEats.Models
{
    public class Recipe
    {
        public string RecipeName { get; set; }
        public int RecipeId { get; set; }
        public string RecipeDescription { get; set; }
        public List<string> RecipeIngredients { get; set; }
        public ApplicationUser RecipeCreator { get; set; }
        public bool RecipeType { get; set; }
        public string RecipeRecipe { get; set; }
        public object Recipes { get; internal set; }
    }
}