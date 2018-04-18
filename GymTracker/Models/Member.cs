﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        // foreign key for MembershipType 
        [ForeignKey("MembershipType")]
        public int MembershipTypeId { get; set; }

        
        //public virtual Membershiptype MembershipType { get; set; }
    }



}

