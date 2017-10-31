using System.Collections.Generic;
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

        public IEnumerable<Basket> GetBaskets()
        {
            return unitOfWork.Basket.GetAll();
        }

        [ResponseType(typeof(Basket))]
        public IHttpActionResult GetBasket(int id)
        {
            Basket basket = unitOfWork.Basket.Get(id);

            if (basket == null)
            {
                return NotFound();
            }

            return Ok(basket);
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult CreateBasket([FromBody]CreateBasketViewModel basket)
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

            unitOfWork.Save();

            return Ok();
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult EditBasket([FromBody]EditBasketViewModel basket)
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

            unitOfWork.Save();

            return Ok();
        }

        [ResponseType(typeof(Basket))]
        public void DeleteBasket(int id)
        {
            unitOfWork.Basket.Delete(id);
            unitOfWork.Save();
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}