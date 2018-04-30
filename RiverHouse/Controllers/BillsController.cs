using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RiverHouse.Models;

namespace RiverHouse.Controllers
{
    public class BillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BillsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Payments
        public ActionResult Create()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            var currentUser = userManager.FindById(User.Identity.GetUserId());

            var member = _context.Members.SingleOrDefault(m => m.Id == currentUser.MemberId);
            return View("BillForm", member);
        }
    }
}