﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Models.Entities;
using CRM.Web.Data;

namespace CRM.Web.Services
{
    public class ScoreRulesService : IScoreRulesService
    {
        private readonly AppDbContext _context;

        public ScoreRulesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ScoreRule>> GetAll()
        {
            return await _context.ScoreRules.ToListAsync();
        }

        public async Task<ScoreRule> GetById(int? id)
        {
            return await _context.ScoreRules.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> Create(ScoreRule rule)
        {
            rule.CreatedDate = DateTime.Now;

            await _context.AddAsync(rule);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> Update(ScoreRule rule)
        {
            rule.UpdatedDate = DateTime.Now;

            _context.Update(rule);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> Delete(int? id)
        {
            var rule = await GetById(id);

            _context.ScoreRules.Remove(rule);

            var deleteResult = await _context.SaveChangesAsync();

            return deleteResult == 1;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.ScoreRules.AnyAsync(i => i.Id == id);
        }

        public async Task<int> CalculateScoreRule(Company company)
        {
            int score = 0;

            string industry = company.Industry.ToString();
            string country = company.Country;
            int size = company.NoOfEmployees;

            var scoreRules = await GetAll();

            foreach (var rule in scoreRules)
            {
                if (rule.Criteria.ToString() == "Industry")
                {
                    if (industry == rule.Value) score += rule.Points;
                }
                else if (rule.Criteria.ToString() == "Country")
                {
                    if (country == rule.Value) score += rule.Points;
                }
                else if (rule.Criteria.ToString() == "Size")
                {
                    var sizeRule = int.Parse(rule.Value);

                    if (size == sizeRule && rule.RelationSymbol == ScoreRule.ScoreRelationSymbol.Equals) score += rule.Points;
                    else if (size > sizeRule && rule.RelationSymbol == ScoreRule.ScoreRelationSymbol.IsGreater) score += rule.Points;
                    else if (size < sizeRule && rule.RelationSymbol == ScoreRule.ScoreRelationSymbol.IsLess) score += rule.Points;
                }
            }
            return score;
        }

        public async Task<int> ApplyScoreRulesForAllCompanies()
        {
            var companies = await _context.Companies.ToListAsync();

            foreach(var company in companies)
            {
                int score = await CalculateScoreRule(company);
                company.Score = score;
                _context.Update(company);
                await _context.SaveChangesAsync();
            }

            return 0;
        }

        public Task<PaginatedList<ScoreRule>> GetPaginatedList(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
