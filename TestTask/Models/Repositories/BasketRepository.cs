using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestTask.Models.Repositories.Interfaces;

namespace TestTask.Models.Repositories
{
    public class BasketRepository : IRepository<Basket>
    {
        private ProductContext db;

        public IEnumerable<Basket> GetAll()
        {
            return db.Baskets;
        }

        public BasketRepository(ProductContext context)
        {
            this.db = context;
        }
        public Basket Get(int id)
        {
            return db.Baskets.Find(id);
        }

        public void Create(Basket basket)
        {
            db.Baskets.Add(basket);
        }

        public void Update(Basket updatedBasket)
        {
            var basket = db.Baskets.Find(updatedBasket.Id);
            if (basket == null) return;
            basket.Products.Clear();
            basket.Name = updatedBasket.Name;
            basket.Products = updatedBasket.Products;
        }

        public void Delete(int id)
        {
            var basket = db.Baskets.Find(id);
            if (basket != null)
            {
                db.Baskets.Remove(basket);
            }
        }
    }
}