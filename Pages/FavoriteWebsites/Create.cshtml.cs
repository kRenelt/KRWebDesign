using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KRWebDesign.Models;

namespace KRWebDesign.Pages.FavoriteWebsites
{
    public class CreateModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public CreateModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FavoriteWebSites FavoriteWebSites { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            FavoriteWebSites.OwnerID = User.Identity.Name;
            _context.FavoriteWebSites.Add(FavoriteWebSites);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}