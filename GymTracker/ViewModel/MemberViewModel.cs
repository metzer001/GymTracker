using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.ViewModel
{
    public class MemberViewModel
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        public string TelephoneNumber { get; set; }

        public string PaymentType { get; set; }




    }
}
