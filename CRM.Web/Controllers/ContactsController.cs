using System;
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

            var contacts = await _contactsService.GetPaginatedList(sortOrder, searchString, currentFilter, pageNumber);

            return View(contacts);
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var contact = await _contactsService.GetById(id);

            if (contact == null)
            {
                return View("NotFound");
            }

            var contactViewModel = new DetailsContactViewModel
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
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Position,Description,Source,Phone,Email,CompanyId,Id,CreatedDate,UpdatedDate")] FormContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Contact contact = new Contact 
            {
                FirstName = contactViewModel.FirstName,
                LastName = contactViewModel.LastName,
                Position = contactViewModel.Position,
                Description = contactViewModel.Description,
                Source = (Contact.Sources)contactViewModel.Source,
                Phone = contactViewModel.Phone,
                Email = contactViewModel.Email,
                CompanyId = contactViewModel.CompanyId
            };

            var successful = await _contactsService.Create(contact);

            if (!successful)
            {
                return View("NotFound");
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", contact.CompanyId);

            return RedirectToAction(nameof(Index));
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var contact = await _contactsService.GetById(id);
            
            if (contact == null)
            {
                return View("NotFound");
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", contact.CompanyId);

            FormContactViewModel contactViewModel = new FormContactViewModel
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Position = contact.Position,
                Description = contact.Description,
                Source = (FormContactViewModel.Sources)contact.Source,
                Phone = contact.Phone,
                Email = contact.Email,
                CompanyId = contact.CompanyId,
                CreatedDate = contact.CreatedDate,
                UpdatedDate = contact.UpdatedDate
            };

            return View(contactViewModel);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Position,Description,Source,Phone,Email,CompanyId,Id,CreatedDate,UpdatedDate")] FormContactViewModel contactViewModel)
        {
            if (id != contactViewModel.Id)
            {
                return View("NotFound");
            }

            Contact contact = new Contact
            {
                Id = contactViewModel.Id,
                FirstName = contactViewModel.FirstName,
                LastName = contactViewModel.LastName,
                Position = contactViewModel.Position,
                Description = contactViewModel.Description,
                Source = (Contact.Sources)contactViewModel.Source,
                Phone = contactViewModel.Phone,
                Email = contactViewModel.Email,
                CompanyId = contactViewModel.CompanyId,
                CreatedDate = contactViewModel.CreatedDate,
                UpdatedDate = contactViewModel.UpdatedDate
            };

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _contactsService.Update(contact);

                    if (result == false)
                    {
                        return View("NotFound");
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _contactsService.Exists(contact.Id)))
                    {
                        return View("NotFound");
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", contact.CompanyId);
            
            return View(contactViewModel);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var contact = await _contactsService.GetById(id);

            if (contact == null)
            {
                return View("NotFound");
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
                return View("NotFound");
            }

            var result = await _contactsService.Delete(id);

            if (result == false)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
