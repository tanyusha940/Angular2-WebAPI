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
    public class ProductsController : ApiController
    {
        private ProductContext db = new ProductContext();

        public IEnumerable<Product> GetProducts()
        {
            return db.Products;
        }


        public Product GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            return product;
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public void CreateProduct([FromBody]Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        [HttpPut]
        [ResponseType(typeof(Product))]
        public void EditBasket(int id, [FromBody]Product product)
        {
            if (id == product.Id)
            {
                db.Entry(product).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        [HttpDelete]
        [ResponseType(typeof(Product))]
        public void DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                NotFound();
            }

            db.Products.Remove(product);
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