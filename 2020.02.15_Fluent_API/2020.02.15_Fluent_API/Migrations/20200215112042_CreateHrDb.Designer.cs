﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2020._02._15_Fluent_API.Models;

namespace _2020._02._15_Fluent_API.Migrations
{
    [DbContext(typeof(HrDbContext))]
    [Migration("20200215112042_CreateHrDb")]
    partial class CreateHrDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CommissionPct")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("JobId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.Job", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("MaxSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.JobGrade", b =>
                {
                    b.Property<string>("GradeLevel")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("HighestSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LowestSalary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GradeLevel");

                    b.ToTable("JobGrades");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.JobHistory", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EmployeeId", "StartDate");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("JobId");

                    b.ToTable("JobHistories");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.Country", b =>
                {
                    b.HasOne("_2020._02._15_Fluent_API.Models.Region", "Region")
                        .WithMany("Countries")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.Department", b =>
                {
                    b.HasOne("_2020._02._15_Fluent_API.Models.Location", "Location")
                        .WithMany("Departments")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.Employee", b =>
                {
                    b.HasOne("_2020._02._15_Fluent_API.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_2020._02._15_Fluent_API.Models.Job", null)
                        .WithMany("Employees")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.JobHistory", b =>
                {
                    b.HasOne("_2020._02._15_Fluent_API.Models.Department", "Department")
                        .WithMany("JobHistories")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("_2020._02._15_Fluent_API.Models.Employee", "Employee")
                        .WithMany("JobHistories")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_2020._02._15_Fluent_API.Models.Job", "Job")
                        .WithMany("JobHistories")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("_2020._02._15_Fluent_API.Models.Location", b =>
                {
                    b.HasOne("_2020._02._15_Fluent_API.Models.Country", "Country")
                        .WithMany("Locations")
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}
