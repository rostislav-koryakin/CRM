using System;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Entities;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Web.Services
{
    public class DealsService : IDealsService
    {
        private readonly AppDbContext _context;

        public DealsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Deal>> GetDeals(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            var appDbContext = _context.Deals
                .Include(d => d.Company)
                .Include(d => d.Contact)
                .Include(d => d.Salesman)
                .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                appDbContext = appDbContext.Where(d => d.Name.Contains(searchString)
                                                    || d.Company.Name.Contains(searchString)
                                                    || d.Contact.Email.Contains(searchString)
                                                    || d.Salesman.Email.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.Name);
                    break;
                case "TotalAmount":
                    appDbContext = appDbContext.OrderBy(d => d.TotalAmount);
                    break;
                case "total_amount_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.TotalAmount);
                    break;
                case "Stage":
                    appDbContext = appDbContext.OrderBy(d => d.Stage);
                    break;
                case "stage_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.Stage);
                    break;
                case "Contact":
                    appDbContext = appDbContext.OrderBy(d => d.Contact.Email);
                    break;
                case "contact_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.Contact.Email);
                    break;
                case "Company":
                    appDbContext = appDbContext.OrderBy(d => d.Company.Name);
                    break;
                case "company_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.Company.Name);
                    break;
                case "Salesman":
                    appDbContext = appDbContext.OrderBy(d => d.Salesman.Email);
                    break;
                case "salesman_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.Salesman.Email);
                    break;
                default:
                    appDbContext = appDbContext.OrderBy(d => d.Name);
                    break;
            }

            int pageSize = 10;

            return await PaginatedList<Deal>.CreateAsync(appDbContext.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public async Task<Deal> GetDealById(int? id)
        {
            var deal = await _context.Deals
                .Where(d => d.Id == id)
                .Include(d => d.DealsProducts)
                    .ThenInclude(d => d.Product)
                .Include(d => d.Contact)
                .Include(d => d.Company)
                .Include(d => d.Salesman)
                .FirstOrDefaultAsync();

            return deal;
        }

        public async Task<bool> CreateDeal(Deal deal)
        {
            deal.CreatedDate = DateTime.Now;

            await _context.Deals.AddAsync(deal);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> UpdateDeal(Deal deal)
        {
            deal.UpdatedDate = DateTime.Now;

            _context.Update(deal);

            var saveResult = await _context.SaveChangesAsync();
            
            return saveResult == 1;
        }

        public async Task<bool> DeleteDeal(int? id)
        {
            var deal = await _context.Deals.FindAsync(id);
            
            _context.Deals.Remove(deal);
            
            var deleteResult = await _context.SaveChangesAsync();

            return deleteResult == 1;
        }

        public async Task<bool> DealExists(int id)
        {
            return await _context.Deals.AnyAsync(d => d.Id == id);
        }
    }
}