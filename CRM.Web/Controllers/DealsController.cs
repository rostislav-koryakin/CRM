using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Models.Entities;
using CRM.Web.Models.ViewModels;
using CRM.Web.Services;
using CRM.Web.Data;

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

            var deals = await _dealsService.GetPaginatedList(sortOrder, searchString, currentFilter, pageNumber);

            return View(deals);
        }

        // GET: Deals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var deal = await _dealsService.GetById(id);

            if (deal == null)
            {
                return View("NotFound");
            }

            List<DealProduct> dealProducts = new List<DealProduct>();
            List<Product> products = new List<Product>();

            dealProducts = deal.DealsProducts;

            foreach (DealProduct dealProduct in deal.DealsProducts)
            {
                products.Add(dealProduct.Product);
            }

            DetailsDealViewModel dealViewModel = new DetailsDealViewModel
            {
                Deal = deal,
                Company = deal.Company,
                Contact = deal.Contact,
                Salesman = deal.Salesman,
                DealProducts = dealProducts,
                Products = products
            };

            return View(dealViewModel);
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
        public async Task<IActionResult> Create([Bind("Name,TotalAmount,Stage,Description,ClosingDate,ContactId,CompanyId,SalesmanId,Id,CreatedDate,UpdatedDate")] FormDealViewModel dealViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("NotFound");
            }

            Deal deal = new Deal 
            {
                Name = dealViewModel.Name,
                Stage = (Deal.DealStage)dealViewModel.Stage,
                Description = dealViewModel.Description,
                ClosingDate = dealViewModel.ClosingDate,
                ContactId = dealViewModel.ContactId,
                CompanyId = dealViewModel.CompanyId,
                SalesmanId = dealViewModel.SalesmanId
            };

            var successful = await _dealsService.Create(deal);

            if (!successful)
            {
                return View("NotFound");
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", deal.CompanyId);
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", deal.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", deal.SalesmanId);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Deals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var deal = await _dealsService.GetById(id);

            if (deal == null)
            {
                return View("NotFound");
            }
            
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", deal.CompanyId);
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", deal.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", deal.SalesmanId);

            FormDealViewModel dealViewModel = new FormDealViewModel
            {
                Id = deal.Id,
                Name = deal.Name,
                Stage = (FormDealViewModel.DealStage)deal.Stage,
                Description = deal.Description,
                ClosingDate = deal.ClosingDate,
                ContactId = deal.ContactId,
                CompanyId = deal.CompanyId,
                SalesmanId = deal.SalesmanId
            };

            return View(dealViewModel);
        }

        // POST: Deals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,TotalAmount,Stage,Description,ClosingDate,ContactId,CompanyId,SalesmanId,Id,CreatedDate,UpdatedDate")] FormDealViewModel dealViewModel)
        {
            if (id != dealViewModel.Id)
            {
                return View("NotFound");
            }

            Deal deal = new Deal
            {
                Id = dealViewModel.Id,
                Name = dealViewModel.Name,
                Stage = (Deal.DealStage)dealViewModel.Stage,
                Description = dealViewModel.Description,
                ClosingDate = dealViewModel.ClosingDate,
                ContactId = dealViewModel.ContactId,
                CompanyId = dealViewModel.CompanyId,
                SalesmanId = dealViewModel.SalesmanId
            };

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _dealsService.Update(deal);
                    
                    if (result == false)
                    {
                        return View("NotFound");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _dealsService.Exists(deal.Id)))
                    {
                        return View("NotFound");
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", deal.CompanyId);
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", deal.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", deal.SalesmanId);
            
            return View(dealViewModel);
        }

        // GET: Deals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var deal = await _dealsService.GetById(id);

            if (deal == null)
            {
                return View("NotFound");
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
                return View("NotFound");
            }

            var result = await _dealsService.Delete(id);

            if (result == false)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GenerateSalesQuote(int id)
        {
            var file = await _dealsService.CreateQuotePDF(id);

            return File(file, "application/pdf", "Quote.pdf");
        }
    }
}