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
    public class IndexModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public Cart ShoppingCart { get; set; }

        public IndexModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        public IList<Cart> Cart { get;set; }

        public async Task OnGetAsync()
        {
          //  Cart = await _context.Carts.ToListAsync();
           // ShoppingCart = Cart[0];
        
            Cart = await GetItemsAsync();

            //return View("Default", items);

        }

        private Task<List<Cart>> GetItemsAsync()
        {
            return _context.Carts.Where(x => x.OwnerID == User.Identity.Name).ToListAsync();
        }
    }
}
