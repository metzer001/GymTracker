using GymTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.Data
{
    public class GymContext : DbContext
    {


        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {
           
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ClassesBooked>().
        //        HasOne(c => c.Class);

                
        //}

        public DbSet<Member> Members { get; set; }


        public DbSet<MembershipType> MembershipTypes { get; set; }

        public DbSet<Classes> Classes { get; set; }

        public DbSet<ClassesBooked> ClassesBooked {get;set;}



    }
}
