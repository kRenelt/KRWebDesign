using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KRWebDesign.Models;

namespace KRWebDesign.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public DeleteModel(KRWebDesign.Models.KRWebDesignContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlayerData = await _context.PlayerData.FindAsync(id);

            if (PlayerData != null)
            {
                _context.PlayerData.Remove(PlayerData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
