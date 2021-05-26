using OMS.Core.DTO;
using OMS.Core.Interface.Services;
using System.Web.Mvc;

namespace OMS.Web.Controllers
{
    public partial class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService,
                                 ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual JsonResult ListProducts(string search = "", int categoryid = 0)
        {
            var start = Request.Params["start"];
            var length = Request.Params["length"];
            var draw = Request.Params["draw"];
            var result = _productService.ListProductByPage(int.Parse(length),int.Parse(start),search,categoryid);
            result.draw = int.Parse(draw);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult CreateProduct(int id = 0)
        {
            if (id != 0)
            {
                var model = _productService.GetProductByID(id);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public virtual JsonResult CreateProduct(Product product)
        {
            Response<Product> response;
            product.UpdatedBy = appUser.Username;
            if(product.ID == 0)
            {
                product.CreatedBy = appUser.Username;
                response = _productService.CreateProduct(product);
            }
            else
            {
                response = _productService.UpdateProduct(product);
            }
            return Json(response);
        }

        [HttpGet]
        public virtual JsonResult GetCategory()
        {
            return Json(_categoryService.GetCategories(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual JsonResult GetProduct(int id)
        {
            return Json(_productService.GetProductByID(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual JsonResult RemoveProduct(int id)
        {
            return Json(_productService.RemoveProduct(id), JsonRequestBehavior.AllowGet);
        }
    }
}