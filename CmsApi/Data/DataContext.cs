using System;
using System.Collections.Generic;
using System.Globalization;
using CmsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CmsApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student>? Students { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<StudentSubject>? StudentSubjects { get; set; }
        public DbSet<Grade>? Grades { get; set; }
        public DbSet<Course>? Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            builder.Entity<Course>()
                .HasData(new List<Course>()
                {
                new Course(1, "Mechanical Engineering"),
                new Course(2, "Software Engineering")
                });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>()
                {
                new Teacher(1, "Lauro", "Alvarez", new DateTime(1980, 11, 05), new decimal(1500.00)),
                new Teacher(2, "Roberto", "Hernandez", new DateTime(1985, 07, 14), new decimal(1600.00)),
                new Teacher(3, "Ronaldo", "Silva", new DateTime(1990, 02, 25), new decimal(1700.00)),
                new Teacher(4, "Rodrigo", "Wilhelm", new DateTime(1989, 03, 27), new decimal(1800.00)),
                new Teacher(5, "Pedro", "Lobo", new DateTime(1992, 01, 10), new decimal(1900.00))
                });

            builder.Entity<Student>()
                .HasData(new List<Student>()
                {
                new Student(1, "Ana", "Silva", new DateTime(2000, 11, 05), 1),
                new Student(2, "Fernando", "Montero", new DateTime(2000, 11, 05), 1),
                new Student(3, "Guilherme", "Sousa", new DateTime(2000, 11, 05), 1),
                new Student(4, "Milton", "Nunes", new DateTime(2000, 11, 05), 1),
                new Student(5, "Alberto", "Silveira", new DateTime(2000, 11, 05), 1)
                });

            builder.Entity<Subject>()
                .HasData(new List<Subject>()
                {
                new Subject(1, "Calculus 1", 1, 1),
                new Subject(2, "Physics 1", 2, 1),
                new Subject(3, "Algorithms 1", 3, 2),
                new Subject(4, "Linear Algebra", 4, 2),
                new Subject(5, "3D CAD Design", 5, 1)
                });

            builder.Entity<StudentSubject>()
                .HasData(new List<StudentSubject>()
                {
                new StudentSubject() {StudentId = 1, SubjectId = 1},
                new StudentSubject() {StudentId = 1, SubjectId = 2},
                new StudentSubject() {StudentId = 1, SubjectId = 5},
                new StudentSubject() {StudentId = 2, SubjectId = 1},
                new StudentSubject() {StudentId = 2, SubjectId = 2},
                new StudentSubject() {StudentId = 2, SubjectId = 5},
                new StudentSubject() {StudentId = 3, SubjectId = 1},
                new StudentSubject() {StudentId = 3, SubjectId = 2},
                new StudentSubject() {StudentId = 3, SubjectId = 5},
                new StudentSubject() {StudentId = 4, SubjectId = 3},
                new StudentSubject() {StudentId = 4, SubjectId = 4},
                new StudentSubject() {StudentId = 5, SubjectId = 3},
                new StudentSubject() {StudentId = 5, SubjectId = 4},
                });

            builder.Entity<Grade>()
                .HasData(new List<Grade>()
                {
                new Grade() {Id = 1, StudentId = 1, SubjectId = 1, Value = 9.5},
                new Grade() {Id = 2, StudentId = 1, SubjectId = 1, Value = 7.25},
                new Grade() {Id = 3, StudentId = 1, SubjectId = 1, Value = 8.0},
                new Grade() {Id = 4, StudentId = 1, SubjectId = 2, Value = 8.5},
                new Grade() {Id = 5, StudentId = 1, SubjectId = 2, Value = 8.7},
                new Grade() {Id = 6, StudentId = 1, SubjectId = 2, Value = 8.9},
                new Grade() {Id = 7, StudentId = 1, SubjectId = 5, Value = 10.0},
                new Grade() {Id = 8, StudentId = 1, SubjectId = 5, Value = 10.0},
                new Grade() {Id = 9, StudentId = 1, SubjectId = 5, Value = 9.0},
                });
        }
    }
}