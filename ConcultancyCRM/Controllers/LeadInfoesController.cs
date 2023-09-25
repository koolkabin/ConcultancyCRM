using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConcultancyCRM.Models;

namespace ConcultancyCRM.Controllers
{
    public class LeadInfoesController : Controller
    {
        private readonly MyDBContext _context;

        public LeadInfoesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: LeadInfoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.LeadInfo.ToListAsync());
        }

        // GET: LeadInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeadInfo == null)
            {
                return NotFound();
            }

            var leadInfo = await _context.LeadInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leadInfo == null)
            {
                return NotFound();
            }

            return View(leadInfo);
        }

        // GET: LeadInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeadInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TxnDate,LeadSource,AgentName,CandidateFirstName,CandidateLastName,PhoneNo,EmailID,Country,City,Result,VendorName,VendorID,ExamCode,ExamName,ExamDate,ExamMonth,ExamYear,ExamType,CenterName,CenterAddress,CenterCountry,CenterPhoneNo,CreditCard,Currency,PaidFeeAmount,VoucherNumber,Delivery")] LeadInfo leadInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leadInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leadInfo);
        }

        // GET: LeadInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeadInfo == null)
            {
                return NotFound();
            }

            var leadInfo = await _context.LeadInfo.FindAsync(id);
            if (leadInfo == null)
            {
                return NotFound();
            }
            return View(leadInfo);
        }

        // POST: LeadInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TxnDate,LeadSource,AgentName,CandidateFirstName,CandidateLastName,PhoneNo,EmailID,Country,City,Result,VendorName,VendorID,ExamCode,ExamName,ExamDate,ExamMonth,ExamYear,ExamType,CenterName,CenterAddress,CenterCountry,CenterPhoneNo,CreditCard,Currency,PaidFeeAmount,VoucherNumber,Delivery")] LeadInfo leadInfo)
        {
            if (id != leadInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadInfoExists(leadInfo.Id))
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
            return View(leadInfo);
        }

        // GET: LeadInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeadInfo == null)
            {
                return NotFound();
            }

            var leadInfo = await _context.LeadInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leadInfo == null)
            {
                return NotFound();
            }

            return View(leadInfo);
        }

        // POST: LeadInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeadInfo == null)
            {
                return Problem("Entity set 'MyDBContext.LeadInfo'  is null.");
            }
            var leadInfo = await _context.LeadInfo.FindAsync(id);
            if (leadInfo != null)
            {
                _context.LeadInfo.Remove(leadInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadInfoExists(int id)
        {
          return _context.LeadInfo.Any(e => e.Id == id);
        }
    }
}
