namespace coffeestore_online.Migrations
{
    using coffeestore_online.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<coffeestore_online.Models.CoffeeStoreDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(coffeestore_online.Models.CoffeeStoreDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            IList<TypeOfProduct> typeOfProducts = new List<TypeOfProduct>();

            TypeOfProduct type1 = new TypeOfProduct();
            type1.TypeOfProductId = "1";
            type1.TypeOfProductName = "Tra dao";
            
            TypeOfProduct type2 = new TypeOfProduct();
            type2.TypeOfProductId = "2";
            type2.TypeOfProductName = "Tra bi dao";

            typeOfProducts.Add(type1);
            typeOfProducts.Add(type2);


            IList<Product> products = new List<Product>();
            Product pd1 = new Product();
            pd1.ProductId = "Pr1";
            pd1.ProductName = "Ice Coffee";
            pd1.ProductPrice = 52000;
            pd1.ProductDescription = "abc";
            pd1.ProductFileNameImg = "abc";
            pd1.ProductStatus = true;
            pd1.TypeOfProductId = "1";



            products.Add(pd1);

            context.TypeOfProducts.AddRange(typeOfProducts);
            context.Products.AddRange(products);
            base.Seed(context);
        }
    }
}
