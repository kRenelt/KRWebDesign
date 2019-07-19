using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KRWebDesign.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KRWebDesign.Pages.SmokedMeats
{
    public class IndexModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public IndexModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        public IList<Products> Products { get;set; }
        public IList<Beef> Beef { get; set; }
        public Cart UserCart { get; set; }
        public List<Cart> UserCartList { get; set; }
        public bool IsLoggedIn { get; set; }
        public string PriceSort { get; set; }
        public string QuantitiySort { get; set; }
        public PlayerData PlayerDataTabel { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }//search string

        [BindProperty(SupportsGet = true)]
        public int Gems { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Ranking { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FlavorSort { get; set; }//search string

        [BindProperty(SupportsGet = true)]
        public string MeatFlavor { get; set; }//MovieGenre

        public SelectList FlavorList { get; set; }// Genres
       
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string SearchFilter { get; set; }
        public bool IsAdminUser { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CartItems { get; set; }


        [BindProperty(SupportsGet = true)]
        public decimal CartPrice { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            if (User.Identity.IsAuthenticated)
            {
                IsLoggedIn = true;
                PlayerDataTabel = await _context.PlayerData.SingleOrDefaultAsync(c => c.PlayerID == User.Identity.Name);
                // var gameName = from p in _context.PlayerData select p.GamerName;
                // PlayerDataTabel = _context.PlayerData.Single(c => c.GamerName == User.Identity.Name);
                if (PlayerDataTabel != null)
                    UserName = PlayerDataTabel.GamerName;
            }
            else
                UserName = "Guest";

            if (User.Identity.Name == "kennethfrenelt@lostmindsstudio.com")
                IsAdminUser = true;

            IQueryable<string> flavorSearch = from m in _context.Beef
                                              orderby m.Flavor
                                              select m.Flavor;

            PriceSort = String.IsNullOrEmpty(sortOrder) ? "price_sort" : "";
            QuantitiySort = sortOrder == "Quantity" ? "quantity_sort" : "Quantity";
            FlavorSort = sortOrder == "Flavor" ? "flavor_sort" : "Flavor";
            SearchFilter = searchString;

            IQueryable<Beef> beefList = from s in _context.Beef select s;

            IQueryable<Cart> cartList = from z in _context.Carts select z;

            if (User.Identity.Name != "")
            {
                cartList = cartList.Where(c => c.OwnerID == User.Identity.Name);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                beefList = beefList.Where(s => s.Flavor.Contains(searchString) ||
                    s.TypeOfMeat.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(MeatFlavor))
            {
                beefList = beefList.Where(s => s.Flavor == MeatFlavor);
            }

            switch(sortOrder)
            {
                case "price_sort":
                    beefList = beefList.OrderByDescending(s => s.Price);
                    break;    
                case "Flavor":
                    beefList = beefList.OrderBy(s => s.Flavor);
                    break;
                case "flavor_sort":
                    beefList = beefList.OrderByDescending(s => s.Flavor);
                    break;
                case "Quantity":
                    beefList = beefList.OrderBy(s => s.Quantity);
                    break;
                case "quantity_sort":
                    beefList = beefList.OrderByDescending(s => s.Quantity);
                    break;
                default:
                    beefList = beefList.OrderBy(s => s.Price);
                    break;
            }

            FlavorList = new SelectList(await flavorSearch.Distinct().ToListAsync());
            Beef = await beefList.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(Cart product)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newProduct = new Cart()
            {
                DateCreated = DateTime.Now,
                OwnerID = User.Identity.Name,
                Price = product.Price,
                ItemsInToCart = 1
            };

            _context.Carts.Add(newProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
