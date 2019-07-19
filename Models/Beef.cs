using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KRWebDesign.Models
{
    public class Beef
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Flavor { get; set; }
        public string TypeOfMeat { get; set; }
        public int ProductID { get; set; }
    }
}
