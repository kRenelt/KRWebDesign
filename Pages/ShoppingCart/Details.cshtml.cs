using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KRWebDesign.Models;

namespace KRWebDesign.Pages.ShoppingCart
{
    public class DetailsModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public DetailsModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        public Cart Cart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Carts.FirstOrDefaultAsync(m => m.ID == id);

            if (Cart == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
