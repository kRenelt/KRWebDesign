using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KRWebDesign.Models;

namespace KRWebDesign.Pages.FavoriteWebsites
{
    public class EditModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public EditModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FavoriteWebSites FavoriteWebSites { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FavoriteWebSites = await _context.FavoriteWebSites.FirstOrDefaultAsync(m => m.ID == id);

            if (FavoriteWebSites == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

          //  var siteToUpdate = await _context.FavoriteWebSites.FindAsync(id);

            _context.Attach(FavoriteWebSites).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteWebSitesExists(FavoriteWebSites.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FavoriteWebSitesExists(int id)
        {
            return _context.FavoriteWebSites.Any(e => e.ID == id);
        }
    }
}
