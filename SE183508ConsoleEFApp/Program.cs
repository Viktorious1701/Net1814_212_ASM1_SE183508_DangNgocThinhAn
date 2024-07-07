using System;
using System.Collections.Generic;
using System.Linq;
using SE183508ConsoleEFApp.Models;
using Microsoft.EntityFrameworkCore;

namespace SE183508ConsoleEFApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NET1814_212_4_JewelryContext>();
            // Add your connection string here
            optionsBuilder.UseSqlServer("YourConnectionStringHere");

            using (var _context = new NET1814_212_4_JewelryContext(optionsBuilder.Options))
            {
                // Sample data
                var products = new List<SiProduct>
                {
                    new SiProduct { ProductId = 1, Name = "Gold Necklace", CategoryId = 1, Description = "Beautiful gold necklace", Barcode = "123456", Weight = 10, CostPrice = 500, GoldPrice = 600, LaborCost = 50, StoneCost = 20, SellPriceRatio = 1.2 },
                    new SiProduct { ProductId = 2, Name = "Silver Ring", CategoryId = 2, Description = "Elegant silver ring", Barcode = "7891011", Weight = 5, CostPrice = 200, GoldPrice = 300, LaborCost = 30, StoneCost = 10, SellPriceRatio = 1.5 },
                    new SiProduct { ProductId = 3, Name = "Diamond Bracelet", CategoryId = 1, Description = "Luxurious diamond bracelet", Barcode = "12131415", Weight = 15.0, CostPrice = 1000, GoldPrice = 1200, LaborCost = 100, StoneCost = 500, SellPriceRatio = 1.3 }
                };

                var categories = new List<Category>
                {
                    new Category { CategoryId = 1, CategoryName = "Necklace" },
                    new Category { CategoryId = 2, CategoryName = "Ring" }
                };

                // LINQ to Objects Examples

                // 1. Display all products
                Console.WriteLine("All Products:");
                var allProducts = products.ToList();
                allProducts.ForEach(p => Console.WriteLine(p.ToString()));

                // 2. Find products with GoldPrice greater than 500
                Console.WriteLine("\nProducts with GoldPrice > 500:");
                var expensiveProducts = products.Where(p => p.GoldPrice > 500).ToList();
                expensiveProducts.ForEach(p => Console.WriteLine(p.ToString()));

                // 3. Order products by Name
                Console.WriteLine("\nProducts ordered by Name:");
                var orderedProducts = products.OrderBy(p => p.Name).ToList();
                orderedProducts.ForEach(p => Console.WriteLine(p.ToString()));

                // 4. Join products with categories
                Console.WriteLine("\nProducts joined with Categories:");
                var productCategories = from p in products
                                        join c in categories on p.CategoryId equals c.CategoryId
                                        select new { p.Name, CategoryName = c.CategoryName };

                foreach (var pc in productCategories)
                {
                    Console.WriteLine($"Product: {pc.Name}, Category: {pc.CategoryName}");
                }

                // 5. Group products by CategoryId
                Console.WriteLine("\nProducts grouped by CategoryId:");
                var groupedProducts = products.GroupBy(p => p.CategoryId).ToList();
                foreach (var group in groupedProducts)
                {
                    Console.WriteLine($"CategoryId: {group.Key}");
                    foreach (var product in group)
                    {
                        Console.WriteLine($" - {product.Name}");
                    }
                }

                // 6. Sum of GoldPrice for all products
                Console.WriteLine("\nTotal GoldPrice for all products:");
                var totalGoldPrice = products.Sum(p => p.GoldPrice);
                Console.WriteLine($"Total GoldPrice: {totalGoldPrice}");

                // 7. Average CostPrice of products
                Console.WriteLine("\nAverage CostPrice of products:");
                var averageCostPrice = products.Average(p => p.CostPrice);
                Console.WriteLine($"Average CostPrice: {averageCostPrice}");

                // 8. Add a new product to the list
                Console.WriteLine("\nAdding a new product:");
                var newProduct = new SiProduct
                {
                    ProductId = 4,
                    Name = "Platinum Earrings",
                    CategoryId = 2,
                    Description = "Shiny platinum earrings",
                    Barcode = "16171819",
                    Weight = 3.0,
                    CostPrice = 800,
                    GoldPrice = 900,
                    LaborCost = 70,
                    StoneCost = 40,
                    SellPriceRatio = 1.4
                };
                products.Add(newProduct);
                Console.WriteLine("New product added:");
                products.ForEach(p => Console.WriteLine(p.ToString()));

                // 9. Update a product
                Console.WriteLine("\nUpdating a product:");
                var productToUpdate = products.FirstOrDefault(p => p.ProductId == 1);
                if (productToUpdate != null)
                {
                    productToUpdate.Name = "Updated Gold Necklace";
                    productToUpdate.GoldPrice = 650;
                }
                Console.WriteLine("Product updated:");
                products.ForEach(p => Console.WriteLine(p.ToString()));

                // 10. Delete a product
                Console.WriteLine("\nDeleting a product:");
                var productToDelete = products.FirstOrDefault(p => p.ProductId == 2);
                if (productToDelete != null)
                {
                    products.Remove(productToDelete);
                }
                Console.WriteLine("Product deleted:");
                products.ForEach(p => Console.WriteLine(p.ToString()));
            }
        }
    }
}
