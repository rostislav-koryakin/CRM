using CRM.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface IScoreRulesService
    {
        public Task<List<ScoreRule>> GetRules();

        public Task<ScoreRule> GetRuleById(int? id);

        public Task<bool> CreateRule(ScoreRule rule);

        public Task<bool> UpdateRule(ScoreRule rule);

        public Task<bool> DeleteRule(int? id);

        public Task<bool> RuleExists(int id);

        public Task<int> CalculateScoreRule(Company company);

        public Task<int> ApplyScoreRulesForAllCompanies();

    }
}