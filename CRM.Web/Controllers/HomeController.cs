using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRM.Web.Models.ViewModels;
using CRM.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CRM.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetDealsByStage()
        {
            var query = from d in _context.Deals
                        group d by d.Stage into g
                        where
                            g.Key == Models.Entities.Deal.DealStage.Analisis ||
                            g.Key == Models.Entities.Deal.DealStage.Offer ||
                            g.Key == Models.Entities.Deal.DealStage.Negotiation ||
                            g.Key == Models.Entities.Deal.DealStage.Won
                        orderby g.Key
                        select new
                        {
                            stageName = g.Key.ToString(),
                            stageTotalAmount = g.Sum(d => d.TotalAmount)
                        };

            var list = await query.ToListAsync();

            return new JsonResult(list);
        }

        public async Task<IActionResult> GetActivitiesBySalesmanAsync()
        {
            var query = from s in _context.Salesmen
                        join a in _context.Activities
                               on s.Id equals a.SalesmanId
                        group a by a.Salesman.FirstName +" "+ a.Salesman.LastName into salesGroup
                        orderby salesGroup.Count() descending
                        select new
                        {
                            name = salesGroup.Key,
                            sum = salesGroup.Count()
                        };

            var list = await query.Take(5).ToListAsync();

            return new JsonResult(list);
        }

        public async Task<IActionResult> GetCompaniesByDealsSumAsync()
        {
            var query = from c in _context.Companies
                        join d in _context.Deals
                               on c.Id equals d.CompanyId
                        group d by d.Company.Name into companiesGroup
                        orderby companiesGroup.Sum(d => d.TotalAmount) descending
                        select new
                        {
                            name = companiesGroup.Key,
                            sum = companiesGroup.Sum(d => d.TotalAmount)
                        };

            var list = await query.Take(10).ToListAsync();

            return new JsonResult(list);
        }

        public async Task<IActionResult> GetCompaniesByIndustryAsync()
        {
            var query = from c in _context.Companies
                        group c by c.Industry into companiesGroup
                        orderby companiesGroup.Count() descending
                        select new
                        {
                            industyName = companiesGroup.Key.ToString(),
                            companiesNumber = companiesGroup.Count()
                        };

            var list = await query.ToListAsync();

            return new JsonResult(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
