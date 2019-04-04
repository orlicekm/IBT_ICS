﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20190312011530_Initialization")]
    partial class Initialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("School.DAL.Entities.AddressEntity", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("City");

                b.Property<string>("Country");

                b.Property<string>("State");

                b.Property<string>("Street");

                b.Property<Guid>("StudentId");

                b.HasKey("Id");

                b.HasIndex("StudentId")
                    .IsUnique();

                b.ToTable("Addresses");
            });

            modelBuilder.Entity("School.DAL.Entities.CourseEntity", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Description");

                b.Property<string>("Name");

                b.HasKey("Id");

                b.ToTable("Courses");
            });

            modelBuilder.Entity("School.DAL.Entities.GradeEntity", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Name");

                b.Property<string>("Section");

                b.HasKey("Id");

                b.ToTable("Grades");
            });

            modelBuilder.Entity("School.DAL.Entities.StudentCourseEntity", b =>
            {
                b.Property<Guid>("StudentId");

                b.Property<Guid>("CourseId");

                b.HasKey("StudentId", "CourseId");

                b.HasIndex("CourseId");

                b.ToTable("StudentCourseEntity");
            });

            modelBuilder.Entity("School.DAL.Entities.StudentEntity", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<Guid?>("GradeId");

                b.Property<string>("Name");

                b.HasKey("Id");

                b.HasIndex("GradeId");

                b.ToTable("Students");
            });

            modelBuilder.Entity("School.DAL.Entities.AddressEntity", b =>
            {
                b.HasOne("School.DAL.Entities.StudentEntity", "Student")
                    .WithOne("Address")
                    .HasForeignKey("School.DAL.Entities.AddressEntity", "StudentId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("School.DAL.Entities.StudentCourseEntity", b =>
            {
                b.HasOne("School.DAL.Entities.CourseEntity", "Course")
                    .WithMany("StudentCourses")
                    .HasForeignKey("CourseId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("School.DAL.Entities.StudentEntity", "Student")
                    .WithMany("StudentCourses")
                    .HasForeignKey("StudentId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("School.DAL.Entities.StudentEntity", b =>
            {
                b.HasOne("School.DAL.Entities.GradeEntity", "Grade")
                    .WithMany("Students")
                    .HasForeignKey("GradeId");
            });
#pragma warning restore 612, 618
        }
    }
}