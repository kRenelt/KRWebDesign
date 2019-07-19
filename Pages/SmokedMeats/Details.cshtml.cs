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
    public class DetailsModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;
        public bool IsAdminUser { get; set; }

        public DetailsModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public Beef UserBeef { get; set; }

        private decimal Price { get; set; }
        private int ItemNumber { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (User.Identity.Name == "kennethfrenelt@lostmindsstudio.com")
                IsAdminUser = true;

            UserBeef = await _context.Beef.FirstOrDefaultAsync(m => m.ID == id);
            Price = UserBeef.Price;
            ItemNumber = UserBeef.ProductID;
            if (UserBeef == null)
            {
                return NotFound();
            }

           // if (!User.Identity.IsAuthenticated)
             //   alert("");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (UserBeef.Quantity > 0)
            {
                var newProduct = new Cart()
                {
                    DateCreated = DateTime.Now,
                    OwnerID = User.Identity.Name,
                    Price = (UserBeef.Price * UserBeef.Quantity),
                    ItemsInToCart = UserBeef.Quantity,
                    ProductID = UserBeef.ProductID
                };

                _context.Carts.Add(newProduct);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
