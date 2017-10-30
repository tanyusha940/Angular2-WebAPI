using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class Initializer : CreateDatabaseIfNotExists<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            Product product_1 = new Product {Name = "Mango", Description = "Fruit", Price = 15.8f};
            Product product_2 = new Product { Name = "Apple", Description = "Fruit", Price = 15.8f };
            Product product_3 = new Product { Name = "Tomato", Description = "Vegetables", Price = 15.8f };
            db.Products.AddRange(new List<Product> {product_1, product_2,product_3});

            Basket basket_1 = new Basket{Name = "BasketWithFrut"};
            basket_1.Products.Add(product_1);
            basket_1.Products.Add(product_2);
            Basket basket_2 = new Basket { Name = "BasketWithVegetables" };
            basket_2.Products.Add(product_3);
            db.Baskets.AddRange(new List<Basket> {basket_1, basket_2});
            db.SaveChanges();
        }

    }
}