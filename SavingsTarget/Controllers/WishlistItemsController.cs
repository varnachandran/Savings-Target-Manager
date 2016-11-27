using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SavingsTarget.Models;
using System.Data.Entity;
using System.Net;

namespace SavingsTarget.Controllers
{
    public class WishlistItemsController : Controller
    {
        private ApplicationDbContext _context;
        private string _userId;

        public WishlistItemsController()
        {
            _context = new ApplicationDbContext();
        }
        

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            _userId = User.Identity.GetUserId();
           
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Items
        public ActionResult Index()
        {


            if (_userId == null)
                return RedirectToAction("Login", "Account");
            var items = _context.WishlistItems.ToList().FindAll(it => it.UserId == _userId);
            var balance= _context.UserSavingsAccounts.ToList().FindAll(sav => sav.UserId == _userId).Sum(item => item.Deposit);
            ViewBag.Balance = balance;
            ViewBag.TotalExpenses= _context.WishlistItems.ToList().FindAll(exp => exp.UserId == _userId).Sum(exp => exp.Value);
            
            
            return View(items);
        }
       
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Title,Value,Date,Description")] WishlistItem wishlistItem)
        {
            if (ModelState.IsValid)
            {
                wishlistItem.UserId = _userId;
                wishlistItem.Date = DateTime.Today;
                _context.WishlistItems.Add(wishlistItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wishlistItem);
        }

        // GET: Savings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (_userId == null)
                return RedirectToAction("Login", "Account");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishlistItem saving = _context.WishlistItems.Find(id);
            if (saving == null)
            {
                return HttpNotFound();
            }
            return View(saving);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Title,Value,Date,Description")] WishlistItem wishlistItem)
        {
            if (ModelState.IsValid)
            {
                wishlistItem.Date=DateTime.Today;
                
                _context.Entry(wishlistItem).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wishlistItem);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishlistItem wishlistItem = _context.WishlistItems.Find(id);
            if (wishlistItem == null)
            {
                return HttpNotFound();
            }
            return View(wishlistItem);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WishlistItem saving = _context.WishlistItems.Find(id);
            _context.WishlistItems.Remove(saving);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


       

    }
}