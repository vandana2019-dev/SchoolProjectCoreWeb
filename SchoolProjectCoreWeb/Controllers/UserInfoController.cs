using DataRepository.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SchoolProjectCoreWeb.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserInfoController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserDataModel userDataModel)
        {
            var user = new IdentityUser
            {
                UserName = userDataModel.EmailAddress,
                Email = userDataModel.EmailAddress,
            };
            var identityResult = await _userManager.CreateAsync(user, userDataModel.Password);
            if (identityResult.Succeeded)
            {
                var role = new IdentityRole("Admin");

                var roleResult = await _roleManager.CreateAsync(role);
                if (roleResult.Succeeded)
                {
                    var existingUser = await _userManager.FindByEmailAsync(userDataModel.EmailAddress);
                    if (existingUser != null)
                    {
                        await _userManager.AddToRoleAsync(existingUser, "Admin");
                    }
                }
                TempData["Success"] = "User created";
            }
            else
            {

                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                  
                }
                
            }
            return View();

        }
    }
}
