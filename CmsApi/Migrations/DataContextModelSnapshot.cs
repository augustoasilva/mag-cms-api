﻿// <auto-generated />
using System;
using CmsApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CmsApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CmsApi.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mechanical Engineering"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Software Engineering"
                        });
                });

            modelBuilder.Entity("CmsApi.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StudentId = 1,
                            SubjectId = 1,
                            Value = 9.5
                        },
                        new
                        {
                            Id = 2,
                            StudentId = 1,
                            SubjectId = 1,
                            Value = 7.25
                        },
                        new
                        {
                            Id = 3,
                            StudentId = 1,
                            SubjectId = 1,
                            Value = 8.0
                        },
                        new
                        {
                            Id = 4,
                            StudentId = 1,
                            SubjectId = 2,
                            Value = 8.5
                        },
                        new
                        {
                            Id = 5,
                            StudentId = 1,
                            SubjectId = 2,
                            Value = 8.6999999999999993
                        },
                        new
                        {
                            Id = 6,
                            StudentId = 1,
                            SubjectId = 2,
                            Value = 8.9000000000000004
                        },
                        new
                        {
                            Id = 7,
                            StudentId = 1,
                            SubjectId = 5,
                            Value = 10.0
                        },
                        new
                        {
                            Id = 8,
                            StudentId = 1,
                            SubjectId = 5,
                            Value = 10.0
                        },
                        new
                        {
                            Id = 9,
                            StudentId = 1,
                            SubjectId = 5,
                            Value = 9.0
                        });
                });

            modelBuilder.Entity("CmsApi.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegistrationNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDay = new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ana",
                            LastName = "Silva",
                            RegistrationNumber = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDay = new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Fernando",
                            LastName = "Montero",
                            RegistrationNumber = 1
                        },
                        new
                        {
                            Id = 3,
                            BirthDay = new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Guilherme",
                            LastName = "Sousa",
                            RegistrationNumber = 1
                        },
                        new
                        {
                            Id = 4,
                            BirthDay = new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Milton",
                            LastName = "Nunes",
                            RegistrationNumber = 1
                        },
                        new
                        {
                            Id = 5,
                            BirthDay = new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Alberto",
                            LastName = "Silveira",
                            RegistrationNumber = 1
                        });
                });

            modelBuilder.Entity("CmsApi.Models.StudentSubject", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubjects");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            SubjectId = 1,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 1,
                            SubjectId = 2,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 1,
                            SubjectId = 5,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 2,
                            SubjectId = 1,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 2,
                            SubjectId = 2,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 2,
                            SubjectId = 5,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 3,
                            SubjectId = 1,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 3,
                            SubjectId = 2,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 3,
                            SubjectId = 5,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 4,
                            SubjectId = 3,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 4,
                            SubjectId = 4,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 5,
                            SubjectId = 3,
                            Id = 0
                        },
                        new
                        {
                            StudentId = 5,
                            SubjectId = 4,
                            Id = 0
                        });
                });

            modelBuilder.Entity("CmsApi.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Name = "Calculus 1",
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Name = "Physics 1",
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 2,
                            Name = "Algorithms 1",
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            Name = "Linear Algebra",
                            TeacherId = 4
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 1,
                            Name = "3D CAD Design",
                            TeacherId = 5
                        });
                });

            modelBuilder.Entity("CmsApi.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDay = new DateTime(1980, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Lauro",
                            LastName = "Alvarez",
                            Salary = 1500m
                        },
                        new
                        {
                            Id = 2,
                            BirthDay = new DateTime(1985, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Roberto",
                            LastName = "Hernandez",
                            Salary = 1600m
                        },
                        new
                        {
                            Id = 3,
                            BirthDay = new DateTime(1990, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ronaldo",
                            LastName = "Silva",
                            Salary = 1700m
                        },
                        new
                        {
                            Id = 4,
                            BirthDay = new DateTime(1989, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Rodrigo",
                            LastName = "Wilhelm",
                            Salary = 1800m
                        },
                        new
                        {
                            Id = 5,
                            BirthDay = new DateTime(1992, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Pedro",
                            LastName = "Lobo",
                            Salary = 1900m
                        });
                });

            modelBuilder.Entity("CmsApi.Models.Grade", b =>
                {
                    b.HasOne("CmsApi.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CmsApi.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("CmsApi.Models.StudentSubject", b =>
                {
                    b.HasOne("CmsApi.Models.Student", "Student")
                        .WithMany("Subjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CmsApi.Models.Subject", "Subject")
                        .WithMany("Students")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("CmsApi.Models.Subject", b =>
                {
                    b.HasOne("CmsApi.Models.Course", "Course")
                        .WithMany("Subjects")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CmsApi.Models.Teacher", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("CmsApi.Models.Course", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("CmsApi.Models.Student", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("CmsApi.Models.Subject", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("CmsApi.Models.Teacher", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
