using CRM.Core.Entities;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface IActivitiesService
    {
        public Task<PaginatedList<Activity>> GetActivities(string sortOrder, string searchString, string currentFilter, int? pageNumber);

        public Task<Activity> GetActivityById(int? id);

        public Task<bool> CreateActivity(Activity activity);

        public Task<bool> UpdateActivity(Activity activity);

        public Task<bool> DeleteActivity(int? id);

        public Task<bool> ActivityExists(int id);
    }
}
