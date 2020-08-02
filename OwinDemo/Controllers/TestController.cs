using System.Collections.Generic;
using System.Web.Http;

namespace OwinDemo.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> GetTest()
        {
            return new string[] { "One", "Two", "Three" };
        }
    }
}
