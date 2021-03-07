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
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Firstname is too long!")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Lastname is too long!")]
        public string LastName { get; set; }
        [Required]
        [Range(typeof(int), "18", "70")]
        public int Age { get; set; }
        [DefaultValue(0)]
        public int CountOrders { get; set; }
        [Required]
        [DefaultValue(3)]
        public float Rating { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public override string ToString()
        {
            string result = "Driver:\n";
            result += $"First name: {FirstName}\n";
            result += $"Last name: {LastName}\n";
            result += $"Age: {Age}\n";
            result += $"Rating: {Rating}\n";
            result += Vehicle.ToString();
            return result;
        }
    }
}
