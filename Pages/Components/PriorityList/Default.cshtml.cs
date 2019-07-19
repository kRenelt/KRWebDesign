using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KRWebDesign.Models;

namespace KRWebDesign.Pages.Components.PriorityList
{
    public class DefaultModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

       // [BindProperty(SupportsGet = true)]
       // private int ItemsInCart { get; set; }
       // public Cart cart { get; set; }
        public DefaultModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;

        }

        public void OnGet()
        {
            //var UserCart = _context.Carts.Where(c => c.OwnerID == User.Identity.Name).ToList();
            //foreach (Cart theseCarts in UserCart)
            //{
            //    if(theseCarts.OwnerID == User.Identity.Name)
            //    {
            //        ItemsInCart++;
            //    }
            //}
        }
    }
}