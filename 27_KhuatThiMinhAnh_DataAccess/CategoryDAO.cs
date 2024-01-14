using _27_KhuatThiMinhAnh_BusinessObjects;
using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_DataAccess
{
    public class CategoryDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Category> GetCategories()
        {
            var categories = new List<Category>();
            try
            {
                using (var context = new AppDBContext())
                {
                    categories = context.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Category GetCategoryByID(int id)
        {
            var category = new Category();
            try
            {
                using (var context = new AppDBContext())
                {
                    category = context.Categories.SingleOrDefault(x => x.CategoryID == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <exception cref="Exception"></exception>
        public static void AddCategory(Category category)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Categories.Add(category);
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
        /// <param name="category"></param>
        /// <exception cref="Exception"></exception>
        public static void UpdateCategory(Category category)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        /// <param name="category"></param>
        /// <exception cref="Exception"></exception>
        public static void DeleteCategory(Category category)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var categoryToDelete = context.Categories.SingleOrDefault(x => x.CategoryID == category.CategoryID);
                    if (categoryToDelete != null)
                    {
                        context.Categories.Remove(categoryToDelete);
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
