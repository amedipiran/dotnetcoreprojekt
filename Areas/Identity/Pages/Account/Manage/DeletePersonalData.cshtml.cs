// Licensierad till .NET Foundation under ett eller flera avtal.
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
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;

        public DeletePersonalDataModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<DeletePersonalDataModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        /// <summary>
        ///     Detta API stöder ASP.NET Core Identity standard UI infrastruktur och är inte avsedd att användas
        ///     direkt från din kod. Detta API kan ändras eller tas bort i framtida utgåvor.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     Detta API stöder ASP.NET Core Identity standard UI infrastruktur och är inte avsedd att användas
        ///     direkt från din kod. Detta API kan ändras eller tas bort i framtida utgåvor.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     Detta API stöder ASP.NET Core Identity standard UI infrastruktur och är inte avsedd att användas
            ///     direkt från din kod. Detta API kan ändras eller tas bort i framtida utgåvor.
            /// </summary>
            [Required(ErrorMessage = "Lösenordet är obligatoriskt.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        /// <summary>
        ///     Detta API stöder ASP.NET Core Identity standard UI infrastruktur och är inte avsedd att användas
        ///     direkt från din kod. Detta API kan ändras eller tas bort i framtida utgåvor.
        /// </summary>
        public bool RequirePassword { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Kunde inte ladda användare med ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Kunde inte ladda användare med ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            if (RequirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(user, Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "Felaktigt lösenord.");
                    return Page();
                }
            }

            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Ett oväntat fel inträffade vid radering av användaren.");
            }

            await _signInManager.SignOutAsync();

            _logger.LogInformation("Användare med ID '{UserId}' har raderat sig själv.", userId);

            return Redirect("~/");
        }
    }
}
