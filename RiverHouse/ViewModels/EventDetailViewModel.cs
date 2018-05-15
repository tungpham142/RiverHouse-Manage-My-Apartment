using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RiverHouse.Models;

namespace RiverHouse.ViewModels
{
    public class EventDetailViewModel
    {
        public Member Member { get; set; }
        public Event Event { get; set; }
        public List<Bill> Bills { get; set; }
    }
}