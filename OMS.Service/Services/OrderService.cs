using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;
using Entities = OMS.Core.Entities;
using DTO = OMS.Core.DTO;
using OMS.Core.Interface.Repositories;
using AutoMapper;

namespace OMS.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICRUDRepository<Entities.Order> _orderRepo;
        public OrderService(ICRUDRepository<Entities.Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Response<Order> CreateOrder(Order order)
        {
            DTO.Response<DTO.Order> response = new DTO.Response<DTO.Order>();
            try
            {
                order.CreatedDate = DateTime.UtcNow;
                order.UpdatedDate = DateTime.UtcNow;
                _orderRepo.Add(Mapper.Map<DTO.Order, Entities.Order>(order));
                response.Success = true;
                response.Data = order;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public Order GetOrderByID(int orderID)
        {
            return Mapper.Map<Entities.Order, DTO.Order>(_orderRepo.GetSingle(u => u.ID.Equals(orderID)));
        }

        public IEnumerable<Order> ListOrders()
        {
            return Mapper.Map<IEnumerable<Entities.Order>, IEnumerable<DTO.Order>>(_orderRepo.GetAll());
        }

        public IEnumerable<Order> ListOrdersByCategoryID(int categoryID)
        {
            return Mapper.Map<IEnumerable<Entities.Order>, IEnumerable<DTO.Order>>(_orderRepo.GetList(p => p.Product.Category.ID.Equals(categoryID)));
        }

        public IEnumerable<Order> ListOrdersByProductID(int productID)
        {
            return Mapper.Map<IEnumerable<Entities.Order>, IEnumerable<DTO.Order>>(_orderRepo.GetList(p => p.Product.ID.Equals(productID)));
        }

        public IEnumerable<Order> ListOrdersByTransID(int transactionID)
        {
            return Mapper.Map<IEnumerable<Entities.Order>, IEnumerable<DTO.Order>>(_orderRepo.GetList(p => p.Transaction.ID.Equals(transactionID)));
        }

        public IEnumerable<Order> ListOrdersByUserID(int userID)
        {
            return Mapper.Map<IEnumerable<Entities.Order>, IEnumerable<DTO.Order>>(_orderRepo.GetList(p => p.User.ID.Equals(userID)));
        }


        public Response<Order> RemoveOrder(int orderID)
        {
            DTO.Response<DTO.Order> response = new DTO.Response<DTO.Order>();
            try
            {
                Entities.Order order = _orderRepo.GetSingle(u => u.ID.Equals(orderID));
                _orderRepo.Remove(order);
                response.Success = true;
                response.Data = Mapper.Map<Entities.Order, DTO.Order>(order);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public Response<Order> UpdateOrder(Order order)
        {
            order.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Order> response = new DTO.Response<DTO.Order>();
            try
            {
                _orderRepo.Update(Mapper.Map<DTO.Order, Entities.Order>(order));
                response.Success = true;
                response.Data = order;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }
    }
}
