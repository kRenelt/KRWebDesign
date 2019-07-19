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
    public class IndexModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public IndexModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string KensString { get; set; }

        public IList<PlayerData> PlayerData { get;set; }
        public IList<PongHighScore> HighScoreList { get; set; }

        public async Task OnGetAsync()
        {

           // KensString[0] = "A";

            KensString = "KenCanDoIt";
            PlayerData = await _context.PlayerData.ToListAsync();
            HighScoreList = await _context.HighScorePong.ToListAsync();

            var ary = KensString.ToCharArray();
            Array.Reverse(ary);
            KensString = new string (ary);
           // var myString =
          //  KensString += ("Adding {0} Some thing{1}", KensString, 15);
            Console.WriteLine("Adding {0} Some thing{1}", KensString, 15);
            //KensString = KensString.Reverse(KensString);
        }

        public int GamesPlayed { get; set; }
        //public string KensString { get => KensString1; set => KensString1 = value; }
       // public string KensString1 { get => kensString; set => kensString = value; }

        public void ChangeGamesPlayed(int gamesPlayed)
        {
            GamesPlayed += gamesPlayed;
        }

        public async Task<IActionResult> OnPostAsync(int playGame)
        {
            Console.WriteLine("Adding {0} Some thing{1}", 12, 15);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var newProduct = new Cart()
            //{
            //    DateCreated = DateTime.Now,
            //    OwnerID = User.Identity.Name,
            //    Price = playGame,
            //    ItemsInToCart = 1
            //};

            //_context.Carts.Add(newProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
