using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SafeEats.Models
{
    public class RecipeContext : ApplicationDbContext
    {
        //public virtual IDbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
    }
}