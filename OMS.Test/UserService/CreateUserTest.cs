using Microsoft.VisualStudio.TestTools.UnitTesting;
using OMS.Core.Interface.Services;
using OMS.Repository;
using OMS.Repository.Repositories;

namespace OMS.Test.UserService
{
    /// <summary>
    /// Summary description for CreateUserTest
    /// </summary>
    [TestClass]
    public class CreateUserTest
    {
        private readonly IUserService userService;
        public CreateUserTest()
        {
            var context = new OMSContext();
            userService = new OMS.Service.Services.UserService(
                new CRUDRepository<OMS.Core.Entities.User>(context),new UserQueryRepository(context));
        }

        [TestMethod]
        public void CreateUser_Success()
        {

        }
    }
}
