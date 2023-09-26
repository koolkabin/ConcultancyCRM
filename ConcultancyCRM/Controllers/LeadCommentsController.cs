using ConcultancyCRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConcultancyCRM.Controllers
{
    [Authorize]
    public class LeadCommentsController : _ABSAuthenticatedController
    {
        private readonly MyDBContext _context;

        public LeadCommentsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: LeadComments
        public async Task<IActionResult> Index()
        {
            var myDBContext = _context.LeadComments.Include(l => l.Employee).Include(l => l.LeadInfo);
            return View(await myDBContext.ToListAsync());
        }

        // GET: LeadComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeadComments == null)
            {
                return NotFound();
            }

            var leadComments = await _context.LeadComments
                .Include(l => l.Employee)
                .Include(l => l.LeadInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leadComments == null)
            {
                return NotFound();
            }

            return View(leadComments);
        }

        // GET: LeadComments/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["LeadInfoId"] = new SelectList(_context.LeadInfo, "Id", "Id");
            return View();
        }

        // POST: LeadComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LeadInfoId,Status,TxnDate,EmployeeID,Description,EmpName")] LeadComments leadComments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leadComments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "Id", leadComments.EmployeeID);
            ViewData["LeadInfoId"] = new SelectList(_context.LeadInfo, "Id", "Id", leadComments.LeadInfoId);
            return View(leadComments);
        }

        // GET: LeadComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeadComments == null)
            {
                return NotFound();
            }

            var leadComments = await _context.LeadComments.FindAsync(id);
            if (leadComments == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "Id", leadComments.EmployeeID);
            ViewData["LeadInfoId"] = new SelectList(_context.LeadInfo, "Id", "Id", leadComments.LeadInfoId);
            return View(leadComments);
        }

        // POST: LeadComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LeadInfoId,Status,TxnDate,EmployeeID,Description,EmpName")] LeadComments leadComments)
        {
            if (id != leadComments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadComments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadCommentsExists(leadComments.Id))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "Id", leadComments.EmployeeID);
            ViewData["LeadInfoId"] = new SelectList(_context.LeadInfo, "Id", "Id", leadComments.LeadInfoId);
            return View(leadComments);
        }

        // GET: LeadComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeadComments == null)
            {
                return NotFound();
            }

            var leadComments = await _context.LeadComments
                .Include(l => l.Employee)
                .Include(l => l.LeadInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leadComments == null)
            {
                return NotFound();
            }

            return View(leadComments);
        }

        // POST: LeadComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeadComments == null)
            {
                return Problem("Entity set 'MyDBContext.LeadComments'  is null.");
            }
            var leadComments = await _context.LeadComments.FindAsync(id);
            if (leadComments != null)
            {
                _context.LeadComments.Remove(leadComments);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadCommentsExists(int id)
        {
            return _context.LeadComments.Any(e => e.Id == id);
        }
    }
}
