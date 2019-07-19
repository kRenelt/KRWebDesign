using System;
using System.Collections.Generic;
using System.Linq;
using KRWebDesign.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KRWebDesign.Logic
{
    public class ShoppingCartAction : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public string ShoppingCartId { get; set; }

        public ShoppingCartAction(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           

            if (User.Identity.Name != "")
                ShoppingCartId = User.Identity.Name;

            var cartItem = _context.Carts.SingleOrDefault(
                c => c.OwnerID == ShoppingCartId
                && c.ID == id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new Cart
                {
                    ItemID = Guid.NewGuid().ToString(),
                    CartID = ShoppingCartId,
                    ItemsInToCart = 1,
                    DateCreated = DateTime.Now
                };

                _context.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.ItemsInToCart++;
            }
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
               // _context = null;
            }
        }

        public List<Cart> GetCartItems()
        {
            return _context.Carts.Where(
                c => c.OwnerID == ShoppingCartId).ToList();
        }
    }
}
