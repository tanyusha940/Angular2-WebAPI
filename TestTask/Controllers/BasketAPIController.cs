using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class BasketAPIController : BaseAPIController
    {
        public HttpResponseMessage Get()
        {
            return ToJsonBasket(basketContext.Baskets.AsEnumerable());
        }

        public HttpResponseMessage Post([FromBody]Basket value)
        {
            basketContext.Baskets.Add(value);
            return ToJsonBasket(basketContext.SaveChanges());
        }

        public HttpResponseMessage Put(int id, [FromBody]Basket value)
        {
            basketContext.Entry(value).State = EntityState.Modified;
            return ToJsonBasket(basketContext.SaveChanges());
        }
        public HttpResponseMessage Delete(int id)
        {
            basketContext.Baskets.Remove(basketContext.Baskets.FirstOrDefault(x => x.Id == id));
            return ToJsonBasket(basketContext.SaveChanges());
        }
    }

}
