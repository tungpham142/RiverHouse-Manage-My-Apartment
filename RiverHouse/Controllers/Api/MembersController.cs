using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using RiverHouse.Dtos;
using RiverHouse.Models;

namespace RiverHouse.Controllers.Api
{
    [Authorize]
    public class MembersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MembersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Members
        public IHttpActionResult GetMembers(string query = null)
        {
            var members = _context.Members.Include(m => m.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
            {
                members = members.Where(m => m.Name.Contains(query));
            }     
                
            var membersDto = members.ToList().Select(Mapper.Map<Member, MemberDto>);
            return Ok(membersDto);
        }

        // GET /api/Members/1
        public IHttpActionResult GetMembers(int id)
        {
            var member = _context.Members.SingleOrDefault(m => m.Id == id);

            if (member == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Member, MemberDto>(member));
        }

        //// POST /api/Members
        //[HttpPost]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        //public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
        //    _context.Members.Add(customer);
        //    _context.SaveChanges();

        //    customerDto.Id = customer.Id;
        //    return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        //}

        //// PUT /api/Members/1
        //[HttpPut]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        //public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var customerInDb = _context.Members.SingleOrDefault(c => c.Id == id);
        //    if (customerInDb == null)
        //    {
        //        return NotFound();
        //    }

        //    Mapper.Map(customerDto, customerInDb);
        //    _context.SaveChanges();
        //    return Ok();
        //}

        ////DELETE /api/Members/1
        //[HttpDelete]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        //public IHttpActionResult DeleteCustomer(int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var customerInDb = _context.Members.SingleOrDefault(c => c.Id == id);

        //    if (customerInDb == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Members.Remove(customerInDb);
        //    _context.SaveChanges();
        //    return Ok();
        //}
    }
}
