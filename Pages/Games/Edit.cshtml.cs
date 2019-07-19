using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KRWebDesign.Models;

namespace KRWebDesign.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public EditModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PlayerData PlayerData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlayerData = await _context.PlayerData.FirstOrDefaultAsync(m => m.ID == id);

            if (PlayerData == null)
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

            _context.Attach(PlayerData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerDataExists(PlayerData.ID))
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

        private bool PlayerDataExists(int id)
        {
            return _context.PlayerData.Any(e => e.ID == id);
        }
    }
}
