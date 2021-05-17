using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Models.Entities;
using CRM.Web.Data;
using CRM.Web.Services;
using CRM.Web.Models.ViewModels;

namespace CRM.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductsService _productsService;

        public ProductsController(AppDbContext context, IProductsService productsService)
        {
            _context = context;
            _productsService = productsService;
        }

        // GET: Products
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var products = await _productsService.GetPaginatedList(sortOrder, searchString, currentFilter, pageNumber);

            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var product = await _productsService.GetById(id);
            
            if (product == null)
            {
                return View("NotFound");
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Id,VAT,Description,CreatedDate,UpdatedDate")] FormProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Product product = new Product 
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                VAT = productViewModel.VAT,
                Description = productViewModel.Description
            };

            var successful = await _productsService.Create(product);

            if (!successful)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var product = await _productsService.GetById(id);

            if (product == null)
            {
                return View("NotFound");
            }

            FormProductViewModel productViewModel = new FormProductViewModel 
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                VAT = product.VAT,
                Description = product.Description
            };

            return View(productViewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price,VAT,Description,Id,CreatedDate,UpdatedDate")] FormProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                return View("NotFound");
            }

            Product product = new Product
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                VAT = productViewModel.VAT,
                Description = productViewModel.Description
            };

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _productsService.Update(product);

                    if (result == false)
                    {
                        return View("NotFound");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _productsService.Exists(id)))
                    {
                        return View("NotFound");
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(productViewModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var product = await _productsService.GetById(id);

            if (product == null)
            {
                return View("NotFound");
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var result = await _productsService.Delete(id);

            if (result == false)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
