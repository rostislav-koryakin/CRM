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
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["FirstNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";
            ViewData["LastNameSortParm"] = sortOrder == "LastName" ? "last_name_desc" : "LastName";
            ViewData["PhoneSortParm"] = sortOrder == "Phone" ? "phone_desc" : "Phone";
            ViewData["EmailSortParm"] = sortOrder == "Email" ? "email_desc" : "Email";
            ViewData["CompanySortParm"] = sortOrder == "Company" ? "company_desc" : "Company";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

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

            int pageSize = 10;
            return View(await PaginatedList<Contact>.CreateAsync(appDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Contacts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact =  _context.Contacts
                .Where(c => c.Id == id)
                .Include(c => c.Company)
                .Include(c => c.Activities)
                .ToList();

            if (contact == null)
            {
                return NotFound();
            }

            ContactViewModel contactViewModel = new ContactViewModel();
            contactViewModel.Contact = contact.FirstOrDefault();

            List<Activity> activities = new List<Activity>();

            foreach (Contact c in contact)
            {
                contactViewModel.Company = c.Company;

                foreach (Activity activity in c.Activities)
                {
                    activities.Add(activity);
                }
            }

            contactViewModel.Activities = activities;

            return View(contactViewModel);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Position,Description,Source,Phone,Email,CompanyId,Id,CreatedDate,UpdatedDate")] Contact contact)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Position,Description,Source,Phone,Email,CompanyId,Id,CreatedDate,UpdatedDate")] Contact contact)
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
