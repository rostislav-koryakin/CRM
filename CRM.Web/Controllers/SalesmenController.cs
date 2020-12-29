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
    public class SalesmenController : Controller
    {
        private readonly AppDbContext _context;

        public SalesmenController(AppDbContext context)
        {
            _context = context;
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

            var appDbContext = _context.Salesmen.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                appDbContext = appDbContext.Where(s => s.FirstName.Contains(searchString)
                                                    || s.LastName.Contains(searchString)
                                                    || s.Email.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "first_name_desc":
                    appDbContext = appDbContext.OrderByDescending(s => s.FirstName);
                    break;
                case "LastName":
                    appDbContext = appDbContext.OrderBy(s => s.LastName);
                    break;
                case "last_name_desc":
                    appDbContext = appDbContext.OrderByDescending(s => s.LastName);
                    break;
                case "Phone":
                    appDbContext = appDbContext.OrderBy(s => s.Phone);
                    break;
                case "phone_desc":
                    appDbContext = appDbContext.OrderByDescending(s => s.Phone);
                    break;
                case "Email":
                    appDbContext = appDbContext.OrderBy(s => s.Email);
                    break;
                case "email_desc":
                    appDbContext = appDbContext.OrderByDescending(s => s.Email);
                    break;
                default:
                    appDbContext = appDbContext.OrderBy(s => s.FirstName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Salesman>.CreateAsync(appDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Salesmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesman = await _context.Salesmen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesman == null)
            {
                return NotFound();
            }

            return View(salesman);
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
            if (ModelState.IsValid)
            {
                _context.Add(salesman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesman);
        }

        // GET: Salesmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesman = await _context.Salesmen.FindAsync(id);
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
                    _context.Update(salesman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesmanExists(salesman.Id))
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
            return View(salesman);
        }

        // GET: Salesmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesman = await _context.Salesmen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesman == null)
            {
                return NotFound();
            }

            return View(salesman);
        }

        // POST: Salesmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesman = await _context.Salesmen.FindAsync(id);
            _context.Salesmen.Remove(salesman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesmanExists(int id)
        {
            return _context.Salesmen.Any(e => e.Id == id);
        }
    }
}
