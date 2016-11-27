using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SavingsTarget.Models
{
    public class UserSavingsAccount
    {
        
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }
        public decimal Deposit { get; set; }
        
    }
}