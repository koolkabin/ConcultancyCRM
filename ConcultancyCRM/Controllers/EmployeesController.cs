using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConcultancyCRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ConcultancyCRM.Controllers
{
    [Authorize]
    public class EmployeesController : _ABSAuthenticatedController
    {
        private readonly MyDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public EmployeesController(MyDBContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        private async Task<ApplicationUser> CreateRelatedIdentityUser(VMEmployeeCreate Data)
        {
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString(), UserName = Data.Email, Email = Data.Email, UserType = enumUserType.SalesRepresentative };
            var result = await _userManager.CreateAsync(user, Data.Password);

            if (result.Succeeded)
            {
                ApplicationUser oldUser = await _userManager.FindByEmailAsync(Data.Email);
                if (oldUser == null)
                {
                    throw new Exception("Identity user Creation Failed.");
                }
                if (Data.IsAdmin)
                {
                    await _userManager.AddToRoleAsync(oldUser, enumUserType.GeneralAdmin.ToString());
                }
                if (Data.IsSalesRepresentative)
                {
                    await _userManager.AddToRoleAsync(oldUser, enumUserType.SalesRepresentative.ToString());
                }
                return oldUser;
            }
            else
            {
                // Handle other user creation failure scenarios, if needed
                string allErrMsg = string.Join(",", result.Errors.Select(x => x.Description).ToArray());
                throw new Exception("User creation failed. " + allErrMsg);
            }
        }
        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VMEmployeeCreate employee)
        {
            if (ModelState.IsValid)
            {
                var uData = await CreateRelatedIdentityUser(employee);
                _context.Add(employee);
                await _context.SaveChangesAsync();
                await MapRelatedUserEmpInfo(employee, uData);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        private async Task MapRelatedUserEmpInfo(VMEmployeeCreate employee, ApplicationUser uData)
        {
            _context.AppUserEmployees.Add(new AppUserEmployeeInfo()
            {
                UserId = uData.Id,
                EmployeeId = employee.Id
            });
            await _context.SaveChangesAsync();
        }
        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            var VMemp = new VMEmployeeCreate();
            VMemp.Name = employee.Name;
            VMemp.Id = employee.Id; 
            VMemp.Address = employee.Address;
            VMemp.Mobile = employee.Mobile;
            VMemp.Email = employee.Email;   
            VMemp.Status = employee.Status;
            VMemp.Deleted = employee.Deleted;
            VMemp.JoinDate = employee.JoinDate; 
            VMemp.UserId = employee.UserId;
            VMemp.IsAdmin   = employee.IsAdmin;
            VMemp.IsSalesRepresentative = employee.IsSalesRepresentative;
            VMemp.Password = null;
            if (employee == null)
            {
                return NotFound();
            }
            return View(VMemp);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VMEmployeeCreate employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'MyDBContext.Employees'  is null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
