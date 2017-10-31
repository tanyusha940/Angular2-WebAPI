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
    public class ProductAPIController : BaseAPIController
    {
        public HttpResponseMessage Get()
        {
            return ToJsonProduct(productContext.Products.AsEnumerable());
        }

        public HttpResponseMessage Post([FromBody]Product value)
        {
            productContext.Products.Add(value);
            return ToJsonProduct(productContext.SaveChanges());
        }

        public HttpResponseMessage Put(int id, [FromBody]Product value)
        {
            productContext.Entry(value).State = EntityState.Modified;
            return ToJsonProduct(productContext.SaveChanges());
        }
        public HttpResponseMessage Delete(int id)
        {
            productContext.Products.Remove(productContext.Products.FirstOrDefault(x => x.Id == id));
            return ToJsonProduct(productContext.SaveChanges());
        }
    }
}
