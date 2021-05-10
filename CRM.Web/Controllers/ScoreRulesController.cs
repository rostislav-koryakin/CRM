using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Models.Entities;
using CRM.Web.Services;

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
            var rules = await _scoreRulesService.GetRules();

            return View(rules);
        }

        // GET: ScoreRules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rules = await _scoreRulesService.GetRuleById(id);

            if (rules == null)
            {
                return NotFound();
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
        public async Task<IActionResult> Create([Bind("Criteria,RelationSymbol,Value,Points,Id,CreatedDate,UpdatedDate")] ScoreRule rule)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _scoreRulesService.CreateRule(rule);

            if (!successful)
            {
                return BadRequest("Could not add Rule.");
            }

            return RedirectToAction("Index");
        }

        // GET: ScoreRules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rule = await _scoreRulesService.GetRuleById(id);

            if (rule == null)
            {
                return NotFound();
            }

            return View(rule);
        }

        // POST: ScoreRules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Criteria,RelationSymbol,Value,Points,Id,CreatedDate,UpdatedDate")] ScoreRule rule)
        {
            if (id != rule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _scoreRulesService.UpdateRule(rule);

                    if (result == false)
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _scoreRulesService.RuleExists(id)))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rule);
        }

        // GET: ScoreRules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rule = await _scoreRulesService.GetRuleById(id);

            if (rule == null)
            {
                return NotFound();
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
                return NotFound();
            }

            var result = await _scoreRulesService.DeleteRule(id);

            if (result == false)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ApplyScoreRulesForAllCompanies()
        {
            await _scoreRulesService.ApplyScoreRulesForAllCompanies();

            return RedirectToAction("Index");
        }
    }
}
