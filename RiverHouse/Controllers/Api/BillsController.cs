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
