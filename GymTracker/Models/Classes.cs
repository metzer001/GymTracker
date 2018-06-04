using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Models
{
    public class Classes
    {


        public int Id { get; set; }

        public string  ClassName { get; set; }

        public int ClassSize { get; set; }

        public int NumberOfBookings { get; set; }   

        public List<Member>MemberClassBookings { get; set; }




    }
}
