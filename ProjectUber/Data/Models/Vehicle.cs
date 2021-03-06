using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Vehicle
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Vehicle Model is too long!")]
        public string Model { get; set; }
        [DefaultValue(100)]
        public int HorsePower { get; set; }
        public override string ToString()
        {
            string result = "Vehicle:\n";
            result += $"Model: {Model}";
            return result;
        }
    }
}
