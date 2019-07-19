using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KRWebDesign.Models;
using Microsoft.AspNetCore.Authorization;

namespace KRWebDesign.Pages.FavoriteWebsites
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly KRWebDesign.Models.KRWebDesignContext _context;

        public IndexModel(KRWebDesign.Models.KRWebDesignContext context)
        {
            _context = context;
        }

        public IList<FavoriteWebSites> FavoriteWebSites { get;set; }
        public string SortAscend { get; set; }
        public string OwnerName { get; set; }

        public async Task OnGetAsync(string sortOrder, string ownerName)
        {
             IQueryable<FavoriteWebSites> favSite = from r in _context.FavoriteWebSites
                                                  select r;

            favSite = favSite.Where(s => s.OwnerID == User.Identity.Name);

            SortAscend = String.IsNullOrEmpty(sortOrder) ? "sort_desc" : "";


            if (sortOrder == "sort_desc")
            {
                favSite = favSite.OrderByDescending(r => r.Rating);
            }
            else
            {
                favSite = favSite.OrderByDescending(r => r.ID);
            }

            FavoriteWebSites = await favSite.AsNoTracking().ToListAsync();
        }

        public class TestyTest
        {
            
        }
    }
}
