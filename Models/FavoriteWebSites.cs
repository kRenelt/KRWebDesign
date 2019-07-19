
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KRWebDesign.Models
{
    public class FavoriteWebSites
    {
        public int ID { get; set; }
      
        public string Category { get; set; }
        [Range(1, 10)]
        [Display(Name ="Rank")]
        public int Rating { get; set; }
        public string OwnerID { get; set; }// userID that created email
        
        public ICollection<FavoriteSite> SiteAddress { get; set; }   
    }
}
