using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TestTask.Models;
using TestTask.ViewModels;

namespace TestTask.Controllers
{
    public class ProductsController : ApiController
    {
        private UnitOfWork unitOfWork;

        public ProductsController()
        {
            unitOfWork = new UnitOfWork();
        }

        public IEnumerable<Product> GetProducts()
        {
            return unitOfWork.Product.GetAll();
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = unitOfWork.Product.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult CreateProduct([FromBody] CreateProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unitOfWork.Product.Create(new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            });
            unitOfWork.Save();
            return Ok();
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult EditProduct([FromBody]EditProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unitOfWork.Product.Update(new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            });
            unitOfWork.Save();
            return Ok();
        }

        [HttpDelete]
        [ResponseType(typeof(Product))]
        public void DeleteProduct(int id)
        {
            unitOfWork.Product.Delete(id);
            unitOfWork.Save();
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}