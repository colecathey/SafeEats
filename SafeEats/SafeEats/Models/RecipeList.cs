using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SafeEats.Models
{
    public class RecipeList
    {
        [Key]
        public int RecipeListId { get; set; }
        public string Title { get; set; }
        public List<Recipe> Recipes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}