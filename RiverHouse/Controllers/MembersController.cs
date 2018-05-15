using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RiverHouse.Models;
using RiverHouse.ViewModels;

namespace RiverHouse.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public MembersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View("MembersList");
        }

        public ActionResult Details()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            var currentUser = userManager.FindById(User.Identity.GetUserId());

            var member = _context.Members.SingleOrDefault(m => m.Id == currentUser.MemberId);
            var bills = _context.Bills.Where(b => b.MemberId == member.Id).ToList();
            var events = _context.Events.Where(e => e.MemberCreatedId == member.Id).ToList();
            var viewModel = new MemberPageViewModel
            {
                 Member = member,
                 Events = events,
                 Bills = bills
            };
            return View("MemberPage", viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Member member)
        {
            if (!ModelState.IsValid)
            {
                var memberViewModel = new MemberFormViewModel
                {
                    Member = member,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("MemberForm", memberViewModel);
            }

            if (member.Id == 0)
            {
                return HttpNotFound();
            }
            else
            {
                var memberInDb = _context.Members.Single(c => c.Id == member.Id);

                memberInDb.Name = member.Name;
                memberInDb.BirthDate = member.BirthDate;
                memberInDb.MembershipTypeId = member.MembershipTypeId;
                memberInDb.PhoneNumber = member.PhoneNumber;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Members");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var member = _context.Members.SingleOrDefault(c => c.Id == id);

            if (member == null)
            {
                return HttpNotFound();
            }

            var memberViewModel = new MemberFormViewModel
            {
                Member = member,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("MemberForm", memberViewModel);
        }
    }
}