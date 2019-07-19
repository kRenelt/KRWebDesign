using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KRWebDesign.Models;

namespace KRWebDesign.Pages.FavoriteWebsites
{
    public class DetailsModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public DetailsModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

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
    }
}
