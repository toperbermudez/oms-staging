using OMS.Core.DTO;
using OMS.Core.Interface.Services;
using System.Web.Mvc;

namespace OMS.Web.Controllers
{
    public partial class AdminController : BaseController
    {

        private readonly ITestService _service;
        private readonly IProductService _productservice;
        private readonly IVariantService _variantService;
        private readonly ICategoryService _categoryService;
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        public AdminController(IUserService userService, IRoleService roleService, ITestService service, IProductService productservice, IVariantService variantService, ICategoryService categoryService, IAccountService accountService)
        {
            _service = service;
            _productservice = productservice;
            _variantService = variantService;
            _categoryService = categoryService;
            _accountService = accountService;
            _roleService = roleService;
            _userService = userService;
        }

        // GET: Admin
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Variants()
        {
            return View(_variantService.ListVariants());
        }

        public virtual ActionResult CreateVariants()
        {
            return View();
        }

        public virtual ActionResult Products()
        {




            return View(_productservice.ListProducts());

        }

        public virtual ActionResult CreateProducts()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult CreateProducts(Product product)
        {
            // product.CreatedBy = Request.Cookies["Username"].Value;
            Response<Product> response = _productservice.CreateProduct(product);
            if (response.Success.Equals(true))
            {
                ViewBag.Message = "Successfully Added";
            }
            else
            {
                ViewBag.Message = response.ErrorMessage;
            }
            return View();

        }

        [HttpGet]
        public virtual ActionResult ListCategory()
        {
            var start = Request.Params["start"];
            var length = Request.Params["length"];
            var draw = Request.Params["draw"];
            var result = _categoryService.ListCategories(int.Parse(length), int.Parse(start));
            result.draw = int.Parse(draw); 
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult CreateCategory()
        {

            var varlist = _variantService.ListVariants();
            SelectList list = new SelectList(varlist, "ID", "Name", 1);
            ViewBag.variantlist = list;


            return View();



        }

        [HttpPost]
        public virtual JsonResult CreateCategory(Category category)
        {
            category.CreatedBy = appUser.Username;
            category.UpdatedBy = appUser.Username;
            Response<Category> response;
            if(category.ID == 0)
            {
                response = _categoryService.CreateCategory(category);
            }
            else
            {
                response = _categoryService.UpdateCategory(category);
            }
            return Json(response);
        }





        [HttpGet]
        public virtual JsonResult GetCategory(int id)
        {
            return Json(_categoryService.GetCategoryByID(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual JsonResult DeleteCategory(int id)
        {
            return Json(_categoryService.RemoveCategory(id), JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult Employee()
        {

            return View(_accountService.ListAccounts());

        }

        public virtual ActionResult CreateEmployee()
        {

            return View();

        }

        [HttpPost]
        public virtual ActionResult CreateEmployee(Account account)
        {
            return View();

        }

        public virtual ActionResult Admin()
        {

            return View(_accountService.ListAccounts());

        }

        public virtual ActionResult CreateAdmin()
        {

            return View();

        }
        [HttpPost]
        public virtual ActionResult CreateAdmin(Account account)
        {
            return View();

        }

        


        public virtual ActionResult CreateUser()
        {

            return View();
        }

        [HttpPost]
        public virtual ActionResult CreateUser(User user)
        {

            Response<User> response = _userService.CreateUser(user,appUser.Username);
            if (response.Success.Equals(true))
            {
                ViewBag.Message = "Successfully Added";
            }
            else
            {
                ViewBag.Message = response.ErrorMessage;
            }
            return View();

        }





    }
}