using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeEats.Models
{
    public class Ingredient
    {
        public string IngredientName { get; set; }
        public int IngredientId { get; set; }
        public RecipeType IngredientType { get; set; }
    }
}