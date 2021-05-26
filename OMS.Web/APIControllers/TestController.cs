using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OMS.Web.APIControllers
{
    public class TestController : ApiController
    {
        private readonly ITestService _service;
        public TestController(ITestService service)
        {
            _service = service;
        }
        public string Get()
        {
            return _service.GetName();
        }
    }
}
