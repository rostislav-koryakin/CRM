using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Core.Entities;
using CRM.Infrastructure.Data;
using CRM.Web.ViewModels;
using CRM.Web.Services;

namespace CRM.Web.Controllers
{
    public class DealsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IDealsService _dealsService;

        public DealsController(AppDbContext context, IDealsService dealsService)
        {
            _context = context;
            _dealsService = dealsService;
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

            var deals = await _dealsService.GetDeals(sortOrder, searchString, currentFilter, pageNumber);

            return View(deals);
        }

        // GET: Deals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _dealsService.GetDealById(id);

            if (deal == null)
            {
                return NotFound();
            }

            List<DealProduct> dealProducts = new List<DealProduct>();
            List<Product> products = new List<Product>();

            dealProducts = deal.DealsProducts;

            foreach (DealProduct dealProduct in deal.DealsProducts)
            {
                products.Add(dealProduct.Product);
            }

            var model = new DealViewModel
            {
                Deal = deal,
                Company = deal.Company,
                Contact = deal.Contact,
                Salesman = deal.Salesman,
                DealProducts = dealProducts,
                Products = products
            };

            return View(model);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,TotalAmount,Stage,Description,ClosingDate,ContactId,CompanyId,SalesmanId,Id,CreatedDate,UpdatedDate")] Deal deal)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _dealsService.CreateDeal(deal);

            if (!successful)
            {
                return BadRequest("Could not add Deal.");
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", deal.CompanyId);
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", deal.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", deal.SalesmanId);
            
            return RedirectToAction("Index");
        }

        // GET: Deals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _dealsService.GetDealById(id);

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,TotalAmount,Stage,Description,ClosingDate,ContactId,CompanyId,SalesmanId,Id,CreatedDate,UpdatedDate")] Deal deal)
        {
            if (id != deal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _dealsService.UpdateDeal(deal);
                    
                    if (result == false)
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _dealsService.DealExists(deal.Id)))
                    {
                        return NotFound();
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

            var deal = await _dealsService.GetDealById(id);

            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // POST: Deals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _dealsService.DeleteDeal(id);

            if (result == false)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}