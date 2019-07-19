using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KRWebDesign.Models;
using Microsoft.AspNetCore.Authorization;

namespace KRWebDesign.Pages.SmokedMeats
{
   // [Authorize(Roles = "Administrator")]
    public class CreateModel : PageModel
    {
        
        public float[] QuantityTags = new float[] { 0.25f, 0.50f, 0.75f, 1.0f };

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
        public Beef Beef { get; set; }
        
        public decimal Quantity { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Beef.Add(Beef);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}