using HelloWorld.Web.Models;
using HelloWorld.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using StructureMap;

namespace HelloWorld.Web.Controllers
{
    public class HelloWorldController : ApiController
    {
        [HttpGet]
        [Route("api/greeting/{id}")]
        public HelloWorldModel Get(int id)
        {
            var bll = ObjectFactory.GetInstance<IHelloWorldRepository>();
            var item = new HelloWorldModel();

            item.Id = id;
            item.Greeting = bll.Get(id);
     
            return item;
        }
    }
}