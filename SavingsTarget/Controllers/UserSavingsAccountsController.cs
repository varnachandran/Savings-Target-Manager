using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;
using SavingsTarget.Models;

namespace SavingsTarget.Controllers
{
    public class UserSavingsAccountsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private string _userId;

        public UserSavingsAccountsController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            _userId = User.Identity.GetUserId();
        }
        // GET: SavingsAccounts
        public ActionResult Index()
        {
            if (_userId == null)
                return RedirectToAction("Login", "Account");
            var savings = _context.UserSavingsAccounts.ToList().FindAll(sav => sav.UserId == _userId);

            return View(savings);
        }

        
        // GET: SavingsAccounts/Create
        public ActionResult Deposit()
        {
            if (_userId == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        // POST: SavingsAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit([Bind(Include = "UserId,Balance,Date,Deposit")] UserSavingsAccount userSavingsAccount)
        {
            if (_userId == null)
                return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
            
                return View(userSavingsAccount);
            userSavingsAccount.UserId = _userId;
            userSavingsAccount.Date=DateTime.Now;
            userSavingsAccount.Balance = userSavingsAccount.Deposit+_context.UserSavingsAccounts.ToList().FindAll(sav => sav.UserId == _userId).Sum(item => item.Deposit);
            _context.UserSavingsAccounts.Add(userSavingsAccount);
            _context.SaveChanges();
            return RedirectToAction("Index");
         
            
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
