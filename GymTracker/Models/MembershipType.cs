using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Models
{
    public class MembershipType
    {

        

        public int MembershipTypeId { get; set; }

        public string PaymentType { get; set; }

        public double Cost { get; set; }

    



}


    public enum Membershiptype { Monthly = 1, Annually, PAYG }
}
