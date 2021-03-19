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
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [DefaultValue(0.70)]
        public decimal Price { get; set; }
        /// <summary>
        /// Foreign Key connected with table UserProfiles
        /// </summary>
        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public UserProfile UserProfile { get; set; }
        /// <summary>
        /// Foreign Key connected with table DriverProfiles
        /// </summary>
        [ForeignKey("DriverProfile")]
        public int DriverProfileId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public DriverProfile DriverProfile { get; set; }
        /// <summary>
        /// Foreign Key connected with table Towns
        /// </summary>
        [ForeignKey("Town")]
        public int TownId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public Town Town { get; set; }


    }
}
