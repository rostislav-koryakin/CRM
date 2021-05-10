using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ContactsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IContactsService _contactsService;

        public ContactsController(AppDbContext context, IContactsService contactsService)
        {
            _context = context;
            _contactsService = contactsService;
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

            var contacts = await _contactsService.GetContacts(sortOrder, searchString, currentFilter, pageNumber);

            return View(contacts);
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contactsService.GetContactById(id);

            if (contact == null)
            {
                return NotFound();
            }

            var contactViewModel = new ContactViewModel
            {
                Activities = contact.Activities,
                Company = contact.Company,
                Contact = contact
            };

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
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _contactsService.CreateContact(contact);

            if (!successful)
            {
                return BadRequest("Could not add Contact.");
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", contact.CompanyId);
            
            return RedirectToAction("Index");
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contactsService.GetContactById(id);
            
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
                    var result = await _contactsService.UpdateContact(contact);

                    if (result == false)
                    {
                        return NotFound();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _contactsService.ContactExists(contact.Id)))
                    {
                        return NotFound();
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

            var contact = await _contactsService.GetContactById(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _contactsService.DeleteContact(id);

            if (result == false)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
