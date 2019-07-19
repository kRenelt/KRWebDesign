using System.ComponentModel.DataAnnotations;

namespace KRWebDesign.Models
{
    public class Cart
    {
        [Key]
        public int ID { get; set; }
        public string ItemID { get; set; }
        public string CartID { get; set; }
        public decimal Price { get; set; }
        public int ItemsInToCart { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string OwnerID { get; set; }
        public int ProductID { get; set; }
    }
}
