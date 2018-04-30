using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiverHouse.Dtos
{
    public class NewEventDto
    {
        public string Name { get; set; }

        public int MemberCreatedId { get; set; }

        public List<int> GuestIds { get; set; }

        public double TotalAmount { get; set; }

        public DateTime? DateCreated { get; set; }

        public string Description { get; set; }

    }
}