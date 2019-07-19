using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KRWebDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KRWebDesign.Pages.Shared.Components.ShoppingCart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly KRWebDesignContext _context;
        public CartViewComponent(KRWebDesignContext context)
        {
            _context = context;
        }

       // public int CartItems { get; set; }
       // public string Price { get; set; }
      //  public int ItemsInCart { get; set; }

        public IViewComponentResult
            Invoke(int itemsInCart)
        {
            return View("Default", itemsInCart);
        }

        //public void OnGet()
        //{
        //    if (User.Identity.Name != "")
        //    {
        //        GetItemsAsync();// _context.Carts.Where(x => x.OwnerID == User.Identity.Name).ToListAsync();
        //    }
        //    else
        //    {
        //        var myCart = new Cart()
        //        {
        //            OwnerID = "Guest",
        //            ItemsInToCart = 0,
        //            DateCreated = DateTime.Now,
        //            Price = 0
        //        };
        //    }
        //}


        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var items = await GetItemsAsync();
        //    return View(items);
        //}

        //private Task<List<Cart>> GetItemsAsync()
        //{
        //    return _context.Carts.Where(x => x.OwnerID == User.Identity.Name).ToListAsync();
        //}
    }
}