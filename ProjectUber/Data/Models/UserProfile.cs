﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Username is too short!")]
        [MaxLength(50, ErrorMessage = "Username is too long!")]
        public string Username { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password is too short!")]
        [MaxLength(50, ErrorMessage = "Password is too long!")]
        public string Password { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}