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

        public ActionResult Edit(int id)
        {
            var eventInDb = _context.Events.Include(e => e.Guest).SingleOrDefault(e => e.Id == id);
            if (eventInDb == null)
            {
                return HttpNotFound();
            }

            return View("EventForm", eventInDb);
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

            return View("EventDetail", modelView);
        }

    }
}