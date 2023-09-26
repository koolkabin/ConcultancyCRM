using ConcultancyCRM.Extensions;
using ConcultancyCRM.Models;
using ConcultancyCRM.StaticHelpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace ConcultancyCRM.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly MyDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        public AccountController(ILogger<AccountController> logger, MyDBContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration
            )
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {

                var user = await _userManager.FindByEmailAsync(username);
                if (user == null)
                {
                    throw new Exception("Invalid User/Password.");
                }
                var checkRes = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (!checkRes.Succeeded)
                {
                    throw new Exception("Invalid User/Password.");
                }
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                var result = new SessionInfo
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    AssociatedRoles = userRoles,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };


                //find related user
                _context.Entry(user).Reference(x => x.AppUserEmployeeInfo).Load();
                if (user.AppUserEmployeeInfo != null)
                {
                    var relEmp = _context.Employees.Find(user.AppUserEmployeeInfo.EmployeeId);
                    if (relEmp != null)
                    {
                        result.EmployeeId = relEmp.Id;
                        result.EmpName = relEmp.Name;
                    }
                }
                HttpContext.SetMessage(true, "Login Successful.");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                HttpContext.SetMessage(false, ex.Message);
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        public async Task<IActionResult> InstallApplciation()
        {
            try
            {
                foreach (var item in Enum.GetValues(typeof(enumUserType)))
                {
                    if (!await _roleManager.RoleExistsAsync(item.ToString()))
                    {
                        await _roleManager.CreateAsync(new IdentityRole() { Name = item.ToString() });
                    }
                }
                var supUser = await _userManager.FindByEmailAsync("superadmin@gmail.com");
                if (supUser == null)
                {
                    var res = await _userManager.CreateAsync(new ApplicationUser()
                    {
                        Email = "superadmin@gmail.com",
                        UserName = "superadmin@gmail.com",
                        Id = Guid.NewGuid().ToString(),
                        IsActive = true,
                        IsDeleted = false,
                        UserType = enumUserType.SuperAdmin,
                        RegisteredDate = DateTime.UtcNow
                    });
                    if (res != null && res.Succeeded)
                    {
                        var uRec = await _userManager.FindByEmailAsync("superadmin@gmail.com");
                        var pres = await _userManager.AddPasswordAsync(uRec, "Admin@123");
                        await _userManager.AddToRolesAsync(uRec,
                            new string[] {
                                enumUserType.SuperAdmin.ToString(),
                                enumUserType.GeneralAdmin.ToString()
                            });
                    }
                    else
                    {
                        throw new Exception("Error while creating user...");
                    }
                }

                return Content("Installation Completed.");
            }
            catch (Exception ex)
            {
                return Content("Installation Failed with error: " + ex.Message);
            }
        }
    }
}