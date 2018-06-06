using GymTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.ViewModel
{
    public class MemberClassViewModel
    {
        [Required]
        public int MemberID { get; set; }

        [Required]
        public int ClassID { get; set; }

        public string ClassName { get; set; }

        public List<Member> MemberClassBookings { get; set; }



    }
}
