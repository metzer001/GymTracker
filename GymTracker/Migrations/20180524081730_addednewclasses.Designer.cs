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
    [Migration("20180524081730_addednewclasses")]
    partial class addednewclasses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GymTracker.Models.Classes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassName");

                    b.Property<int>("ClassSize");

                    b.Property<int>("NumberOfBookings");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("GymTracker.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("MembershipTypeId");

                    b.Property<string>("TelephoneNumber");

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