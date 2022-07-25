using PortalDAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalBL.Models;
using System.Diagnostics;

namespace PortalPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Login||LogOut
       public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {

           // var userName = await userManager.FindByNameAsync(model.UserName);
            var userEmail = await userManager.FindByEmailAsync(model.Email);

            dynamic result;




                if (userEmail != null)
                {
                    result = await signInManager.PasswordSignInAsync(userEmail, model.Password, model.RemmberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("", "Invalid UserName Or Password");

                    }
                }

                
                else
                {
                    ModelState.AddModelError("", "Invalid UserName Or Password");

                }
           
         

            return View(model);
        }


        //        public async Task<IActionResult> Login(LoginVM model)
        //{

        //            //if (model.UserName!=null)
        //{
        // res = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RemmberMe, false);
        //    if (res.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Invalid UserName Or Password");
        //    }

        //}
        //else if(model.Email!=null)
        //{

        //res = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemmberMe, false);
        //    if (res.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Invalid UserName Or Password");
        //    }
        //}



        //   var userName = await userManager.FindByNameAsync(model.Email);

        //    try
        //    {
        //        var userEmail = await userManager.FindByEmailAsync(model.Email);

        //        dynamic result = "";

        //        if (userEmail != null)
        //        {
        //            result = await signInManager.PasswordSignInAsync(userEmail, model.Password, model.RemmberMe, false);
        //        }
        //        //else
        //        //{
        //        //    result = await signInManager.PasswordSignInAsync(userName, model.Password, model.RemmberMe, false);
        //        //}

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Invalid UserName Or Password");
        //        }
        //    }

        //      catch (Exception)
        //    {
        //            ModelState.AddModelError("", "Invalid UserName Or Password");



        //    }



        //    return View(model);
        //}
       
        public async  Task<IActionResult> LogOut()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("Login");

        }


        #endregion


        #region SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM model)
        {
            try
            {
               
                    var user = new ApplicationUser()
                    {
                        UserName = model.Name,
                        Email = model.Email,
                        IsAgree=model.IsAccepted
                    };

                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                
            }
            catch (Exception)
            {

                throw;
            }

            return View(model);
        }
        #endregion

        #region Passwords_Operations

        public IActionResult ForgetPassword()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);

                var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                // MailSender.Mail("Password Reset", passwordResetLink);

                //logger.Log(LogLevel.Warning, passwordResetLink);
                EventLog log = new EventLog();
                log.Source = "Inventory System";
                log.WriteEntry(passwordResetLink, EventLogEntryType.Warning);

                return RedirectToAction("ConfirmForgetPassword");
            }

            return RedirectToAction("ConfirmForgetPassword");
        }


        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }
  

        public IActionResult ResetPassword(string? Email, string? Token)
        {
            if (Email != null && Token != null)
            {
                return View();
            }
            return RedirectToAction("ForgetPassword");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(RestPasswordVM model)
        {

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("ConfirmRestPassword");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

            return RedirectToAction("ConfirmResetPassword");
        }
        public IActionResult ConfirmRestPassword()
        {
            return View();
        }


        #endregion


        #region Erros
        [Route("/Account/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion
    }
}
