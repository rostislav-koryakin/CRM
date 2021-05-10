using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Models.Entities;
using CRM.Web.Data;
using CRM.Web.Services;

namespace CRM.Web.Controllers
{
    public class DealProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IDealProductsService _dealsProductsServices;

        public DealProductsController(AppDbContext context, IDealProductsService dealProductsService)
        {
            _context = context;
            _dealsProductsServices = dealProductsService;
        }

        // GET: DealProducts
        public async Task<IActionResult> Index()
        {
            var dealsItems = await _dealsProductsServices.GetDealsItems();
            
            return View(dealsItems);
        }

        // GET: DealProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealProduct = await _dealsProductsServices.GetDealItemById(id);
            
            if (dealProduct == null)
            {
                return NotFound();
            }

            return View(dealProduct);
        }

        // GET: DealProducts/Create
        public IActionResult Create()
        {
            ViewData["DealId"] = new SelectList(_context.Deals, "Id", "Name");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            
            return View();
        }

        // POST: DealProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DealId,ProductId,Id,CreatedDate,UpdatedDate,Quantity")] DealProduct dealProduct)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _dealsProductsServices.CreateDealItem(dealProduct);

            if (!successful)
            {
                return BadRequest("Could not add Deal Item.");
            }

            ViewData["DealId"] = new SelectList(_context.Deals, "Id", "Name", dealProduct.DealId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", dealProduct.ProductId);

            return RedirectToAction("Index");
        }

        // GET: DealProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealProduct = await _dealsProductsServices.GetDealItemById(id);
            
            if (dealProduct == null)
            {
                return NotFound();
            }
            
            ViewData["DealId"] = new SelectList(_context.Deals, "Id", "Name", dealProduct.DealId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", dealProduct.ProductId);
            
            return View(dealProduct);
        }

        // POST: DealProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DealId,ProductId,Id,CreatedDate,UpdatedDate,Quantity")] DealProduct dealProduct)
        {
            if (id != dealProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _dealsProductsServices.UpdateDealItem(dealProduct);

                    if (result == false)
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _dealsProductsServices.DealItemExists(dealProduct.Id)))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["DealId"] = new SelectList(_context.Deals, "Id", "Name", dealProduct.DealId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", dealProduct.ProductId);
            
            return View(dealProduct);
        }

        // GET: DealProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealProduct = await _dealsProductsServices.GetDealItemById(id);

            if (dealProduct == null)
            {
                return NotFound();
            }

            return View(dealProduct);
        }

        // POST: DealProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _dealsProductsServices.DeleteDealItem(id);

            if (result == false)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}