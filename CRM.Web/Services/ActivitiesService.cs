using CRM.Core.Entities;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly AppDbContext _context;

        public ActivitiesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Activity>> GetActivities(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            var appDbContext = _context.Activities
                .Include(a => a.Contact)
                .Include(a => a.Salesman)
                .AsQueryable();

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

            int pageSize = 10;

            return await PaginatedList<Activity>.CreateAsync(appDbContext.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public async Task<Activity> GetActivityById(int? id)
        {
            var activity = await _context.Activities
                .Include(a => a.Contact)
                .Include(a => a.Salesman)
                .FirstOrDefaultAsync(m => m.Id == id);

            return activity;
        }

        public async Task<bool> CreateActivity(Activity activity)
        {
            activity.CreatedDate = DateTime.Now;

            _context.Add(activity);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> UpdateActivity(Activity activity)
        {
            activity.UpdatedDate = DateTime.Now;

            _context.Update(activity);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> DeleteActivity(int? id)
        {
            var activity = await _context.Activities.FindAsync(id);

            _context.Activities.Remove(activity);

            var deleteResult = await _context.SaveChangesAsync();

            return deleteResult == 1;
        }

        public async Task<bool> ActivityExists(int id)
        {
            return await _context.Activities.AnyAsync(a => a.Id == id);
        }
    }
}