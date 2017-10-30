using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class BasketsController : ApiController
    {
        private ProductContext db = new ProductContext();

        public IEnumerable<Basket> GetBaskets()
        {
            return db.Baskets;
        }
        public Basket GetBastBasket(int id)
        {
            Basket basket = db.Baskets.Find(id);
            return basket;
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public void CreateBasket([FromBody]Basket basket)
        {
            db.Baskets.Add(basket);
            db.SaveChanges();
        }

        [HttpPut]
        [ResponseType(typeof(Basket))]
        public void EditBasket(int id, [FromBody]Basket basket)
        {
            if (id == basket.Id)
            {
                db.Entry(basket).State = EntityState.Modified;

                db.SaveChanges();
            }
        }


        [ResponseType(typeof(Basket))]
        public void DeleteBasket(int id)
        {
            Basket basket = db.Baskets.Find(id);
            if (basket == null)
            {
                NotFound();
            }

            db.Baskets.Remove(basket);
            db.SaveChanges();
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}