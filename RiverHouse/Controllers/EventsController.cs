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
    public class EventsController : Controller
    {       
        private readonly ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            return View("EventsList");
        }

        [Authorize]
        public ActionResult New()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            var currentUser = userManager.FindById(User.Identity.GetUserId());

            var member = _context.Members.SingleOrDefault(m => m.Id == currentUser.MemberId);
            return View("Create", member);
        }

        public ActionResult Detail(int id)
        {
            var eventInDb = _context.Events.Include(e => e.Guest).SingleOrDefault(e => e.Id == id);
            if (eventInDb == null)
            {
                return HttpNotFound();
            }

            var bills = _context.Bills.Where(b => b.EventId == eventInDb.Id).ToList();
            var host = _context.Members.SingleOrDefault(m => m.Id == eventInDb.MemberCreatedId);
          
            var modelView = new EventDetailViewModel
            {
                Member = host,
                Event = eventInDb,
                Bills = bills
            };

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            var currentUser = userManager.FindById(User.Identity.GetUserId());

            return View(currentUser.MemberId == eventInDb.MemberCreatedId ? "EventDetailAdmin" : "EventDetail", modelView);
        }

        public ActionResult EditPaymentStatus(int id)
        {
            var bill = _context.Bills.SingleOrDefault(b => b.Id == id);
            var eEvent = _context.Events.SingleOrDefault(e => e.Id == bill.EventId);
            if (bill == null || eEvent == null)
                return HttpNotFound();

            bill.IsPaid = true;
            eEvent.TotalRemain -= Math.Round((eEvent.TotalAmount / (eEvent.GuestCount + 1)), 2);
            if (CheckEventComplete(eEvent))
            {
                eEvent.IsCompleted = true;
            }
            _context.SaveChanges();
            return RedirectToAction("Detail", "Events", new {id = eEvent.Id});
        }

        public ActionResult Completed(int id)
        {
            var eEvent = _context.Events.SingleOrDefault(e => e.Id == id);
            if (eEvent == null)
                return HttpNotFound();

            eEvent.IsCompleted = true;
            eEvent.TotalRemain = 0.0;
            _context.SaveChanges();
            return RedirectToAction("Details", "Members");
        }


        private bool CheckEventComplete(Event eEvent)
        {
            var bills = _context.Bills.Where(b => b.EventId == eEvent.Id).ToList();
            foreach (var bill in bills)
            {
                if (!bill.IsPaid)
                    return false;
            }

            return true;
        }

    }
}