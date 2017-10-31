using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestTask.Models;
using TestTask.ViewModels;

namespace TestTask.Controllers
{
    public class BasketsController : BaseAPIController
    {
        private UnitOfWork unitOfWork;

        public BasketsController()
        {
            unitOfWork = new UnitOfWork();
        }

        public HttpResponseMessage GetBaskets()
        {
            return ToJson(unitOfWork.Basket.GetAll());
        }

        [ResponseType(typeof(Basket))]
        public HttpResponseMessage GetBasket(int id)
        {
            Basket basket = unitOfWork.Basket.Get(id);

            if (basket == null)
            {
                return NotFound();
            }

            return ToJson(basket);
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public HttpResponseMessage CreateBasket([FromBody]CreateBasketViewModel basket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.Basket.Create(new Basket
            {
                Name = basket.Name,
                Products = basket.Products
            });

            var result = unitOfWork.Save();

            return ToJson(result);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public HttpResponseMessage EditBasket([FromBody]EditBasketViewModel basket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.Basket.Update(new Basket
            {
                Id = basket.Id,
                Name = basket.Name,
                Products = basket.Products
            });

            var result = unitOfWork.Save();

            return ToJson(result);
        }

        [ResponseType(typeof(Basket))]
        public HttpResponseMessage DeleteBasket(int id)
        {
            unitOfWork.Basket.Delete(id);
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