using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RiverHouse.Models;

namespace RiverHouse.ViewModels
{
    public class MemberPageViewModel
    {
        public Member Member { get; set; }

        public List<Event> Events { get; set; }

        public List<Bill> Bills { get; set; }
    }
}