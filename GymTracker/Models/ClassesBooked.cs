using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Models
{
    public class ClassesBooked
    {
        public int Id { get; set; }

        public int MemberID { get; set; }

        public int ClassID { get; set; }


        public Classes Class { get; set; }


        public Member Member  { get; set; }

    }
}
