using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiverHouse.Models
{
    public class Bill
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PaidFor { get; set; }
        public string PaidBy { get; set; }

        public DateTime DateCreated { get; set; }

        public double Amount { get; set; }

        public int EventId { get; set; }

        public int MemberId { get; set; }

        public bool IsPaid { get; set; }

        public bool Pending { get; set; }
    }
}