using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Core.Entities;
using CRM.Infrastructure.Data;

namespace CRM.Web.Controllers
{
    public class DealProductsController : Controller
    {
        private readonly AppDbContext _context;

        public DealProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DealProducts
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.DealProducts.Include(d => d.Deal).Include(d => d.Product);
            return View(await appDbContext.ToListAsync());
        }

        // GET: DealProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealProduct = await _context.DealProducts
                .Include(d => d.Deal)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (ModelState.IsValid)
            {
                _context.Add(dealProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DealId"] = new SelectList(_context.Deals, "Id", "Name", dealProduct.DealId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", dealProduct.ProductId);
            return View(dealProduct);
        }

        // GET: DealProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealProduct = await _context.DealProducts.FindAsync(id);
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
                    _context.Update(dealProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealProductExists(dealProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
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

            var dealProduct = await _context.DealProducts
                .Include(d => d.Deal)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealProduct == null)
            {
                return NotFound();
            }

            return View(dealProduct);
        }

        // POST: DealProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dealProduct = await _context.DealProducts.FindAsync(id);
            _context.DealProducts.Remove(dealProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealProductExists(int id)
        {
            return _context.DealProducts.Any(e => e.Id == id);
        }
    }
}
