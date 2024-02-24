// Licensierad till .NET Foundation under en eller flera avtal.
// .NET Foundation licensierar denna fil till dig under MIT-licensen.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Projekt.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChangePasswordModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        /// <summary>
        ///     Detta API stödjer ASP.NET Core Identity standard UI infrastruktur och är inte avsedd att användas
        ///     direkt från din kod. Detta API kan ändras eller tas bort i framtida utgåvor.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     Detta API stödjer ASP.NET Core Identity standard UI infrastruktur och är inte avsedd att användas
        ///     direkt från din kod. Detta API kan ändras eller tas bort i framtida utgåvor.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     Detta API stödjer ASP.NET Core Identity standard UI infrastruktur och är inte avsedd att användas
        ///     direkt från din kod. Detta API kan ändras eller tas bort i framtida utgåvor.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     Detta API stödjer ASP.NET Core Identity standard UI infrastruktur och är inte avsedd att användas
            ///     direkt från din kod. Detta API kan ändras eller tas bort i framtida utgåvor.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Nuvarande lösenord")]
            public string OldPassword { get; set; }

            /// <summary>
            ///     Detta API stödjer ASP.NET Core Identity standard UI infrastruktur och är inte avsedd att användas
            ///     direkt från din kod. Detta API kan ändras eller tas bort i framtida utgåvor.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "Lösenordet {0} måste vara minst {2} och max {1} tecken långt.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Nytt lösenord")]
            public string NewPassword { get; set; }

            /// <summary>
            ///     Detta API stödjer ASP.NET Core Identity standard UI infrastruktur och är inte avsedd att användas
            ///     direkt från din kod. Detta API kan ändras eller tas bort i framtida utgåvor.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Bekräfta nytt lösenord")]
            [Compare("NewPassword", ErrorMessage = "Det nya lösenordet och bekräftelselösenordet matchar inte.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Kunde inte ladda användare med ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Kunde inte ladda användare med ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("Användaren har framgångsrikt ändrat sitt lösenord.");
            StatusMessage = "Ditt lösenord har ändrats.";

            return RedirectToPage();
        }
    }
}
