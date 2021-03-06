using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [DefaultValue(0.70)]
        public decimal Price { get; set; }
        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        [ForeignKey("DriverProfile")]
        public int DriverProfileId { get; set; }
        public DriverProfile DriverProfile { get; set; }
        [ForeignKey("Town")]
        public int TownId { get; set; }
        public Town Town { get; set; }


    }
}
