
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using ProductCustomer.Models;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ProductCustomer.Controllers
{
    public class AccessController : Controller
    {


        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;



        public AccessController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }
       
           public IActionResult Dashboard()
        {
            return View();
        }



        public ActionResult AccessDenied()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["RedirectUrl"] = Url.Action("Dashboard", "Access", new { area = "" });


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser user = await _userManager.FindByNameAsync(model.username);
                if (user != null)
                {
                    
                    
                    SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (result.Succeeded) 
                    
                    {
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("", "incorrect username,password");
                    }
                
                }
                else
                {
                    ModelState.AddModelError("","invalid username ,Password");
                }

            }
            return View(model);
        }


        [HttpGet]
        public  ActionResult Register()
        {
         
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username,  firstname=model.firstname , lastName=model.lastname,Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Sign in the user
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    // Redirect to the dashboard page
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }


        //logout


        public  async Task<IActionResult> Logout()
        {
          await  _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Access");
        }


      //Adminstration
        public IActionResult AddAdmin()
        { 

            return View("Register");
        }


        //Add Admin To system
        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterViewModel newAcc)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = newAcc.Username, firstname = newAcc.firstname, lastName = newAcc.lastname, Email = newAcc.Email };
                var result = await _userManager.CreateAsync(user, newAcc.Password);

                if (result.Succeeded)
                {
                    // Add to Admin Role
                    await _userManager.AddToRoleAsync(user, "Admin");


                    //create cookie
                    await _signInManager.SignInAsync(user, false);


                    // Redirect to the dashboard page
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(newAcc);
        }
      
    }
}