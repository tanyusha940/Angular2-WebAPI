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
        private UnitOfWork unitOfWork;

        public ProductsController()
        {
            unitOfWork = new UnitOfWork();
        }

        public IQueryable<Product> GetBaskets()
        {
            return unitOfWork.Product.GetAll();
        }

        public Product GetBasket(int id)
        {
            Product basket = unitOfWork.Product.Get(id);
            return basket;
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public void CreateProduct([FromBody]Product product)
        {
            unitOfWork.Product.Create(product);
        }

        [HttpPut]
        [ResponseType(typeof(Product))]
        public void EditBasket(int id, [FromBody]Product product)
        {
            unitOfWork.Product.Update(product);
        }

        [HttpDelete]
        [ResponseType(typeof(Product))]
        public void DeleteProduct(int id)
        {
            unitOfWork.Product.Delete(id);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}