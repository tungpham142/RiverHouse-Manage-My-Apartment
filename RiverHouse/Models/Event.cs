using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RiverHouse.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double TotalAmount { get; set; }

        public int GuestCount { get; set; }

        public Member MemberCreated { get; set; }

        public List<Member> Guest { get; set; }

        public DateTime? DateCreated { get; set; }

        public string Description { get; set; }
    }
}