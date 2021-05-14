using CRM.Web.Models.Entities;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface IDealsService : IBaseService<Deal>
    {
        public Task<byte[]> CreateQuotePDF(int id);
    }
}