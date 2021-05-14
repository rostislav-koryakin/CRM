using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Models.Entities;
using CRM.Web.Data;

namespace CRM.Web.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly AppDbContext _context;
        private readonly IScoreRulesService _scoreRulesService;

        public CompaniesService(AppDbContext context, IScoreRulesService scoreRulesService)
        {
            _context = context;
            _scoreRulesService = scoreRulesService;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Companies
                .Include(c => c.Contacts)
                .Include(c => c.Deals)
                .ToListAsync();
        }

        public async Task<PaginatedList<Company>> GetPaginatedList(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            var appDbContext = _context.Companies.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                appDbContext = appDbContext.Where(c => c.Name.Contains(searchString)
                                                    || c.City.Contains(searchString)
                                                    || c.TaxpayerNumber.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    appDbContext = appDbContext.OrderByDescending(c => c.Name);
                    break;
                case "TaxpayerNumber":
                    appDbContext = appDbContext.OrderBy(c => c.TaxpayerNumber);
                    break;
                case "taxpayer_number_desc":
                    appDbContext = appDbContext.OrderByDescending(c => c.TaxpayerNumber);
                    break;
                case "City":
                    appDbContext = appDbContext.OrderBy(c => c.City);
                    break;
                case "city_desc":
                    appDbContext = appDbContext.OrderByDescending(c => c.City);
                    break;
                case "Street":
                    appDbContext = appDbContext.OrderBy(c => c.Street);
                    break;
                case "street_desc":
                    appDbContext = appDbContext.OrderByDescending(c => c.Street);
                    break;
                case "ZipCode":
                    appDbContext = appDbContext.OrderBy(c => c.ZipCode);
                    break;
                case "zip_code_desc":
                    appDbContext = appDbContext.OrderByDescending(c => c.ZipCode);
                    break;
                default:
                    appDbContext = appDbContext.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 10;

            return await PaginatedList<Company>.CreateAsync(appDbContext.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public async Task<Company> GetById(int? id)
        {
            return await _context.Companies
                .Where(c => c.Id == id)
                .Include(c => c.Contacts)
                .Include(c => c.Deals)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Create(Company company)
        {
            company.CreatedDate = DateTime.Now;
            company.Score = await _scoreRulesService.CalculateScoreRule(company);

            await _context.AddAsync(company);
            
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> Update(Company company)
        {
            company.UpdatedDate = DateTime.Now;
            company.Score = await _scoreRulesService.CalculateScoreRule(company);

            _context.Update(company);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> Delete(int? id)
        {
            var company = await _context.Companies.FindAsync(id);

            _context.Companies.Remove(company);

            var deleteResult = await _context.SaveChangesAsync();

            return deleteResult == 1;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Companies.AnyAsync(c => c.Id == id);
        }
    }
}
