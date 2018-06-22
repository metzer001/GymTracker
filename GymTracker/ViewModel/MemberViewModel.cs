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
        [StringLength(50,  ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

       
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DateOfBirth { get; set; }
        
        public string TelephoneNumber { get; set; }

        
        public string PaymentType { get; set; }

     




    }
}
