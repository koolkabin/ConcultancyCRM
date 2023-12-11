using ConcultancyCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcultancyCRM.Controllers
{
    public class MyLeadInfoesController : _ABSAuthenticatedController
    {
        private readonly MyDBContext _context;

        public MyLeadInfoesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: LeadInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeadInfo
                .Where(x => x.AssignedLeads != null &&
                    x.AssignedLeads
                    .OrderBy(x => x.Id)
                    .LastOrDefault() != null &&
                    x.AssignedLeads
                    .OrderBy(x => x.Id)
                    .LastOrDefault()
                    .EmployeeId == _ActiveSession.EmployeeId)
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

            return View(leadInfo);
        }

        public async Task<IActionResult> SaveComment(LeadComments Data)
        {
            var oldLead = _context.LeadInfo.Find(Data.LeadInfoId);
            if (oldLead == null)
            {
                throw new Exception("Invalid Old Lead.");
            }

            if (!oldLead.CanComment(_ActiveSession))
            {
                throw new Exception("Permission Error. Sales representative not assigned");
            }

            Data.EmployeeID = _ActiveSession.EmployeeId;
            Data.EmpName = _ActiveSession.EmpName;
            Data.TxnDate = DateTime.Now;
            oldLead.LeadComments.Add(Data);
            oldLead.LeadStatus = Data.Status;
            _context.Entry(oldLead).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = Data.LeadInfo });
        }
        public async Task<IActionResult> AssignLead(AssignedLeads Data)
        {
            var oldLead = _context.LeadInfo.Find(Data.LeadInfoId);
            if (oldLead == null)
            {
                throw new Exception("Invalid Old Lead.");
            }
            //Data. = 0;
            Data.AssignedByName = _ActiveSession.UserName;
            Data.AssignedDate = DateTime.Now;

            oldLead.AssignedLeads.Add(Data);
            _context.Entry(oldLead).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = Data.LeadInfo });
        }
    }
}
