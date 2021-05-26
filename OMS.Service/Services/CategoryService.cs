using AutoMapper;
using OMS.Core.Interface.Repositories;
using OMS.Core.Interface.Services;
using OMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;

namespace OMS.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICRUDRepository<Entities.Category> _categoryRepo;
        public CategoryService(ICRUDRepository<Entities.Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public DTO.Response<DTO.Category> CreateCategory(DTO.Category category)
        {
            DTO.Response<DTO.Category> response = new DTO.Response<DTO.Category>();
            try
            {
                category.CreatedDate = DateTime.UtcNow;
                category.UpdatedDate = DateTime.UtcNow;
                _categoryRepo.Add(Mapper.Map<DTO.Category, Entities.Category>(category));
                response.Success = true;
                response.Data = category;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DTO.Category GetCategoryByID(int categoryID)
        {
            return Mapper.Map<Entities.Category, DTO.Category>(_categoryRepo.GetSingle(u => u.ID.Equals(categoryID)));
        }

        public DataTableResult ListCategories(int take, int skip)
        {
            var allCategories = _categoryRepo.GetAll();
            var result = allCategories.Skip(skip).Take(take).Select(i => new DTO.Category
            {
                ID = i.ID,
                Name = i.Name,
                Description = i.Description
            });
            return new  DataTableResult(result,allCategories.Count());
        }

        public IEnumerable<DTO.Category> ListSubCategoryByCategoryID(int categoryID)
        {
            return Mapper.Map<IEnumerable<Entities.Category>, IEnumerable<DTO.Category>>(_categoryRepo.GetList(c => c.ParentCategory.ID.Equals(categoryID)));
        }

        public DTO.Response<DTO.Category> RemoveCategory(int categoryID)
        {
            DTO.Response<DTO.Category> response = new DTO.Response<DTO.Category>();
            try
            {
                Entities.Category category = _categoryRepo.GetSingle(u => u.ID.Equals(categoryID));
                _categoryRepo.Remove(category);
                response.Success = true;
                response.Data = Mapper.Map<Entities.Category, DTO.Category>(category);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DTO.Response<DTO.Category> UpdateCategory(DTO.Category category)
        {
            category.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Category> response = new DTO.Response<DTO.Category>();
            try
            {
                var categoryEntity = _categoryRepo.GetSingle(i => i.ID == category.ID);
                categoryEntity.Name = category.Name;
                categoryEntity.Description = category.Description;
                _categoryRepo.Update(categoryEntity);
                response.Success = true;
                response.Data = category;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public IEnumerable<DTO.SelectListDto> GetCategories()
        {
            var result = _categoryRepo.GetAll().Select(i => new DTO.SelectListDto
            {
                Value = i.ID.ToString(),
                Text = i.Name
            });
            return result;
        }
    }
}
