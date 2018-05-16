namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication2.Models.AutosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication2.Models.AutosContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var audi = new Models.Brand() { Name = "AUDI", Country = "Germany" };
            var fiat = new Models.Brand() { Name = "FIAT", Country = "Italy" };
            context.Brands.Add(audi);
            context.Brands.Add(fiat);
            context.SaveChanges();

            context.Cars.Add(new Models.Car() { Name = "A3", Price = 34567, BrandId = audi.Id });
            context.Cars.Add(new Models.Car() { Name = "A4", Price = 45678, BrandId = audi.Id });
            context.Cars.Add(new Models.Car() { Name = "500", Price = 12345, BrandId = fiat.Id });
            context.Cars.Add(new Models.Car() { Name = "Punto", Price = 23456, BrandId = fiat.Id });

            context.SaveChanges();
        }
    }
}
