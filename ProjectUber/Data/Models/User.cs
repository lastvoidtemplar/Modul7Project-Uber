using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Configuration;

namespace Data.Models
{
    public class User
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Firstname is too long!")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Lastname is too long!")]
        public string LastName { get; set; }
        [Required]
        [Range(typeof(int),"14","120")]
        public int Age { get; set; }
        [DefaultValue(0)]
        public int CountOrders { get; set; }
        public override string ToString()
        {
            string result = "User:\n";
            result += $"First name: {FirstName}\n";
            result += $"Last name: {LastName}\n";
            result += $"Age: {Age}";
            return result;
        }     
    }
}
