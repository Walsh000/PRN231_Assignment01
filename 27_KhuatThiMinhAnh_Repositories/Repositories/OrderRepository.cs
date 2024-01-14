using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using _27_KhuatThiMinhAnh_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_Repositories.Repositories
{
    public class OrderRepository : Interfaces.IOrderRepository
    {
        public bool AddOrder(Order order) => OrderDAO.AddOrder(order);

        public bool DeleteOrder(Order order) => OrderDAO.DeleteOrder(order);

        public Order GetOrderById(int id) => OrderDAO.GetOrderByID(id);

        public List<Order> GetOrders() => OrderDAO.GetOrders();

        public List<Order> GetOrdersByMember(Member member) => OrderDAO.GetOrderByMember(member);

        public bool UpdateOrder(Order order) => OrderDAO.UpdateOrder(order);
    }
}
