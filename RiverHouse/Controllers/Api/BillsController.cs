using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using RiverHouse.Dtos;
using RiverHouse.Models;

namespace RiverHouse.Controllers.Api
{
    public class BillsController : ApiController
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

        public IHttpActionResult GetBills(int id)
        {
            var bills = _context.Bills.Where(b => b.EventId == id).ToList();
            return Ok(bills);
        }

        [HttpPut]
        public IHttpActionResult EditBills(int id)
        {
            var bill = _context.Bills.Single(b => b.Id == id);
            bill.IsPaid = !bill.IsPaid;
            _context.SaveChanges();
            return Ok(bill);
        }
        //[HttpPost]
        ////public IHttpActionResult CreatePayments(PaymentDto paymentDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    //var payment = Mapper.Map<PaymentDto, Payment>(paymentDto);
        //    //_context.Payments.Add(payment);
        //    //_context.SaveChanges();

        //    //paymentDto.Id = payment.Id;
        //    //return Created(new Uri(Request.RequestUri + "/" + payment.Id), paymentDto);
        //}
    }
}
