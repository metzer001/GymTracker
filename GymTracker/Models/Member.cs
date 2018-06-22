using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Models
{
    public class Member
    {


        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

     
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        
        public string TelephoneNumber { get; set; }
        [Required]
        // foreign key for MembershipType 
        [ForeignKey("MembershipType")]
        [DisplayName("Payment Type")]
        public int MembershipTypeId { get; set; }

       

        
        //public virtual Membershiptype MembershipType { get; set; }
    }



}

