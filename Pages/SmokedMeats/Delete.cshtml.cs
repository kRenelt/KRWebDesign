using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KRWebDesign.Models;

namespace KRWebDesign.Pages.SmokedMeats
{
    public class DeleteModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public DeleteModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Beef BeefObject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BeefObject = await _context.Beef.FirstOrDefaultAsync(m => m.ID == id);

            if (BeefObject == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BeefObject = await _context.Beef.FindAsync(id);

            if (BeefObject != null)
            {
                _context.Beef.Remove(BeefObject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
