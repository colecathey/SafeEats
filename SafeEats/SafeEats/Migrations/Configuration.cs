namespace SafeEats.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SafeEats.Models.RecipeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SafeEats.Models.RecipeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Recipes.AddOrUpdate(r => r.RecipeName,
                new Models.Recipe { RecipeName = "Meatloaf" },
                new Models.Recipe { RecipeName = "Chicken al'orange" },
                new Models.Recipe { RecipeName = "A single carrot" },
                new Models.Recipe { RecipeName = "Porridge" },
                new Models.Recipe { RecipeName = "Trout Souflee" });
        }
    }
}
