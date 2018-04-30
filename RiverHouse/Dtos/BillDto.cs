using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RiverHouse.Models;

namespace RiverHouse.Dtos
{
    public class BillDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int MemberCreatedId { get; set; }

        public double? Total { get; set; }

        public List<int> MembersPaidIdList { get; set; }

        public DateTime? DateCreated { get; set; }

        public string Description { get; set; }

    }
}