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
    public class ActivitiesController : Controller
    {
        private readonly AppDbContext _context;

        public ActivitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TypeSortParm"] = sortOrder == "Type" ? "type_desc" : "Type";
            ViewData["StartDateSortParm"] = sortOrder == "StartDate" ? "start_date_desc" : "StartDate";
            ViewData["EndDateSortParm"] = sortOrder == "EndDate" ? "end_date_desc" : "EndDate";
            ViewData["ContactSortParm"] = sortOrder == "Contact" ? "contact_desc" : "Contact";
            ViewData["SalesmanSortParm"] = sortOrder == "Salesman" ? "salesman_desc" : "Salesman";
            ViewData["CurrentFilter"] = searchString;

            var appDbContext = _context.Activities.Include(a => a.Contact).Include(a => a.Salesman).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                appDbContext = appDbContext.Where(a => a.Name.Contains(searchString)
                                       || a.Contact.Email.Contains(searchString)
                                       || a.Salesman.Email.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    appDbContext = appDbContext.OrderByDescending(a => a.Name);
                    break;
                case "Type":
                    appDbContext = appDbContext.OrderBy(a => a.Type);
                    break;
                case "type_desc":
                    appDbContext = appDbContext.OrderByDescending(a => a.Type);
                    break;
                case "StartDate":
                    appDbContext = appDbContext.OrderBy(a => a.StartDate);
                    break;
                case "start_date_desc":
                    appDbContext = appDbContext.OrderByDescending(a => a.StartDate);
                    break;
                case "EndDate":
                    appDbContext = appDbContext.OrderBy(a => a.EndDate);
                    break;
                case "end_date_desc":
                    appDbContext = appDbContext.OrderByDescending(a => a.EndDate);
                    break;
                case "Contact":
                    appDbContext = appDbContext.OrderBy(a => a.Contact.Email);
                    break;
                case "contact_desc":
                    appDbContext = appDbContext.OrderByDescending(a => a.Contact.Email);
                    break;
                case "Salesman":
                    appDbContext = appDbContext.OrderBy(a => a.Salesman.Email);
                    break;
                case "salesman_desc":
                    appDbContext = appDbContext.OrderByDescending(a => a.Salesman.Email);
                    break;
                default:
                    appDbContext = appDbContext.OrderBy(a => a.Name);
                    break;
            }
            return View(await appDbContext.AsNoTracking().ToListAsync());
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.Contact)
                .Include(a => a.Salesman)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email");
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,StartDate,EndDate,Type,ContactId,SalesmanId,Id,CreatedDate,UpdatedDate")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", activity.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", activity.SalesmanId);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", activity.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", activity.SalesmanId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,StartDate,EndDate,Type,ContactId,SalesmanId,Id,CreatedDate,UpdatedDate")] Activity activity)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.Id))
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
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", activity.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", activity.SalesmanId);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.Contact)
                .Include(a => a.Salesman)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityExists(int id)
        {
            return _context.Activities.Any(e => e.Id == id);
        }
    }
}
