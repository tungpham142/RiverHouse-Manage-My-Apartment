using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using RiverHouse.Models;

namespace RiverHouse.ViewModels
{
    public class MemberFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Member Member { get; set; }
    }
}