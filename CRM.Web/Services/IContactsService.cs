using CRM.Core.Entities;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface IContactsService
    {
        public Task<PaginatedList<Contact>> GetContacts(string sortOrder, string searchString, string currentFilter, int? pageNumber);

        public Task<Contact> GetContactById(int? id);

        public Task<bool> CreateContact(Contact contact);

        public Task<bool> UpdateContact(Contact contact);

        public Task<bool> DeleteContact(int? id);

        public Task<bool> ContactExists(int id);
    }
}