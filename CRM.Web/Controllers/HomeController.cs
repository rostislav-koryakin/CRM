using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRM.Web.ViewModels;
using CRM.Infrastructure.Data;

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

        public IActionResult GetDealsByStage()
        {
            var query = from d in _context.Deals
                        group d by d.Stage into g
                        where
                            g.Key == Core.Entities.Deal.DealStage.Analisis ||
                            g.Key == Core.Entities.Deal.DealStage.Offer ||
                            g.Key == Core.Entities.Deal.DealStage.Negotiation ||
                            g.Key == Core.Entities.Deal.DealStage.Won
                        orderby g.Key
                        select new
                        {
                            stageName = g.Key.ToString(),
                            stageTotalAmount = g.Sum(d => d.TotalAmount)
                        };

            return new JsonResult(query);
        }

        public IActionResult GetActivitiesBySalesman()
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

            //var query2 = _context.Salesmen
            //        .Include(s => s.Activities)
            //            .ThenInclude(s => s.Type)
            //        .Select(s => new
            //            {
            //                name = s.LastName,
            //                type = s.Activities
            //            })
            //        .ToList();

            var result = query.Take(5);

            return new JsonResult(result);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
