using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Core.Entities;
using CRM.Infrastructure.Data;

namespace CRM.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly AppDbContext _context;

        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TaxpayerNumberSortParm"] = sortOrder == "TaxpayerNumber" ? "taxpayer_number_desc" : "TaxpayerNumber";
            ViewData["CitySortParm"] = sortOrder == "City" ? "city_desc" : "City";
            ViewData["StreetSortParm"] = sortOrder == "Street" ? "street_desc" : "Street";
            ViewData["ZipCodeSortParm"] = sortOrder == "ZipCode" ? "zip_code_desc" : "ZipCode";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

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

            int pageSize = 3;
            return View(await PaginatedList<Company>.CreateAsync(appDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaxpayerNumber,Name,City,Street,ZipCode,Id,CreatedDate,UpdatedDate")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaxpayerNumber,Name,City,Street,ZipCode,Id,CreatedDate,UpdatedDate")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
