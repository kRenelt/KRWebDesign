using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KRWebDesign.Models
{
    public class PlayerData
    {
        public int ID { get; set; }
        public string PlayerID { get; set; }
        public int TriesPerDay { get; set; }
        public DateTime LastAttemptedPlay { get; set; }
        [Display(Name = "Gamer Name")]
        public string GamerName { get; set; }
        public int GamerLevel { get; set; }
        public int GamePlaysToDate { get; set; }
        public int TotalGems { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime Birthday { get; set; }
    }
}
