using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using _27_KhuatThiMinhAnh_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_Repositories.Repositories
{
    public class OrderDetailRepository : Interfaces.IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.AddOrderDetail(orderDetail);

        public void DeleteOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.DeleteOrderDetail(orderDetail);

        public OrderDetail GetOrderDetail(int orderId, int productId) => OrderDetailDAO.GetOrderDetail(orderId, productId);

        public List<OrderDetail> GetOrderDetails() => OrderDetailDAO.GetOrderDetails();

        public List<OrderDetail> GetOrderDetailsByOrderId(int id) => OrderDetailDAO.GetOrderDetailByOrderID(id);

        public List<OrderDetail> GetOrderDetailsByProductId(int id) => OrderDetailDAO.GetOrderDetailByProductID(id);

        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.UpdateOrderDetail(orderDetail);
    }
}
