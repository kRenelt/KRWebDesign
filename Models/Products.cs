using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KRWebDesign.Models
{
    public class Products
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Flavor { get; set; }
        public string OwnerID { get; set; }
        public int ItemId { get; set; }
    }
}
