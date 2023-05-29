﻿using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMSContext db;
        public ProductRepository(IMSContext db)
        {
            this.db = db;
        }
        public async Task<List<Product>> GetProductsByName(string name)
        {
            return await db.Products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                            string.IsNullOrWhiteSpace(name)).ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            if (db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase))) return;

            db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await db.Products.Include(x => x.ProductInventories)
                .ThenInclude(x => x.Inventory)
                .FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task UpdateProductAsync(Product product)
        {
            if(db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase))) return;

            var prod = await db.Products.FindAsync(product.ProductId);
            if(prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.ProductPrice = product.ProductPrice;
                prod.ProductQuantity = product.ProductQuantity;
                prod.ProductInventories = product.ProductInventories;

                await db.SaveChangesAsync();
            }
        }
    }
}
