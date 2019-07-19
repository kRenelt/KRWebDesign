
using System.ComponentModel.DataAnnotations;


namespace KRWebDesign.Models
{
    public class FavoriteSite
    {
        public int ID { get; set; }
        public string SiteURL { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }
        public string Category { get; set; }
    }
}
