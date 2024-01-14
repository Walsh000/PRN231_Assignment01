using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        List<Product> SearchProduct(string name, decimal minPrice, decimal maxPrice);
        List<Product> ReportProductSale(DateTime fromDate, DateTime toDate);
        List<Category> GetCategories();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
