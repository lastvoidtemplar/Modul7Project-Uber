using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Town
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name is too long!")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name is too long!")]
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public override string ToString()
        {
            string result = "Town: \n";
            result += $"Name: {Name}";
            return result; ;
        }
    }
}
