using CRM.Core.Entities;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public class ScoreRulesService : IScoreRulesService
    {
        private readonly AppDbContext _context;

        public ScoreRulesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ScoreRule>> GetRules()
        {
            return await _context.ScoreRules.ToListAsync();
        }

        public async Task<ScoreRule> GetRuleById(int? id)
        {
            return await _context.ScoreRules.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> CreateRule(ScoreRule rule)
        {
            rule.CreatedDate = DateTime.Now;

            await _context.AddAsync(rule);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> UpdateRule(ScoreRule rule)
        {
            rule.UpdatedDate = DateTime.Now;

            _context.Update(rule);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> DeleteRule(int? id)
        {
            var rule = await GetRuleById(id);

            _context.ScoreRules.Remove(rule);

            var deleteResult = await _context.SaveChangesAsync();

            return deleteResult == 1;
        }

        public async Task<bool> RuleExists(int id)
        {
            return await _context.ScoreRules.AnyAsync(i => i.Id == id);
        }

    }
}
