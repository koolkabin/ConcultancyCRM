using ConcultancyCRM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace ConcultancyCRM.Controllers
{
    public class AssetsController : Controller
    {
        private readonly MyDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AssetsController(MyDBContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: Assets
        public async Task<IActionResult> Index()
        {
            var myDBContext = _context.Assets
            .Include(l => l.AssetsCategory)
            .Include(l => l.AssetsItemsAssigned)
                .ThenInclude(l => l.Employee)
                .ThenInclude(l => l.Department);
            return View(await myDBContext.ToListAsync());
        }
        // GET: Assets
        public async Task<IActionResult> Create()
        {
            ViewData["EmployeeName"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["DepartmentName"] = new SelectList(_context.Department, "Id", "Title");
            ViewData["CategoryName"] = new SelectList(_context.AssestCategories, "Id", "Title");
            return View();
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Assets assets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assets);
        }

        //GET: Assets/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assets == null)
            {
                return NotFound();
            }

            var assets = await _context.Assets
     .Include(l => l.AssetsCategory)
            .Include(l => l.AssetsItemsAssigned)
                .ThenInclude(l => l.Employee)
                .ThenInclude(l => l.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assets == null)
            {
                return NotFound();
            }

            return View(assets);
        }
        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assets == null)
            {
                return Problem("Entity set 'MyDBContext.Employees'  is null.");
            }
            var asset = await _context.Assets.FindAsync(id);
            if (asset != null)
            {
                _context.Assets.Remove(asset);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assets == null)
            {
                return NotFound();
            }

            var asset = await _context.Assets.Where(x => x.Id == id).Include(l => l.AssetsItemsAssigned).FirstOrDefaultAsync();
            if (asset == null)
            {
                return NotFound();
            }

            ViewData["EmployeeName"] = new SelectList(_context.Employees, "Id", "Name", asset.AssetsItemsAssigned.AssignedToId);
            /* ViewData["DepartmentName"] = new SelectList(_context.Department, "Id", "Title", asset.AssetsItemsAssigned.DepartmentId);*/
            ViewData["CategoryName"] = new SelectList(_context.AssestCategories, "Id", "Title", asset.AssetsCategoryId);
            return View(asset);
        }

        // POST: LeadInfoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Assets assets)
        {
            if (id != assets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Assets.Update(assets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetsExists(assets.Id))
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
            return View(assets);
        }
        //GET: Assets/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeadInfo == null)
            {
                return NotFound();
            }

            var assets = await _context.Assets
            .Include(l => l.AssetsCategory)
            .Include(l => l.AssetsItemsAssigned)
                .ThenInclude(l => l.Employee)
                .ThenInclude(l => l.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assets == null)
            {
                return NotFound();
            }

            return View(assets);
        }
        private bool AssetsExists(int id)
        {
            return _context.Assets.Any(e => e.Id == id);
        }

    }
}
