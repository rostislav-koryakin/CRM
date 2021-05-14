using CRM.Web.Models.Entities;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface IScoreRulesService : IBaseService<ScoreRule>
    {
        public Task<int> CalculateScoreRule(Company company);

        public Task<int> ApplyScoreRulesForAllCompanies();

    }
}