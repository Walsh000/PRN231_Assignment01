using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using _27_KhuatThiMinhAnh_DataAccess;
using _27_KhuatThiMinhAnh_Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product) => ProductDAO.AddProduct(product);

        public void DeleteProduct(Product product) => ProductDAO.DeleteProduct(product);

        public List<Category> GetCategories() => CategoryDAO.GetCategories();

        public Product GetProductById(int id) => ProductDAO.GetProductByID(id);

        public List<Product> GetProducts() => ProductDAO.GetProducts();

        public List<Product> ReportProductSale(DateTime fromDate, DateTime toDate) => ProductDAO.ReportProductSale(fromDate, toDate);

        public List<Product> SearchProduct(string name, decimal minPrice, decimal maxPrice) => ProductDAO.SearchProduct(name, minPrice, maxPrice);

        public void UpdateProduct(Product product) => ProductDAO.UpdateProduct(product);
    }
}

