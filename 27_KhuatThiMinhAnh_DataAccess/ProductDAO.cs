using _27_KhuatThiMinhAnh_BusinessObjects;
using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_DataAccess
{
    public class ProductDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            try
            {
                using (var context = new AppDBContext())
                {
                    products = context.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Product GetProductByID(int id)
        {
            var product = new Product();
            try
            {
                using (var context = new AppDBContext())
                {
                    product = context.Products.SingleOrDefault(x => x.ProductID == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        /// <summary>
        /// SEARCH product
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Product> SearchProduct(string? name, decimal minPrice = 0, decimal maxPrice = 0)
        {
            var products = new List<Product>();
            try
            {
                using (var context = new AppDBContext())
                {
                    products = context.Products.Where(x => (string.IsNullOrWhiteSpace(name) ? true : x.ProductName.Contains(name))
                    && x.UnitPrice >= minPrice
                    && ((maxPrice <= 0 || maxPrice < minPrice) ? true : x.UnitPrice <= maxPrice))
                        .ToList();
                }
                Console.WriteLine(products.Count);
                Console.WriteLine(products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="Exception"></exception>
        public static void AddProduct(Product product)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="Exception"></exception>
        public static void UpdateProduct(Product product)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="Exception"></exception>
        public static void DeleteProduct(Product product)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var productToDelete = context.Products.SingleOrDefault(x => x.ProductID == product.ProductID);
                    if (productToDelete != null)
                    {
                        context.Products.Remove(productToDelete);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// REPORT product sale
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Product> ReportProductSale(DateTime fromDate, DateTime toDate)
        {
            var products = new List<Product>();
            try
            {
                throw new NotImplementedException();
                //using (var context = new AppDBContext())
                //{
                //    var list = context.Products
                //        .Join(context.OrderDetails,
                //        product => product.ProductID,
                //        od => od.ProductId,
                //        (product, od) => new { Product = product, OrderDetail = od })
                //        .Where(x => x.OrderDetail.ProductId == x.Product.ProductID)
                //        .ToList();
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
    }
}
