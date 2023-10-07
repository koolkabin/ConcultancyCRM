using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConcultancyCRM.Models;
using ConcultancyCRM.StaticHelpers;

namespace ConcultancyCRM.Controllers
{
    public class LeadInfoesController : _ABSAuthenticatedController
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
        public async Task<IActionResult> UnAssignedLeads()
        {
            return View(await _context.LeadInfo
                .Where(x => x.AssignedLeads == null)
                .ToListAsync());
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
            _context.Entry(leadInfo).Collection(x => x.AssignedLeads).Load();
            _context.Entry(leadInfo).Collection(x => x.LeadComments).Load();
            // Explicitly load the department for each child
            //foreach (var child in leadInfo.LeadComments)
            //{
            //    _context.Entry(child)
            //        .Reference(c => c.Employee)
            //        .Load();
            //}
            ViewBag.EmployeeId = _context.Employees.ToList();// new SelectList(_context.Employees.ToList(), "Id", "Name");
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
        public async Task<IActionResult> SaveComment(LeadComments Data)
        {
            var oldLead = _context.LeadInfo.Find(Data.LeadInfoId);
            if (oldLead == null)
            {
                throw new Exception("Invalid Old Lead.");
            }
            if (_ActiveSession.IsSalesRepresentative &&
                oldLead.AssignedLeads.Any() &&
                _ActiveSession.EmployeeId != oldLead
                    .AssignedLeads
                    .OrderBy(x => x.Id)
                    .Last()
                    .EmployeeId
                )
            {
                throw new Exception("Sales Representative can comment on leads they are assigned to.");
            }
            Data.EmployeeID = _ActiveSession.IsSuperAdmin ? Data.EmployeeID : _ActiveSession.EmployeeId;
            Data.EmpName = _ActiveSession.IsSuperAdmin ? "SuperAdmin" : _ActiveSession.EmpName;
            Data.TxnDate = DateTime.Now;
            oldLead.LeadComments.Add(Data);
            oldLead.LeadStatus = Data.Status;
            _context.Entry(oldLead).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = oldLead.Id });
        }
        public async Task<IActionResult> AssignLead(AssignedLeads Data)
        {
            try
            {
                var oldLead = _context.LeadInfo.Find(Data.LeadInfoId);
                if (oldLead == null)
                {
                    throw new Exception("Invalid Old Lead.");
                }
                if (!_ActiveSession.IsGeneralAdmin)
                {
                    throw new Exception("Permission Error. Logged in User should be General Admin");
                }
                //Data. = 0;
                Data.AssignedByName = _ActiveSession.UserName;
                Data.AssignedDate = DateTime.Now;

                oldLead.AssignedLeads.Add(Data);
                _context.Entry(oldLead).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                Data.Id = oldLead.Id;
                TempDataHelper.SetMsg(TempData, true, "Lead Assigned Successfully");

            }
            catch (Exception ex)
            {
                TempDataHelper.SetMsg(TempData, false, ex.Message);
            }
            return RedirectToAction("Details", new { id = Data.Id });
        }
    }
}
