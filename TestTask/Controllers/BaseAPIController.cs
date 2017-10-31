using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace TestTask.Controllers
{
    public class BaseAPIController : ApiController
    {
        protected HttpResponseMessage ToJson(dynamic obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }

        protected HttpResponseMessage BadRequest(dynamic obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.BadRequest);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }

        protected HttpResponseMessage NotFound()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }
    }
}
