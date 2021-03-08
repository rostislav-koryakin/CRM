﻿using CRM.Core.Entities;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Product>> GetProducts(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            var appDbContext = _context.Products.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                appDbContext = appDbContext.Where(p => p.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    appDbContext = appDbContext.OrderByDescending(p => p.Name);
                    break;
                case "Price":
                    appDbContext = appDbContext.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    appDbContext = appDbContext.OrderByDescending(p => p.Price);
                    break;
                default:
                    appDbContext = appDbContext.OrderBy(p => p.Name);
                    break;
            }

            int pageSize = 10;

            return await PaginatedList<Product>.CreateAsync(appDbContext.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public async Task<Product> GetProductById(int? id)
        {
            return await _context.Products
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CreateProduct(Product product)
        {
            product.CreatedDate = DateTime.Now;

            await _context.Products.AddAsync(product);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            product.UpdatedDate = DateTime.Now;

            _context.Update(product);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> DeleteProduct(int? id)
        {
            var product = await _context.Products.FindAsync(id);

            _context.Products.Remove(product);

            var deleteResult = await _context.SaveChangesAsync();

            return deleteResult == 1;
        }
        public async Task<bool> ProductExists(int id)
        {
            return await _context.Products.AnyAsync(d => d.Id == id);
        }
    }
}