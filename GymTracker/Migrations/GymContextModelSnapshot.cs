﻿// <auto-generated />
using GymTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GymTracker.Migrations
{
    [DbContext(typeof(GymContext))]
    partial class GymContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GymTracker.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("MembershipTypeId");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("GymTracker.Models.MembershipType", b =>
                {
                    b.Property<int>("MembershipTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Cost");

                    b.Property<string>("PaymentType");

                    b.HasKey("MembershipTypeId");

                    b.ToTable("MembershipTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
