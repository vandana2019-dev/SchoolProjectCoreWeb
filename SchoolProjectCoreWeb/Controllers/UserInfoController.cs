using DataRepository.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SchoolProjectCoreWeb.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserInfoController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
            if(identityResult.Succeeded)
            {
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
