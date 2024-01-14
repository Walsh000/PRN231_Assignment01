using _27_KhuatThiMinhAnh_BusinessObjects;
using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_DataAccess
{
    public class OrderDAO
    {
        /// <summary>
        /// GET ALL orders
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Order> GetOrders()
        {
            var orders = new List<Order>();
            try
            {
                using (var context = new AppDBContext())
                {
                    orders = context.Orders.ToList();
                    foreach(var order in orders)
                    {
                        order.Member = context.Members.SingleOrDefault(x => x.MemberID == order.MemberID);
                    }
                    Console.WriteLine(orders.Count);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        /// <summary>
        /// GET order by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Order GetOrderByID(int id)
        {
            var order = new Order();
            try
            {
                using (var context = new AppDBContext())
                {
                    order = context.Orders.SingleOrDefault(x => x.OrderID == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        /// <summary>
        /// GET order by MEMBER
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Order> GetOrderByMember(Member member)
        {
            var orders = new List<Order>();
            try
            {
                using (var context = new AppDBContext())
                {
                    orders = context.Orders.Where(x => x.MemberID == member.MemberID).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        /// <summary>
        /// ADD new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool AddOrder(Order order)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UPDATE order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool UpdateOrder(Order order)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// DELETE order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool DeleteOrder(Order order)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var orderToDelete = context.Orders.SingleOrDefault(x => x.OrderID == order.OrderID);
                    if (orderToDelete == null) return false;
                    context.Orders.Remove(orderToDelete);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
