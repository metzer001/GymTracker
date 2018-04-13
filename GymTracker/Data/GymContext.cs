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

        public DbSet<Member> Members { get; set; }


        public DbSet<MembershipType> MembershipTypes { get; set; }


    }
}
