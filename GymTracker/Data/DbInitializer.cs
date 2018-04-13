using GymTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Data
{
    public class DbInitializer
    {
        public static void Initialize(GymContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Members.Any())
            {
                return;   // DB has been seeded
            }

            var members = new Member[]
            {
            new Member{FirstName="Carson",LastName="Alexander",DateOfBirth=DateTime.Parse("2005-09-01"), MembershipTypeId = 1},
            new Member{FirstName="Meredith",LastName="Alonso",DateOfBirth=DateTime.Parse("1995-09-01"), MembershipTypeId=1},
            new Member{FirstName="Arturo",LastName="Anand",DateOfBirth=DateTime.Parse("1986-09-01"), MembershipTypeId=3
            }
      
            };
            foreach (Member s in members)
            {
                context.Members.Add(s);
            }
            context.SaveChanges();




            var membershipTypes = new MembershipType[]
            {
            new MembershipType{Cost = 29.99 , PaymentType="Monthly" },
            new MembershipType{Cost= 229.99, PaymentType="Annually"},
            new MembershipType{Cost= 4.99, PaymentType="PAYG"}
   

            };
            foreach (MembershipType c in membershipTypes)
            {
                context.MembershipTypes.Add(c);
            }
            context.SaveChanges();

     
        }
    


}
}
