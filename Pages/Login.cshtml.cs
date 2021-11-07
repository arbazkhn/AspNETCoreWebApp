using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.ViewModels;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login Model{ get; set; }
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl=null)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await signInManager.PasswordSignInAsync(Model.Email,Model.Password,Model.RememberMe,false);
                if (identityResult.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("MainApp");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }

                
                ModelState.AddModelError("", "Username or Password is incorrect.");
            }
            return Page();
            
        }
    }
}
