using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.ViewModel
{
    public class MemberClassBookedViewModel
    {
        public int ClassId { get; set; }

        public List<int> MemberIDs { get; set; }

        public string ClassName { get; set; }

        public int ClassSize { get; set; }

        public int NumberOfBookings { get; set; }


    }
}
