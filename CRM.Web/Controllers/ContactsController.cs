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
    public class ContactsController : Controller
    {
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["FirstNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";
            ViewData["LastNameSortParm"] = sortOrder == "LastName" ? "last_name_desc" : "LastName";
            ViewData["PhoneSortParm"] = sortOrder == "Phone" ? "phone_desc" : "Phone";
            ViewData["EmailSortParm"] = sortOrder == "Email" ? "email_desc" : "Email";
            ViewData["CompanySortParm"] = sortOrder == "Company" ? "company_desc" : "Company";
            ViewData["CurrentFilter"] = searchString;

            var appDbContext = _context.Contacts.Include(c => c.Company).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                appDbContext = appDbContext.Where(c => c.FirstName.Contains(searchString)
                                                    || c.LastName.Contains(searchString)
                                                    || c.Email.Contains(searchString)
                                                    || c.Company.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "first_name_desc":
                    appDbContext = appDbContext.OrderByDescending(c => c.FirstName);
                    break;
                case "LastName":
                    appDbContext = appDbContext.OrderBy(c => c.LastName);
                    break;
                case "last_name_desc":
                    appDbContext = appDbContext.OrderByDescending(c => c.LastName);
                    break;
                case "Phone":
                    appDbContext = appDbContext.OrderBy(c => c.Phone);
                    break;
                case "phone_desc":
                    appDbContext = appDbContext.OrderByDescending(c => c.Phone);
                    break;
                case "Email":
                    appDbContext = appDbContext.OrderBy(c => c.Email);
                    break;
                case "email_desc":
                    appDbContext = appDbContext.OrderByDescending(c => c.Email);
                    break;
                case "Company":
                    appDbContext = appDbContext.OrderBy(c => c.Company.Name);
                    break;
                case "company_desc":
                    appDbContext = appDbContext.OrderByDescending(c => c.Company.Name);
                    break;
                default:
                    appDbContext = appDbContext.OrderBy(c => c.FirstName);
                    break;
            }

            return View(await appDbContext.AsNoTracking().ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Phone,Email,CompanyId,Id,CreatedDate,UpdatedDate")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", contact.CompanyId);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", contact.CompanyId);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Phone,Email,CompanyId,Id,CreatedDate,UpdatedDate")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", contact.CompanyId);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
