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
    public class DetailsModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public DetailsModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        public PlayerData PlayerData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            PlayerData = await _context.PlayerData.FirstOrDefaultAsync(m => m.ID == id);

            //if (PlayerData == null)
            //{
            //    return NotFound();
            //}
            return Page();
        }
    }
}
