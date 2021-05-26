using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;
using OMS.Web.Models;

namespace OMS.Core.Interface.Services
{
    public interface ICategoryService
    {
        DataTableResult ListCategories(int take, int skip);

        Response<Category> CreateCategory(Category category);

        Response<Category> UpdateCategory(Category category);

        Response<Category> RemoveCategory(int categoryID);

        Category GetCategoryByID(int categoryID);

        IEnumerable<Category> ListSubCategoryByCategoryID(int categoryID);

        IEnumerable<DTO.SelectListDto> GetCategories();
    }
}
