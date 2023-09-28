using ConcultancyCRM.CustomAttibutes;
using ConcultancyCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConcultancyCRM.Controllers
{
    [GeneralAdminAuth]
    public class AssestCategoryController : _ABSAuthenticatedController
    {
        private readonly MyDBContext _context;

        public AssestCategoryController(MyDBContext context)
        {
            _context = context;
        }

        // GET: AssestCategories
        public async Task<IActionResult> Index()
        {
            var myDBContext = _context.AssestCategories;
            return View(await myDBContext.ToListAsync());
        }

        // GET: AssestCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AssestCategories == null)
            {
                return NotFound();
            }

            var assestCategory = await _context.AssestCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assestCategory == null)
            {
                return NotFound();
            }

            return View(assestCategory);
        }

        // GET: AssestCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssestCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssestCategory assestCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assestCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assestCategory);
        }

        // GET: AssestCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AssestCategories == null)
            {
                return NotFound();
            }

            var assestCategory = await _context.AssestCategories.FindAsync(id);
            if (assestCategory == null)
            {
                return NotFound();
            }
            return View(assestCategory);
        }

        // POST: AssestCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssestCategory assestCategory)
        {
            if (id != assestCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assestCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!assestCategoryExists(assestCategory.Id))
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
            return View(assestCategory);
        }

        // GET: AssestCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AssestCategories == null)
            {
                return NotFound();
            }

            var assestCategory = await _context.AssestCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assestCategory == null)
            {
                return NotFound();
            }

            return View(assestCategory);
        }

        // POST: AssestCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AssestCategories == null)
            {
                return Problem("Entity set 'MyDBContext.AssestCategories'  is null.");
            }
            var assestCategory = await _context.AssestCategories.FindAsync(id);
            if (assestCategory != null)
            {
                _context.AssestCategories.Remove(assestCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool assestCategoryExists(int id)
        {
            return _context.AssestCategories.Any(e => e.Id == id);
        }

    }
}
