using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Core.Entities;
using CRM.Infrastructure.Data;
using CRM.Web.ViewModels;
using Microsoft.EntityFrameworkCore.Query;

namespace CRM.Web.Controllers
{
    public class DealsController : Controller
    {
        private readonly AppDbContext _context;

        public DealsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Deals
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TotalAmountSortParm"] = sortOrder == "TotalAmount" ? "total_amount_desc" : "TotalAmount";
            ViewData["StageSortParm"] = sortOrder == "Stage" ? "stage_desc" : "Stage";
            ViewData["ContactSortParm"] = sortOrder == "Contact" ? "contact_desc" : "Contact";
            ViewData["CompanySortParm"] = sortOrder == "Company" ? "company_desc" : "Company";
            ViewData["SalesmanSortParm"] = sortOrder == "Salesman" ? "salesman_desc" : "Salesman";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var appDbContext = _context.Deals.Include(d => d.Company).Include(d => d.Contact).Include(d => d.Salesman).AsQueryable();

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

            int pageSize = 3;
            return View(await PaginatedList<Deal>.CreateAsync(appDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Deals/Details/5
        public IActionResult Details(int? id)
        {
            DealProductsViewModel dealProductsViewModel = new DealProductsViewModel();
            dealProductsViewModel.Deal = GetDeal(id);
            dealProductsViewModel.DealProducts = GetDealProducts(id);

            return View(dealProductsViewModel);
        }

        public Deal GetDeal(int? id)
        {
            var deal =  _context.Deals
                .Include(d => d.Company)
                .Include(d => d.Contact)
                .Include(d => d.Salesman)
                .FirstOrDefault(d => d.Id == id);

            return deal;
        }

        public IIncludableQueryable<DealProduct, Product> GetDealProducts(int? id)
        {
            var dealProducts = _context.DealProducts
                .Where(d => d.DealId == id)
                .Include(p => p.Product);

            return dealProducts;
        }


        // GET: Deals/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email");
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email");
            return View();
        }

        // POST: Deals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,TotalAmount,Stage,Description,ContactId,CompanyId,SalesmanId,Id,CreatedDate,UpdatedDate")] Deal deal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", deal.CompanyId);
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", deal.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", deal.SalesmanId);
            return View(deal);
        }

        // GET: Deals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.Deals.FindAsync(id);
            if (deal == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", deal.CompanyId);
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", deal.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", deal.SalesmanId);
            return View(deal);
        }

        // POST: Deals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,TotalAmount,Stage,Description,ContactId,CompanyId,SalesmanId,Id,CreatedDate,UpdatedDate")] Deal deal)
        {
            if (id != deal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealExists(deal.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", deal.CompanyId);
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", deal.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", deal.SalesmanId);
            return View(deal);
        }

        // GET: Deals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.Deals
                .Include(d => d.Company)
                .Include(d => d.Contact)
                .Include(d => d.Salesman)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // POST: Deals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deal = await _context.Deals.FindAsync(id);
            _context.Deals.Remove(deal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealExists(int id)
        {
            return _context.Deals.Any(e => e.Id == id);
        }
    }
}
