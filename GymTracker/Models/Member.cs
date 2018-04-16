using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Models
{
    public class Member
    {


        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }



        public DateTime DateOfBirth { get; set; }

        // foreign key for MembershipType 
        [ForeignKey("MembershipType")]
        public long MembershipTypeId { get; set; }

        //
    }



}

