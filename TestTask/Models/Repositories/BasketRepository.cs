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

        public IQueryable<Basket> GetAll()
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

        public void Update(Basket basket)
        {
            db.Entry(basket).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Basket basket = db.Baskets.Find(id);
            if (basket != null)
            {
                db.Baskets.Remove(basket);
            }
        }
    }
}