using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Models.Entities;
using CRM.Web.Data;

namespace CRM.Web.Services
{
    public class ContactsService : IContactsService
    {
        private readonly AppDbContext _context;

        public ContactsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Contact>> GetContacts(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            var appDbContext = _context.Contacts
                .Include(c => c.Company)
                .AsQueryable();

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
            
            return await PaginatedList<Contact>.CreateAsync((IQueryable<Contact>)appDbContext.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public async Task<Contact> GetContactById(int? id)
        {
            return await _context.Contacts
                .Where(c => c.Id == id)
                .Include(c => c.Company)
                .Include(c => c.Activities)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CreateContact(Contact contact)
        {
            contact.CreatedDate = DateTime.Now;

            await _context.Contacts.AddAsync(contact);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> UpdateContact(Contact contact)
        {
            contact.UpdatedDate = DateTime.Now;

             _context.Contacts.Update(contact);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> DeleteContact(int? id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            _context.Contacts.Remove(contact);

            var deleteResult = await _context.SaveChangesAsync();

            return deleteResult == 1;
        }

        public async Task<bool> ContactExists(int id)
        {
            return await _context.Contacts.AnyAsync(d => d.Id == id);
        }
    }
}