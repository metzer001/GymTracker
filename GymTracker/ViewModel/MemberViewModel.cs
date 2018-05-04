using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.ViewModel
{
    public class MemberViewModel
    {
        [Required]
        public int MemberID { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }

        
        public string PaymentType { get; set; }




    }
}
