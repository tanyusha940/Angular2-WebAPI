using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestTask.Models;
using TestTask.ViewModels;

namespace TestTask.Controllers
{
    public class ProductsController : BaseAPIController
    {
        private UnitOfWork unitOfWork;

        public ProductsController()
        {
            unitOfWork = new UnitOfWork();
        }

        public HttpResponseMessage GetProducts()
        {
            return ToJson(unitOfWork.Product.GetAll());
        }

        [ResponseType(typeof(Product))]
        public HttpResponseMessage GetProduct(int id)
        {
            Product product = unitOfWork.Product.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return ToJson(product);
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public HttpResponseMessage CreateProduct([FromBody] CreateProductViewModel product)
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
            var result = unitOfWork.Save();
            return ToJson(result);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public HttpResponseMessage EditProduct([FromBody]EditProductViewModel product)
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
            var result = unitOfWork.Save();
            return ToJson(result);
        }

        [HttpDelete]
        [ResponseType(typeof(Product))]
        public HttpResponseMessage DeleteProduct(int id)
        {
            unitOfWork.Product.Delete(id);
            var result = unitOfWork.Save();
            return ToJson(result);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}