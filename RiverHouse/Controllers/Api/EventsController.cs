using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using RiverHouse.Dtos;
using RiverHouse.Models;

namespace RiverHouse.Controllers.Api
{
    public class EventsController : ApiController
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

        public IHttpActionResult GetEvents()
        {
            var events = _context.Events.ToList();
            return Ok(events);
        }

        public IHttpActionResult GetEvents(int id)
        {
            var events = _context.Events.Where(e => e.MemberCreated.Id == id).ToList();
            return Ok(events);
        }

        [HttpPost]
        public IHttpActionResult CreateNewEvents(NewEventDto newEvent)
        {
            var memberCreated = _context.Members.Single(m => m.Id == newEvent.MemberCreatedId);
            var guests = _context.Members.Where(s => newEvent.GuestIds.Contains(s.Id)).ToList();
            var guestCount = newEvent.GuestIds.Count();

            var addedEvent = new Event
            {
                Name = newEvent.Name,
                MemberCreated = memberCreated,
                Guest = guests,
                DateCreated = newEvent.DateCreated ?? DateTime.Today,
                Description = newEvent.Description,
                TotalAmount = newEvent.TotalAmount,
                GuestCount = guestCount
            };
            _context.Events.Add(addedEvent);

            if (newEvent.TotalAmount > 0 && guestCount > 0)
            {
                foreach (var guest in guests)
                {
                    var bill = new Bill
                    {
                        Name = "Payment for " + newEvent.Name,
                        PaidFor = memberCreated.Name,
                        DateCreated = newEvent.DateCreated ?? DateTime.Now,
                        Amount = newEvent.TotalAmount / (guestCount + 1),
                        MemberId = guest.Id
                    };
                    _context.Bills.Add(bill);
                }
            }

            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EditEvent(int id)
        {

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteEvent(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var eventInDb = _context.Events.SingleOrDefault(c => c.Id == id);

            if (eventInDb == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
