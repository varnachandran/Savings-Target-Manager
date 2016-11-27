using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SavingsTarget.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

      
    }
}