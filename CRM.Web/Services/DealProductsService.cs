using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Entities;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Web.Services
{
    public class DealProductsService : IDealProductsService
    {
        private readonly AppDbContext _context;

        public DealProductsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DealProduct>> GetDealsItems()
        {
            return await _context.DealProducts
                .Include(d => d.Deal)
                .Include(d => d.Product)
                .ToListAsync();
        }

        public async Task<DealProduct> GetDealItemById(int? id)
        {
            return await _context.DealProducts
                .Include(d => d.Deal)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> CreateDealItem(DealProduct dealProduct)
        {
            dealProduct.CreatedDate = DateTime.Now;
            
            await _context.AddAsync(dealProduct);

            var saveResult = await _context.SaveChangesAsync();

            var dealId = dealProduct.DealId;

            var sumResult = await SumTotalAmountOnDeal(dealId);

            return saveResult == 1 && sumResult;
        }

        public async Task<bool> UpdateDealItem(DealProduct dealProduct)
        {
            dealProduct.UpdatedDate = DateTime.Now;

            _context.Update(dealProduct);

            var saveResult = await _context.SaveChangesAsync();

            var dealId = dealProduct.DealId;

            var sumResult = await SumTotalAmountOnDeal(dealId);

            return saveResult == 1 && sumResult;
        }

        public async Task<bool> DeleteDealItem(int? id)
        {
            var dealItem = await GetDealItemById(id);

            var dealId = dealItem.Deal.Id;

            _context.DealProducts.Remove(dealItem);

            var deleteResult = await _context.SaveChangesAsync();
            
            var sumResult = await SumTotalAmountOnDeal(dealId);

            return deleteResult == 1 && sumResult;
        }

        public async Task<bool> DealItemExists(int id)
        {
            return await _context.DealProducts.AnyAsync(i => i.Id == id);
        }

        public async Task<bool> SumTotalAmountOnDeal(int? dealId)
        {
            var deal = await _context.Deals
                .Where(d => d.Id == dealId)
                .Include(d => d.DealsProducts)
                    .ThenInclude(d => d.Product)
                .FirstOrDefaultAsync();

            decimal totalAmount = 0;

            foreach (var dealItem in deal.DealsProducts)
            {
                totalAmount += dealItem.Quantity * dealItem.Product.Price;
            }

            deal.TotalAmount = totalAmount;

            _context.Update(deal);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult >= 1;
        }
    }
}