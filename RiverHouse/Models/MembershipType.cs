using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RiverHouse.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Display(Name = "Membership Type")]
        public string Name { get; set; }

        public double MonthlyPayment { get; set; }

        public static readonly byte Guest = 0;
        public static readonly byte Regular = 1;
        public static readonly byte SmallRoom = 2;
        public static readonly byte MediumRoom = 3;
        public static readonly byte MasterRoom = 4;

    }
}