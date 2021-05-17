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

            var companies = await _compmaniesServices.GetPaginatedList(sortOrder, searchString, currentFilter, pageNumber);

            return View(companies);
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var company = await _compmaniesServices.GetById(id);

            if (company == null)
            {
                return View("NotFound");
            }

            var companyViewModel = new DetailsCompanyViewModel
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
        public async Task<IActionResult> Create([Bind("TaxpayerNumber,Name,Website,NoOfEmployees,Industry,Country,City,Street,ZipCode,Id,CreatedDate,UpdatedDate,Score")] FormCompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Company company = new Company
            { 
                TaxpayerNumber = companyViewModel.TaxpayerNumber,
                Name = companyViewModel.Name,
                Website = companyViewModel.Website,
                NoOfEmployees = companyViewModel.NoOfEmployees,
                Industry = (Company.Industries)companyViewModel.Industry,
                Country = companyViewModel.Country,
                City = companyViewModel.City,
                Street = companyViewModel.Street,
                ZipCode = companyViewModel.ZipCode
            };

            var successful = await _compmaniesServices.Create(company);

            if (!successful)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var company = await _compmaniesServices.GetById(id);
            
            if (company == null)
            {
                return View("NotFound");
            }

            FormCompanyViewModel companyViewModel = new FormCompanyViewModel
            {
                Id = company.Id,
                TaxpayerNumber = company.TaxpayerNumber,
                Name = company.Name,
                Website = company.Website,
                NoOfEmployees = company.NoOfEmployees,
                Industry = (FormCompanyViewModel.Industries)company.Industry,
                Country = company.Country,
                City = company.City,
                Street = company.Street,
                ZipCode = company.ZipCode,
                Score = company.Score
            };

            return View(companyViewModel);
        }

        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaxpayerNumber,Name,Website,NoOfEmployees,Industry,Country,City,Street,ZipCode,Id,CreatedDate,UpdatedDate,Score")] FormCompanyViewModel companyViewModel)
        {
            if (id != companyViewModel.Id)
            {
                return View("NotFound");
            }

            Company company = new Company
            {
                Id = companyViewModel.Id,
                TaxpayerNumber = companyViewModel.TaxpayerNumber,
                Name = companyViewModel.Name,
                Website = companyViewModel.Website,
                NoOfEmployees = companyViewModel.NoOfEmployees,
                Industry = (Company.Industries)companyViewModel.Industry,
                Country = companyViewModel.Country,
                City = companyViewModel.City,
                Street = companyViewModel.Street,
                ZipCode = companyViewModel.ZipCode,
                Score = companyViewModel.Score
            };

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _compmaniesServices.Update(company);

                    if (result == false)
                    {
                        return View("NotFound");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _compmaniesServices.Exists(company.Id)))
                    {
                        return View("NotFound");
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(companyViewModel);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var company = await _compmaniesServices.GetById(id);

            if (company == null)
            {
                return View("NotFound");
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
                return View("NotFound");
            }

            var result = await _compmaniesServices.Delete(id);

            if (result == false)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}