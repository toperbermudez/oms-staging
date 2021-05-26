using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Service.Services
{
    //this is just an example service that's why this doesn't have any repository reference
    public class TestService : ITestService
    {
        public TestService()
        {

        }

        public string GetName()
        {
            return "Francis";
        }
    }
}
