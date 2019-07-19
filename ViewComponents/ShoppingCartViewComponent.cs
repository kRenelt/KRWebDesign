using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KRWebDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KRWebDesign.Pages.Components.ShoppingCart
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly KRWebDesignContext _context;

        public ShoppingCartViewComponent(KRWebDesignContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var items = await _context.Carts.ToListAsync();
            var userName = (!User.Identity.IsAuthenticated) ? "Guest" : User.Identity.Name;
            
            var  UserCarts = await GetItemsAsync(userName);
   
            var guestData = new PlayerData()
            {
                GamerName = "Guest",
                GamerLevel = 0,
                TotalGems = 0
            };

            var guestCart = new Cart()
            {
                CartID = "Guest",
                DateCreated = DateTime.Now,
                OwnerID = "Guest",
                ItemsInToCart = 0,
                Price = 0
            };

            var playerData = new PlayerData();

            if (!User.Identity.IsAuthenticated)
            {
                playerData = guestData;
                UserCarts.Add(guestCart);
            }
            else
            {
                playerData = await GetPlayerDataAsync(User.Identity.Name);
            }
            var shoppingCart = new ShoppingCartModel()
            {
                UserCart = UserCarts,
                UserPlayerData = playerData
               
             };

            return View("Default", shoppingCart);
        }

        private Task<PlayerData> GetPlayerDataAsync(string userName)
        {
            return _context.PlayerData.Where(x => x.PlayerID == userName).SingleAsync();
        }

        private Task<List<Cart>> GetItemsAsync(string userName)
        {
            return _context.Carts.Where(x => x.OwnerID == userName).ToListAsync();
        }
    }
}
