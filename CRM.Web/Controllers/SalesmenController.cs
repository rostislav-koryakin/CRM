using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Models.Entities;
using CRM.Web.Data;
using CRM.Web.Models.ViewModels;
using CRM.Web.Services;

namespace CRM.Web.Controllers
{
    public class SalesmenController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISalesmenService _salesmanServiece;

        public SalesmenController(AppDbContext context, ISalesmenService salesmenService)
        {
            _context = context;
            _salesmanServiece = salesmenService;
        }

        // GET: Salesmen
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["FirstNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";
            ViewData["LastNameSortParm"] = sortOrder == "LastName" ? "last_name_desc" : "LastName";
            ViewData["PhoneSortParm"] = sortOrder == "Phone" ? "phone_desc" : "Phone";
            ViewData["EmailSortParm"] = sortOrder == "Email" ? "email_desc" : "Email";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var salesmen = await _salesmanServiece.GetSalesmen(sortOrder, searchString, currentFilter, pageNumber);

            return View(salesmen);
        }

        // GET: Salesmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesman = await _salesmanServiece.GetSalesmanlById(id);

            if (salesman == null)
            {
                return NotFound();
            }

            var salesmanViewModel = new SalesmanViewModel
            {
                Salesman = salesman,
                Activities = salesman.Activities,
                Deals = salesman.Deals
            };

            return View(salesmanViewModel);
        }

        // GET: Salesmen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salesmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Phone,Email,Id,CreatedDate,UpdatedDate")] Salesman salesman)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _salesmanServiece.CreateSalesman(salesman);

            if (!successful)
            {
                return BadRequest("Could not add Salesman.");
            }

            return RedirectToAction("Index");
        }

        // GET: Salesmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesman = await _salesmanServiece.GetSalesmanlById(id);

            if (salesman == null)
            {
                return NotFound();
            }

            return View(salesman);
        }

        // POST: Salesmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Phone,Email,Id,CreatedDate,UpdatedDate")] Salesman salesman)
        {
            if (id != salesman.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _salesmanServiece.UpdateSalesman(salesman);

                    if (result == false)
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _salesmanServiece.SalesmanExists(salesman.Id)))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(salesman);
        }

        // GET: Salesmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesman = await _salesmanServiece.GetSalesmanlById(id);

            if (salesman == null)
            {
                return NotFound();
            }

            return View(salesman);
        }

        // POST: Salesmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _salesmanServiece.DeleteSalesman(id);

            if (result == false)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
