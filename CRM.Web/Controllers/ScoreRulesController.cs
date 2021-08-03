using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Models.Entities;
using CRM.Web.Services;
using CRM.Web.Models.ViewModels;

namespace CRM.Web.Controllers
{
    public class ScoreRulesController : Controller
    {
        private readonly IScoreRulesService _scoreRulesService;

        public ScoreRulesController(IScoreRulesService scoreRulesService)
        {
            _scoreRulesService = scoreRulesService;
        }

        // GET: ScoreRules
        public async Task<IActionResult> Index()
        {
            var rules = await _scoreRulesService.GetAll();

            return View(rules);
        }

        // GET: ScoreRules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var rules = await _scoreRulesService.GetById(id);

            if (rules == null)
            {
                return View("NotFound");
            }

            return View(rules);
        }

        // GET: ScoreRules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScoreRules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Criteria,RelationSymbol,Value,Points,Id,CreatedDate,UpdatedDate")] FormScoreRuleViewModel scoreRuleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ScoreRule rule = new ScoreRule 
            {
                Criteria = (ScoreRule.RuleCriteria)scoreRuleViewModel.Criteria,
                RelationSymbol = (ScoreRule.ScoreRelationSymbol)scoreRuleViewModel.RelationSymbol,
                Value = scoreRuleViewModel.Value,
                Points = scoreRuleViewModel.Points
            };

            var successful = await _scoreRulesService.Create(rule);

            if (!successful)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ScoreRules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var rule = await _scoreRulesService.GetById(id);

            if (rule == null)
            {
                return View("NotFound");
            }

            FormScoreRuleViewModel scoreRuleViewModel = new FormScoreRuleViewModel
            {
                Id = rule.Id,
                Criteria = (FormScoreRuleViewModel.RuleCriteria)rule.Criteria,
                RelationSymbol = (FormScoreRuleViewModel.ScoreRelationSymbol)rule.RelationSymbol,
                Value = rule.Value,
                Points = rule.Points,
                CreatedDate = rule.CreatedDate,
                UpdatedDate = rule.UpdatedDate
            };

            return View(scoreRuleViewModel);
        }

        // POST: ScoreRules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Criteria,RelationSymbol,Value,Points,Id,CreatedDate,UpdatedDate")] FormScoreRuleViewModel scoreRuleViewModel)
        {
            if (id != scoreRuleViewModel.Id)
            {
                return View("NotFound");
            }

            ScoreRule rule = new ScoreRule
            {
                Id = scoreRuleViewModel.Id,
                Criteria = (ScoreRule.RuleCriteria)scoreRuleViewModel.Criteria,
                RelationSymbol = (ScoreRule.ScoreRelationSymbol)scoreRuleViewModel.RelationSymbol,
                Value = scoreRuleViewModel.Value,
                Points = scoreRuleViewModel.Points,
                CreatedDate = scoreRuleViewModel.CreatedDate,
                UpdatedDate = scoreRuleViewModel.UpdatedDate
            };

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _scoreRulesService.Update(rule);

                    if (result == false)
                    {
                        return View("NotFound");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _scoreRulesService.Exists(id)))
                    {
                        return View("NotFound");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(scoreRuleViewModel);
        }

        // GET: ScoreRules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var rule = await _scoreRulesService.GetById(id);

            if (rule == null)
            {
                return View("NotFound");
            }

            return View(rule);
        }

        // POST: ScoreRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var result = await _scoreRulesService.Delete(id);

            if (result == false)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ApplyScoreRulesForAllCompanies()
        {
            await _scoreRulesService.ApplyScoreRulesForAllCompanies();

            return RedirectToAction(nameof(Index));
        }
    }
}
