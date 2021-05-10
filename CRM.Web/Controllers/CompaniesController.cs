using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Services;
using CRM.Web.Data;
using CRM.Web.Models.ViewModels;
using CRM.Web.Models.Entities;

namespace CRM.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICompaniesService _compmaniesServices;

        public CompaniesController(AppDbContext context, ICompaniesService companiesService)
        {
            _context = context;
            _compmaniesServices = companiesService;
        }

        // GET: Companies
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TaxpayerNumberSortParm"] = sortOrder == "TaxpayerNumber" ? "taxpayer_number_desc" : "TaxpayerNumber";
            ViewData["CitySortParm"] = sortOrder == "City" ? "city_desc" : "City";
            ViewData["StreetSortParm"] = sortOrder == "Street" ? "street_desc" : "Street";
            ViewData["ZipCodeSortParm"] = sortOrder == "ZipCode" ? "zip_code_desc" : "ZipCode";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var companies = await _compmaniesServices.GetCompanies(sortOrder, searchString, currentFilter, pageNumber);

            return View(companies);
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _compmaniesServices.GetCompanyById(id);

            if (company == null)
            {
                return NotFound();
            }

            var companyViewModel = new CompanyViewModel
            {
                Company = company,
                Contacts = company.Contacts,
                Deals = company.Deals
            };

            return View(companyViewModel);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaxpayerNumber,Name,Website,NoOfEmployees,Industry,Country,City,Street,ZipCode,Id,CreatedDate,UpdatedDate,Score")] Company company)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _compmaniesServices.CreateCompany(company);

            if (!successful)
            {
                return BadRequest("Could not add Company.");
            }

            return RedirectToAction("Index");
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _compmaniesServices.GetCompanyById(id);
            
            if (company == null)
            {
                return NotFound();
            }
            
            return View(company);
        }

        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaxpayerNumber,Name,Website,NoOfEmployees,Industry,Country,City,Street,ZipCode,Id,CreatedDate,UpdatedDate,Score")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _compmaniesServices.UpdateCompany(company);

                    if (result == false)
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _compmaniesServices.CompanyExists(company.Id)))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _compmaniesServices.GetCompanyById(id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _compmaniesServices.DeleteCompany(id);

            if (result == false)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}