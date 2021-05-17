using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Models.Entities;
using CRM.Web.Data;
using CRM.Web.Models.ViewModels;
using CRM.Web.Services;

namespace CRM.Web.Controllers
{
    public class SalesmenController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISalesmenService _salesmanServiece;

        public SalesmenController(AppDbContext context, ISalesmenService salesmenService)
        {
            _context = context;
            _salesmanServiece = salesmenService;
        }

        // GET: Salesmen
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["FirstNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";
            ViewData["LastNameSortParm"] = sortOrder == "LastName" ? "last_name_desc" : "LastName";
            ViewData["PhoneSortParm"] = sortOrder == "Phone" ? "phone_desc" : "Phone";
            ViewData["EmailSortParm"] = sortOrder == "Email" ? "email_desc" : "Email";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var salesmen = await _salesmanServiece.GetPaginatedList(sortOrder, searchString, currentFilter, pageNumber);

            return View(salesmen);
        }

        // GET: Salesmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var salesman = await _salesmanServiece.GetById(id);

            if (salesman == null)
            {
                return View("NotFound");
            }

            var salesmanViewModel = new DetailsSalesmanViewModel
            {
                Salesman = salesman,
                Activities = salesman.Activities,
                Deals = salesman.Deals
            };

            return View(salesmanViewModel);
        }

        // GET: Salesmen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salesmen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Phone,Email,MonthlySalesGoal,Id,CreatedDate,UpdatedDate")] FormSalesmanViewModel salesmanViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Salesman salesman = new Salesman 
            {
                FirstName = salesmanViewModel.FirstName,
                LastName = salesmanViewModel.LastName,
                Phone = salesmanViewModel.Phone,
                Email = salesmanViewModel.Email,
                MonthlySalesGoal = salesmanViewModel.MonthlySalesGoal
            };

            var successful = await _salesmanServiece.Create(salesman);

            if (!successful)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Salesmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var salesman = await _salesmanServiece.GetById(id);

            if (salesman == null)
            {
                return View("NotFound");
            }

            FormSalesmanViewModel salesmanViewModel = new FormSalesmanViewModel
            {
                Id = salesman.Id,
                FirstName = salesman.FirstName,
                LastName = salesman.LastName,
                Phone = salesman.Phone,
                Email = salesman.Email,
                MonthlySalesGoal = salesman.MonthlySalesGoal
            };

            return View(salesmanViewModel);
        }

        // POST: Salesmen/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Phone,Email,MonthlySalesGoal,Id,CreatedDate,UpdatedDate")] FormSalesmanViewModel salesmanViewModel)
        {
            if (id != salesmanViewModel.Id)
            {
                return View("NotFound");
            }

            Salesman salesman = new Salesman
            {
                Id = salesmanViewModel.Id,
                FirstName = salesmanViewModel.FirstName,
                LastName = salesmanViewModel.LastName,
                Phone = salesmanViewModel.Phone,
                Email = salesmanViewModel.Email,
                MonthlySalesGoal = salesmanViewModel.MonthlySalesGoal
            };

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _salesmanServiece.Update(salesman);

                    if (result == false)
                    {
                        return View("NotFound");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _salesmanServiece.Exists(salesman.Id)))
                    {
                        return View("NotFound");
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(salesmanViewModel);
        }

        // GET: Salesmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var salesman = await _salesmanServiece.GetById(id);

            if (salesman == null)
            {
                return View("NotFound");
            }

            return View(salesman);
        }

        // POST: Salesmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var result = await _salesmanServiece.Delete(id);

            if (result == false)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
