using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KRWebDesign.Pages
{
    public class IndexModel : PageModel
    {
        protected UserManager<ApplicationIdentity> UserManager { get; set; }

        public string UserId { get; set; }

        public void OnGet()
        {
            UserId = (User.Identity.Name != null) ? User.Identity.Name : "";
        }
    }
}
