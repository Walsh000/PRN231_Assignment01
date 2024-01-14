using _27_KhuatThiMinhAnh_BusinessObjects;
using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_DataAccess
{
    public class OrderDetailDAO
    {
        /// <summary>
        /// GET ALL order details
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<OrderDetail> GetOrderDetails()
        {
            var orderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new AppDBContext())
                {
                    orderDetails = context.OrderDetails.ToList();
                    foreach (var orderDetail in orderDetails)
                    {
                        orderDetail.Order = context.Orders.SingleOrDefault(x => x.OrderID == orderDetail.OrderId);
                        orderDetail.Product = context.Products.SingleOrDefault(x => x.ProductID == orderDetail.ProductId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        /// <summary>
        /// GET by ORDER id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<OrderDetail> GetOrderDetailByOrderID(int id)
        {
            var orderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new AppDBContext())
                {
                    orderDetails = context.OrderDetails.Where(x => x.OrderId == id).ToList();
                    Console.WriteLine("GetOrderDetailsByOrderId: " + orderDetails.Count);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        /// <summary>
        /// GET by PRODUCT id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<OrderDetail> GetOrderDetailByProductID(int id)
        {
            var orderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new AppDBContext())
                {
                    orderDetails = context.OrderDetails.Where(x => x.ProductId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        /// <summary>
        /// GET by ORDER id and PRODUCT id
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static OrderDetail GetOrderDetail(int orderId, int productId)
        {
            var orderDetail = new OrderDetail();
            try
            {
                using (var context = new AppDBContext())
                {
                    orderDetail = context.OrderDetails.SingleOrDefault(x => x.OrderId == orderId && x.ProductId == productId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        /// <summary>
        /// ADD new order detail
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <exception cref="Exception"></exception>
        public static void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UPDATE order detail
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <exception cref="Exception"></exception>
        public static void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Entry(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// DELETE order detail
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <exception cref="Exception"></exception>
        public static void DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var orderDetailToDelete = context.OrderDetails.SingleOrDefault(x => x.OrderId == orderDetail.OrderId && x.ProductId == orderDetail.ProductId);
                    if (orderDetailToDelete != null)
                    {
                        context.OrderDetails.Remove(orderDetailToDelete);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
