using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IHttpActionResult GetEvet(int id)
        {
            var eEvent = _context.Events.Single(e => e.Id == id);
            return Ok(eEvent);
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
                MemberCreatedId= memberCreated.Id,
                GuestId = newEvent.GuestIds,
                DateCreated = newEvent.DateCreated ?? DateTime.Today,
                Description = newEvent.Description,
                TotalAmount = newEvent.TotalAmount,
                GuestCount = guestCount,
                TotalRemain = Math.Round((newEvent.TotalAmount / (guestCount + 1)), 2) * guestCount
            };
            _context.Events.Add(addedEvent);
            _context.SaveChanges();

            if (newEvent.TotalAmount > 0 && guestCount > 0)
            {
                foreach (var guest in guests)
                {
                    var bill = new Bill
                    {
                        EventId = addedEvent.Id,
                        Name = newEvent.Name,
                        PaidFor = memberCreated.Name,
                        PaidBy = guest.Name,
                        DateCreated = newEvent.DateCreated ?? DateTime.Now,
                        Amount = Math.Round((newEvent.TotalAmount / (guestCount + 1)), 2),
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
            
            var billInDb = _context.Bills.Where(b => b.EventId == eventInDb.Id).ToList();
            foreach (var bill in billInDb)
            {
                _context.Bills.Remove(bill);
            }
            _context.Events.Remove(eventInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
