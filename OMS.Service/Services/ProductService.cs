using AutoMapper;
using OMS.Core.Interface.Repositories;
using OMS.Core.Interface.Services;
using OMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;

namespace OMS.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly ICRUDRepository<Entities.Product> _productRepo;
        private readonly ICRUDRepository<Entities.Category> _categoryRepo;
        public ProductService(ICRUDRepository<Entities.Product> productRepo,
                              ICRUDRepository<Entities.Category> categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        public DTO.Response<DTO.Product> CreateProduct(DTO.Product product)
        {
            DTO.Response<DTO.Product> response = new DTO.Response<DTO.Product>();
            try
            {
                product.CreatedDate = DateTime.UtcNow;
                product.UpdatedDate = DateTime.UtcNow;
                var productEntity = Mapper.Map<DTO.Product, Entities.Product>(product);
                _productRepo.Add(productEntity);
                response.Success = true;
                response.Data = product;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;

        }

        public DTO.Product GetProductByID(int productID)
        {
            return Mapper.Map<Entities.Product, DTO.Product>(_productRepo.GetSingle(u => u.ID.Equals(productID)));
        }

        public IEnumerable<DTO.Product> ListProducts()
        {
            return Mapper.Map<IEnumerable<Entities.Product>, IEnumerable<DTO.Product>>(_productRepo.GetAll());
        }

        public IEnumerable<DTO.Product> ListProductsByCategory(int categoryID)
        {
            return Mapper.Map<IEnumerable<Entities.Product>, IEnumerable<DTO.Product>>(_productRepo.GetList(p => p.Category.ID.Equals(categoryID)));
        }

        public DTO.Response<DTO.Product> RemoveProduct(int productID)
        {
            DTO.Response<DTO.Product> response = new DTO.Response<DTO.Product>();
            try
            {
                Entities.Product product = _productRepo.GetSingle(u => u.ID.Equals(productID));
                _productRepo.Remove(product);
                response.Success = true;
                response.Data = Mapper.Map<Entities.Product, DTO.Product>(product);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DTO.Response<DTO.Product> UpdateProduct(DTO.Product product)
        {
            product.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Product> response = new DTO.Response<DTO.Product>();
            try
            {
                var productEntity = _productRepo.GetSingle(i => i.ID == product.ID);
                productEntity.Name = product.Name;
                productEntity.Description = product.Description;
                productEntity.CategoryId = product.CategoryID;
                productEntity.Price = product.Price;
                _productRepo.Update(productEntity);
                response.Success = true;
                response.Data = product;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DataTableResult ListProductByPage(int take, int skip,string search = "",int category = 0)
        {
            var allProduct = _productRepo.GetAll(i => i.Category);
            if (!string.IsNullOrEmpty(search))
            {
                allProduct = allProduct.Where(i => i.Name.Contains(search) || i.Description.Contains(search)).ToList();
            }
            if(category != 0)
            {
                allProduct = allProduct.Where(i => i.CategoryId == category).ToList();
            }
            var result = allProduct.Skip(skip).Take(take).Select(i => new DTO.ProductResult
            {
                Category = i.Category?.Name,
                Description = i.Description,
                Name = i.Name,
                Price = i.Price.ToString("c", CultureInfo.CreateSpecificCulture("en-PH")),
                ProductId = i.ID
            });
            return new DataTableResult(result, allProduct.Count());
        }
    }
}
