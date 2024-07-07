using SE183508ConsoleEFApp.Models;
using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SE183508ConsoleEFApp
{
    public class ProductDAO
    {
        private readonly NET1814_212_4_JewelryContext _context;

        public ProductDAO()
        {
            _context = new NET1814_212_4_JewelryContext(new Microsoft.EntityFrameworkCore.DbContextOptions<NET1814_212_4_JewelryContext>());
        }
        // PRODUCT TABLE CRUD
        public void CreateProduct(SiProduct prodDto)
        {
            var newProduct = new SiProduct
            {
                ProductId = prodDto.ProductId,
                Name = prodDto.Name,
                CategoryId = prodDto.CategoryId,
                Description = prodDto.Description,
                Barcode = prodDto.Barcode,
                Weight = prodDto.Weight,
                CostPrice = prodDto.CostPrice,
                GoldPrice = prodDto.GoldPrice,
                LaborCost = prodDto.LaborCost,
                StoneCost = prodDto.StoneCost,
                SellPriceRatio = prodDto.SellPriceRatio
            };
            _context.SiProducts.Add(newProduct);
            _context.SaveChanges();
        }

        public SiProduct[] ReadProducts()
        {
            return _context.SiProducts.Select(p => new SiProduct
            {
                ProductId = p.ProductId,
                Name = p.Name,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Barcode = p.Barcode,
                Weight = p.Weight,
                CostPrice = p.CostPrice,
                GoldPrice = p.GoldPrice,
                LaborCost = p.LaborCost,
                StoneCost = p.StoneCost,
                SellPriceRatio = p.SellPriceRatio
            }).ToArray();
        }

        public void UpdateProduct(SiProduct prodDto)
        {
            var selectedProduct = _context.SiProducts.FirstOrDefault(p => p.ProductId == prodDto.ProductId);
            if (selectedProduct != null)
            {
                selectedProduct.Name = prodDto.Name;
                selectedProduct.CategoryId = prodDto.CategoryId;
                selectedProduct.Description = prodDto.Description;
                selectedProduct.Barcode = prodDto.Barcode;
                selectedProduct.Weight = prodDto.Weight;
                selectedProduct.CostPrice = prodDto.CostPrice;
                selectedProduct.GoldPrice = prodDto.GoldPrice;
                selectedProduct.LaborCost = prodDto.LaborCost;
                selectedProduct.StoneCost = prodDto.StoneCost;
                selectedProduct.SellPriceRatio = prodDto.SellPriceRatio;
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int productId)
        {
            var selectedProduct = _context.SiProducts.FirstOrDefault(p => p.ProductId == productId);
            if (selectedProduct != null)
            {
                _context.SiProducts.Remove(selectedProduct);
                _context.SaveChanges();
            }
        }  
    }

}
