using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;

namespace OMS.Core.Interface.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> ListOrders();

        Response<Order> CreateOrder(Order order);

        Response<Order> UpdateOrder(Order order);

        Response<Order> RemoveOrder(int orderID);

        Order GetOrderByID(int orderID);

        IEnumerable<Order> ListOrdersByCategoryID(int categoryID);

        IEnumerable<Order> ListOrdersByProductID(int productID);

        IEnumerable<Order> ListOrdersByUserID(int userID);

        IEnumerable<Order> ListOrdersByTransID(int transactionID);

    }
}
