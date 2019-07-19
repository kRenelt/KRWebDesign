using KRWebDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KRWebDesign.ViewComponents
{
    public class PriorityListViewComponent : ViewComponent
    {
        private readonly KRWebDesignContext db;

        [BindProperty(SupportsGet = true)]
        public string Balls { get; set; }

        public PriorityListViewComponent(KRWebDesignContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
             var items = await GetItemsAsync();
      
            return View("Default", items);
        }

        private Task<List<Cart>> GetItemsAsync()
        {
            return db.Carts.Where(x => x.OwnerID == User.Identity.Name).ToListAsync();
        }
    }
}