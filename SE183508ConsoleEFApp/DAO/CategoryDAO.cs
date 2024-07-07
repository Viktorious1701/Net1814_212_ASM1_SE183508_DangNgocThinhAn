using SE183508ConsoleEFApp.Models;
using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SE183508ConsoleEFApp
{
    public class CategoryDAO
    {
        private readonly NET1814_212_4_JewelryContext _context;

        public CategoryDAO()
        {
            _context = new NET1814_212_4_JewelryContext(new Microsoft.EntityFrameworkCore.DbContextOptions<NET1814_212_4_JewelryContext>());
        }
        //Category Table CRUD
        public void createCategory(Category cate)
        {
            var newCategory = new Category
            {
                CategoryId = cate.CategoryId,
                CategoryName = cate.CategoryName
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
        }
        public Category[] readCategories()
        {
            return _context.Categories.Select(c => new Category
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToArray();
        }
        public void updateCategory(Category cate)
        {
            var selectCategory = _context.Categories.FirstOrDefault(c => c.CategoryId == cate.CategoryId);
            if (selectCategory != null)
            {
                selectCategory.CategoryName = cate.CategoryName;
                _context.SaveChanges();
            }

        }
        public void deleteCategory(int categoryId)
        {
            var selectCategory = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (selectCategory != null)
            {
                _context.Categories.Remove(selectCategory);
                _context.SaveChanges();
            }
        }
    }

}
