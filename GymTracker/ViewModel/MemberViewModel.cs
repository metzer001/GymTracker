using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.ViewModel
{
    public class MemberViewModel
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PaymentType { get; set; }

        
    }
}
